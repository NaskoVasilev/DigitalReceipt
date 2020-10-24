import Vue from 'vue'
import App from './App.vue'
import { sync } from 'vuex-router-sync'
import router from './router'
import store from './store'
import BootstrapVue from 'bootstrap-vue'
import VueCookies from 'vue-cookies'
import { FontAwesomeIcon } from './icons'
import axios from 'axios'

Vue.config.productionTip = false

Vue.prototype.$http = axios

Vue.use(BootstrapVue)
Vue.use(VueCookies)

Vue.prototype.$cookies = VueCookies
Vue.component('icon', FontAwesomeIcon)

sync(store, router)

axios.interceptors.request.use(
  (config) => {
      let token = VueCookies.get('access_token') || null;

      if (token) {
          config.headers['Authorization'] = `Bearer ${token}`;
      }

      return config;
  },

  (error) => {
      return Promise.reject(error);
  }
);

const app = new Vue({
  el: "#app",
    store,
    router,
    render: h => h(App),
})

export {
  app,
  router,
  store
}
