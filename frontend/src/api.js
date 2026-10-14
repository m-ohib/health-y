// Det eneste sted i frontenden, der kender API'ets adresse og endpoints.
// Komponenter kalder fx getWalks() og ved intet om URL'er.
import { useAuthStore } from './features/auth/authStore'

const baseUrl = import.meta.env.VITE_API_URL

async function request(path, options = {}) {
  const auth = useAuthStore()

  // TODO: Tilføj 'Authorization': `Bearer ${auth.token}` til headers, når brugeren er logget ind.
  const response = await fetch(`${baseUrl}${path}`, {
    ...options,
    headers: { 'Content-Type': 'application/json', ...options.headers },
  })

  // TODO: Ved 401: kald auth.logout(), og send brugeren til login-siden.
  // TODO: Ved 400: API'et sender { detail: "venlig dansk besked" }. Kast en Error med den besked,
  //       så komponenten kan vise den til brugeren.
  if (!response.ok) {
    throw new Error(`API-fejl ${response.status}`)
  }

  return response.status === 204 ? null : response.json()
}

// ----- Auth (US 1 og 2) -----
export const register = (email, password, birthYear) =>
  request('/api/auth/register', { method: 'POST', body: JSON.stringify({ email, password, birthYear }) })

export const login = (email, password) =>
  request('/api/auth/login', { method: 'POST', body: JSON.stringify({ email, password }) })

// ----- Gåture (US 3, 4, 5, 14) -----
export const getWalks = () => request('/api/walks')

/** Returnerer { walk, praise }. Vis praise bagefter (US 12). */
export const createWalk = (walk) => request('/api/walks', { method: 'POST', body: JSON.stringify(walk) })

export const updateWalk = (id, walk) => request(`/api/walks/${id}`, { method: 'PUT', body: JSON.stringify(walk) })

export const deleteWalk = (id) => request(`/api/walks/${id}`, { method: 'DELETE' })

// ----- Mål (US 6) -----
export const getGoal = () => request('/api/goal')

export const setGoal = (type, dailyTarget) =>
  request('/api/goal', { method: 'PUT', body: JSON.stringify({ type, dailyTarget }) })

// ----- Forside (US 7, 8, 9) -----
export const getWeekSummary = () => request('/api/summary/week')

// ----- Dagens ret (US 11) -----
export const getTodaysRecipe = () => request('/api/recipes/today')

// ----- Konto (US 10 og GDPR) -----
export const getSettings = () => request('/api/account/settings')

export const saveSettings = (settings) =>
  request('/api/account/settings', { method: 'PUT', body: JSON.stringify(settings) })

export const deleteAccount = () => request('/api/account', { method: 'DELETE' })
