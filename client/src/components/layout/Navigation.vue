<template>
    <div class="main-nav">
        <nav class="navbar navbar-expand-lg navbar-dark bg-vue">
            <router-link to="/" tag="a" class="navbar-brand"
                >Smart Receipt</router-link
            >
            <button
                class="navbar-toggler hamburger-menu"
                type="button"
                data-toggle="collapse"
                data-target="#navbarContent"
                aria-controls="navbarContent"
                aria-expanded="false"
                aria-label="Toggle navigation"
            >
                <icon icon="bars" />
            </button>
            <div class="collapse navbar-collapse" id="navbarContent">
                <ul
                    class="nav navbar-nav justify-content-end nav-items-container ml-lg-auto mr-lg-0"
                >
                    <li
                        v-if="isUserAuthenticated && !hasAdminRights"
                        class="nav-item"
                        v-for="(route, index) in routes"
                        :key="index"
                    >
                        <router-link
                            class="nav-link text-white"
                            :to="route.path"
                            exact-active-class="active"
                        >
                            <span>{{ route.display }}</span>
                        </router-link>
                    </li>
                    <li><span class="point-separator"> • </span></li>
                    <li
                        v-if="isUserAuthenticated && hasAdminRights"
                        class="nav-item"
                        v-for="(route, index) in adminRoutes"
                        :key="index + 100"
                    >
                        <router-link
                            class="nav-link text-white"
                            :to="route.path"
                            exact-active-class="active"
                        >
                            <span>{{ route.display }}</span>
                        </router-link>
                    </li>
                    <li
                        v-if="!isUserAuthenticated"
                        class="nav-item"
                        v-for="(route, index) in anonymousAccountRoutes"
                        :key="index + 100"
                    >
                        <router-link
                            class="nav-link text-white"
                            :to="route.path"
                            exact-active-class="active"
                        >
                            <span>{{ route.display }}</span>
                        </router-link>
                    </li>
                    <li v-if="isUserAuthenticated" class="nav-item">
                        <router-link
                            class="nav-link text-white"
                            exact-active-class="active"
                            to="Home"
                        >
                            <span>{{ this.userEmail }}</span>
                        </router-link>
                    </li>
                    <li v-if="isUserAuthenticated" class="nav-item">
                        <form method="post" @submit.prevent="submitLogoutForm">
                            <button type="submit" class="nav-link text-white">
                                Logout
                            </button>
                        </form>
                    </li>
                </ul>
            </div>
        </nav>
    </div>
</template>

<script>
export default {
    data() {
        return {
            routes: [
                { display: this.userEmail, path: "/home" },
                { display: "Receipts", path: "/receipts" },
                { display: "Statistics", path: "/statistics" },
            ],
            anonymousAccountRoutes: [
                { display: "Register", path: "/register" },
                { display: "Login", path: "/login" },
            ],
            adminRoutes: [{ display: this.userEmail, path: "/admin/home" }],
        };
    },
    computed: {
        isUserAuthenticated() {
            return this.$store.getters.loggedIn;
        },
        userEmail() {
            return this.$store.getters.userEmail;
        },
        hasAdminRights() {
            return this.$store.getters.hasAdminRights;
        },
    },
    methods: {
        submitLogoutForm: function () {
            this.$store.dispatch("destroyToken").then(() => {
                this.$router.push({ name: "login" });
            });
        },
    },
};
</script>

<style>
.hamburger-menu {
    border: none;
    box-shadow: none !important;
    outline: none !important;
}
.hamburger-menu * {
    color: #fff !important;
}

.nav-items-container a,
.nav-items-container button {
    font-weight: bold;
    text-transform: uppercase;
    text-align: center;
}

.nav-items-container button {
    background: none;
    border: none;
}

.nav-items-container a.active,
.nav-items-container a:hover,
.nav-items-container button:hover {
    color: #334a5e !important;
}

.point-separator {
    font-size: 24px;
    color: #fff;
}

@media only screen and (max-width: 991px) {
    .point-separator {
        display: none;
    }
}
</style>