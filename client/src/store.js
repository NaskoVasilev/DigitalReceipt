import Vue from 'vue'
import Vuex from 'vuex'
import VueCookies from 'vue-cookies'
import axios from 'axios'
import jwtDecode from 'jwt-decode'

Vue.use(Vuex)
Vue.use(VueCookies)

// const roleClaim = 'http://schemas.microsoft.com/ws/2008/06/identity/claims/role';

const axiosConfig = {
    baseURL: 'https://localhost:44316',
    timeout: 30000,
};

let http = axios.create(axiosConfig)

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

// STATE
const state = {
    accessToken: VueCookies.get('access_token') || null,
    userEmail: (VueCookies.get('access_token') != null) ? jwtDecode(VueCookies.get('access_token')).email : '',
    userRoles: (VueCookies.get('access_token') != null) ? jwtDecode(VueCookies.get('access_token'))['role'] : null,
    userId: (VueCookies.get('access_token') != null) ? jwtDecode(VueCookies.get('access_token'))['nameid'] : '',
}

// GETTERS
const getters = {
    loggedIn(state) {
        return state.accessToken !== null;
    },
    userEmail(state) {
        return state.userEmail;
    },
    userRoles(state) {
        return state.userRoles;
    },
    hasAdminRights(state) {
        return state.userRoles != null ? state.userRoles.includes('Administrator') : false
    },
    userId(state) {
        return state.userId != null ? state.userId : '';
    }
}

// MUTATIONS
const mutations = {
    SET_TOKEN(state, token) {
        state.accessToken = token;
    },
    SET_USER_EMAIL(state, email) {
        state.userEmail = email;
    },
    SET_USER_ROLES(state, roles) {
        state.userRoles = roles;
    },
    SET_USER_ID(state, id) {
        state.userId = id;
    }
}

// ACTIONS
const actions = ({
    validateAuthentication(context) {
        context.commit("SET_TOKEN", (VueCookies.get('access_token') || null));
    },
    retrieveToken(context, credentials) {
        return new Promise((resolve, reject) => {
            http.post("/api/Users/Login", {
                'email': credentials.email,
                'password': credentials.password
            })
                .then(response => {
                    if (response.data) {
                        context.commit("SET_TOKEN", response.data.token);
                        VueCookies.set('access_token', response.data.token);
                        context.commit("SET_USER_EMAIL", jwtDecode(response.data.token).email);
                        context.commit("SET_USER_ROLES", response.data.roles);
                        context.commit("SET_USER_ID", response.data.userId);
                    }

                    resolve(response);
                })
                .catch(e => {
                    reject(e);
                })
        });
    },
    destroyToken(context) {
        context.commit("SET_TOKEN", null);
        VueCookies.remove('access_token');
        context.commit("SET_USER_EMAIL", '');
        context.commit("SET_USER_ROLES", null);
        context.commit("SET_USER_ID", null);
    },
    registerUser(context, credentials) {
        return new Promise((resolve, reject) => {
            http.post("api/Users/Register", {
                'email': credentials.email,
                'password': credentials.password,
            })
                .then(response => {
                    resolve(response);
                })
                .catch(e => {
                    reject(e);
                })
        });
    }
})

export default new Vuex.Store({
    state,
    getters,
    mutations,
    actions
})
