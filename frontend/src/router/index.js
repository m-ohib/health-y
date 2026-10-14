import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../features/home/HomeView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    { path: '/', name: 'home', component: HomeView },
    { path: '/log-ind', name: 'login', component: () => import('../features/auth/LoginView.vue'), meta: { public: true } },
    { path: '/opret', name: 'register', component: () => import('../features/auth/RegisterView.vue'), meta: { public: true } },
    { path: '/privatliv', name: 'privacy', component: () => import('../features/privacy/PrivacyView.vue'), meta: { public: true } },
    { path: '/tilfoej', name: 'add-walk', component: () => import('../features/walks/AddWalkView.vue') },
    { path: '/gaature', name: 'walks', component: () => import('../features/walks/WalkListView.vue') },
    { path: '/maal', name: 'goal', component: () => import('../features/goal/GoalView.vue') },
    { path: '/indstillinger', name: 'settings', component: () => import('../features/settings/SettingsView.vue') },
  ],
})

// TODO: router.beforeEach: er siden ikke meta.public, og er brugeren ikke logget ind (useAuthStore().isLoggedIn),
//       så send til { name: 'login' }.

export default router
