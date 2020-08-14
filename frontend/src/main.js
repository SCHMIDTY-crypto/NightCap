import '@babel/polyfill'
import 'mutationobserver-shim'
import Vue from 'vue'
import './plugins/bootstrap-vue'
import App from './App.vue'
import router from './router/index'
import store from './store/index'
import axios from 'axios'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import {BootstrapVue, BootstrapVueIcons} from 'bootstrap-vue'
import moment from 'moment'


Vue.filter('formatDate', function(value) {
  if (value) {
    return moment.utc(String(value)).local().format('MM/DD/YY, hh:mm:ss')
  }
})
Vue.use(BootstrapVue);
Vue.use(BootstrapVueIcons)
Vue.config.productionTip = false

axios.defaults.baseURL = process.env.VUE_APP_REMOTE_API;

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
