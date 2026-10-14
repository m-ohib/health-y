<script setup>
// US 2: Log ind. Designregel: Birgit skal kunne klare det selv.
// TODO: ref til email og password.
// TODO: Ved submit: kald login() fra api.js, gem token med authStore.setToken, og gå til forsiden (router.push('/')).
// TODO: Forkert login: vis ÉN venlig fejlbesked fra API'et.
// TIP: Fejlbeskeden skal være i et element med role="alert", så skærmlæsere læser den op.
</script>

<template>
  <main>
    <h1>Log ind</h1>
    <!-- TODO: <form @submit.prevent="...">
         - <label for="email">E-mail</label> + <input id="email" type="email" autocomplete="email">
         - <label for="password">Adgangskode</label> + <PasswordInput>
         - Én stor knap: "Log ind"
         - Link: "Ny bruger? Opret konto" (RouterLink til /opret) -->
    <!-- TIP: Hvert felt skal have en <label for>, ikke kun placeholder. Det er et WCAG-krav. -->
  </main>
</template>
