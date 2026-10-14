import { defineStore } from 'pinia'
import { computed, ref } from 'vue'

// Holder styr på, om brugeren er logget ind.
export const useAuthStore = defineStore('auth', () => {
  const token = ref(null)

  const isLoggedIn = computed(() => token.value !== null)

  function setToken(newToken) {
    token.value = newToken
    // TODO: Gem token, så man forbliver logget ind efter genindlæsning (US 2: "forbliv logget ind").
    // TIP (sikkerhed): localStorage er nemt, men kan læses af et XSS-angreb. Den sikreste løsning er en
    //                  HttpOnly-cookie sat af API'et. Vælg bevidst, og skriv valget i README.
  }

  function logout() {
    token.value = null
    // TODO: Fjern også den gemte token.
  }

  // TODO: Ved opstart: hent en gemt token, hvis der er en.

  return { token, isLoggedIn, setToken, logout }
})
