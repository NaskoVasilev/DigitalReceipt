import Vue from 'vue'
import App from './App.vue'
import { sync } from 'vuex-router-sync'
import router from './router'
import store from './store'
import BootstrapVue from 'bootstrap-vue'
import VueCookies from 'vue-cookies'
import { FontAwesomeIcon } from './icons'
import axios from 'axios'
import VueQrCode from 'vue-qrcode'
import VueQrcodeReader from "vue-qrcode-reader";
import BarChart from './components/Chart.vue';
import moment from 'moment';

Vue.config.productionTip = false

const axiosConfig = {
  baseURL: 'https://localhost:44316/',
  timeout: 30000,
};

let http = axios.create(axiosConfig)

Vue.use(BootstrapVue)
Vue.use(VueCookies)
Vue.use(VueQrcodeReader)

Vue.prototype.$cookies = VueCookies
Vue.component('icon', FontAwesomeIcon)
Vue.component('qrcode', VueQrCode)
Vue.component('bar-chart', BarChart)

Vue.filter('formatDate', function (value) {
  if (value) {
    return moment(String(value)).format('DD/MM/YYYY hh:mm')
  }
})

sync(store, router)

http.interceptors.request.use(
  (config) => {
    config.headers['Content-Type'] = "application/json"

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

Vue.prototype.$http = http

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
