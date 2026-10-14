import { defineStore } from 'pinia'
import { ref } from 'vue'

// Brugerens indstillinger (US 10). Bruges af forsiden og "Tilføj gåtur" til at vælge Enkel/Udvidet.
export const useSettingsStore = defineStore('settings', () => {
  const viewMode = ref('Simple')
  const birthYear = ref(null)

  // TODO: async function load(): hent med getSettings() fra api.js, og sæt viewMode og birthYear.
  // TODO: async function save(): gem med saveSettings({ birthYear, viewMode }).

  return { viewMode, birthYear }
})
