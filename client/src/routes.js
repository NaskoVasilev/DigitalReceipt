import Login from './components/authentication/Login'
import Register from './components/authentication/Register'
import HelloWorld from './components/HelloWorld'

import store from './store'

const guard = async (to, from, next) => {
    store.dispatch("validateAuthentication").then(response => {
        if (store.getters.loggedIn) {
            next();
        } else {
            next('/login');
        }
    });
};

const authGuard = async (to, from, next) => {
    store.dispatch("validateAuthentication").then(response => {
        if (!store.getters.loggedIn) {
            next();
        } else {
            next('/');
        }
    });
};

const adminGuard = async (to, from, next) => {
    store.dispatch("validateAuthentication").then(response => {
        if (store.getters.loggedIn && store.getters.hasAdminRights) {
            next();
        } else {
            next('/');
        }
    });
};


export const routes = [
    { name: 'login', path: '/login', component: Login, beforeEnter: authGuard },
    { name: 'register', path: '/register', component: Register, beforeEnter: authGuard },
    { name: 'hello-world', path: '/helloworld', component: HelloWorld, beforeEnter: guard },

    //     { name: 'page-not-found',  path: '/404', component: PageNotFound },
    { name: 'redirect', path: '*', redirect: '/login' },
]