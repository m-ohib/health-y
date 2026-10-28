targetScope = 'resourceGroup'

@allowed(['swedencentral', 'francecentral', 'germanywestcentral', 'norwayeast', 'switzerlandnorth'])
param location string = 'swedencentral'

@description('Container-image, fx ghcr.io/m-ohib/health-y:latest')
param containerImage string

@description('Entra-login (UPN) på den, der er administrator for SQL-serveren')
param sqlAdminLogin string

@description('Object id på samme person')
param sqlAdminObjectId string

@description('GitHub-repo, der må deploye: ejer/navn')
param githubRepo string = 'm-ohib/health-y'

@description('Egne domæner, der må bruges som Host-header')
param customHostNames array = ['health-y.dk', 'www.health-y.dk']

var suffix = take(uniqueString(resourceGroup().id), 6)
var appName = 'ca-healthy'
var databaseName = 'healthy'

resource logs 'Microsoft.OperationalInsights/workspaces@2023-09-01' = {
  name: 'log-healthy-${suffix}'
  location: location
  properties: {
    sku: { name: 'PerGB2018' }
    retentionInDays: 30
    workspaceCapping: { dailyQuotaGb: json('0.1') }
  }
}

resource env 'Microsoft.App/managedEnvironments@2024-03-01' = {
  name: 'cae-healthy-${suffix}'
  location: location
  properties: {
    appLogsConfiguration: {
      destination: 'log-analytics'
      logAnalyticsConfiguration: {
        customerId: logs.properties.customerId
        sharedKey: logs.listKeys().primarySharedKey
      }
    }
  }
}

resource sqlServer 'Microsoft.Sql/servers@2023-08-01-preview' = {
  name: 'sql-healthy-${suffix}'
  location: location
  properties: {
    minimalTlsVersion: '1.2'
    publicNetworkAccess: 'Enabled'
    administrators: {
      administratorType: 'ActiveDirectory'
      azureADOnlyAuthentication: true
      login: sqlAdminLogin
      sid: sqlAdminObjectId
      tenantId: subscription().tenantId
      principalType: 'User'
    }
  }
}

resource allowAzureServices 'Microsoft.Sql/servers/firewallRules@2023-08-01-preview' = {
  parent: sqlServer
  name: 'AllowAllWindowsAzureIps'
  properties: {
    startIpAddress: '0.0.0.0'
    endIpAddress: '0.0.0.0'
  }
}

resource database 'Microsoft.Sql/servers/databases@2023-08-01-preview' = {
  parent: sqlServer
  name: databaseName
  location: location
  sku: {
    name: 'GP_S_Gen5'
    tier: 'GeneralPurpose'
    family: 'Gen5'
    capacity: 2
  }
  properties: {
    useFreeLimit: true
    freeLimitExhaustionBehavior: 'AutoPause'
    autoPauseDelay: 60
    minCapacity: json('0.5')
    maxSizeBytes: 34359738368
    zoneRedundant: false
    requestedBackupStorageRedundancy: 'Local'
  }
}

resource app 'Microsoft.App/containerApps@2024-03-01' = {
  name: appName
  location: location
  identity: { type: 'SystemAssigned' }
  properties: {
    environmentId: env.id
    configuration: {
      activeRevisionsMode: 'Single'
      ingress: {
        external: true
        targetPort: 8080
        transport: 'auto'
        allowInsecure: false
      }
    }
    template: {
      containers: [
        {
          name: 'healthy'
          image: containerImage
          resources: {
            cpu: json('0.25')
            memory: '0.5Gi'
          }
          env: [
            { name: 'ASPNETCORE_ENVIRONMENT', value: 'Production' }
            { name: 'ASPNETCORE_FORWARDEDHEADERS_ENABLED', value: 'true' }
            { name: 'AllowedHosts', value: join(concat(customHostNames, ['${appName}.${env.properties.defaultDomain}']), ';') }
            {
              name: 'ConnectionStrings__HealthY'
              value: 'Server=tcp:${sqlServer.properties.fullyQualifiedDomainName},1433;Database=${databaseName};Authentication=Active Directory Managed Identity;Encrypt=True;TrustServerCertificate=False;Connect Timeout=60;'
            }
          ]
        }
      ]
      scale: {
        minReplicas: 0
        maxReplicas: 1
      }
    }
  }
}

resource deployIdentity 'Microsoft.ManagedIdentity/userAssignedIdentities@2023-01-31' = {
  name: 'id-healthy-github'
  location: location
}

resource githubFederation 'Microsoft.ManagedIdentity/userAssignedIdentities/federatedIdentityCredentials@2023-01-31' = {
  parent: deployIdentity
  name: 'github-main'
  properties: {
    issuer: 'https://token.actions.githubusercontent.com'
    subject: 'repo:${githubRepo}:ref:refs/heads/main'
    audiences: ['api://AzureADTokenExchange']
  }
}

var contributorRoleId = 'b24988ac-6180-42a0-ab88-20f7382dd24c'

resource deployRole 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(resourceGroup().id, deployIdentity.id, contributorRoleId)
  properties: {
    principalId: deployIdentity.properties.principalId
    principalType: 'ServicePrincipal'
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', contributorRoleId)
  }
}

output appUrl string = 'https://${app.properties.configuration.ingress.fqdn}'
output appName string = app.name
output sqlServerName string = sqlServer.name
output sqlServerFqdn string = sqlServer.properties.fullyQualifiedDomainName
output databaseName string = databaseName
output environmentVerificationId string = app.properties.customDomainVerificationId
output deployClientId string = deployIdentity.properties.clientId
