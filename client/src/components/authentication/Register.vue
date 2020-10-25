<template>
    <div class="container login-container">
        <div class="login-form-1">
            <h2>Register</h2>
            <form method="post" @submit.prevent="submitRegisterForm">
                <div class="form-group">
                    <input
                        type="text"
                        class="form-control"
                        placeholder="Email"
                        value=""
                        v-model="email"
                    />
                </div>
                <div class="form-group">
                    <input
                        type="password"
                        class="form-control"
                        placeholder="Password"
                        value=""
                        v-model="password"
                    />
                </div>
                <div class="form-group">
                    <input
                        type="password"
                        class="form-control"
                        placeholder="Confirm Password"
                        value=""
                        v-model="confirmedPassword"
                    />
                </div>
                <div class="form-group">
                    <input type="submit" class="btnSubmit" value="Register" />
                </div>
                <div class="form-group">
                    <a href="/login" class="ForgetPwd">Login</a>
                </div>
            </form>
        </div>
    </div>
</template>

<script>
export default {
    data() {
        return {
            email: "",
            password: "",
            confirmedPassword: "",
        };
    },
    computed: {
        passwordsMatch: function () {
            return this.password === this.confirmedPassword;
        },
    },
    methods: {
        submitRegisterForm: function () {
            let self = this;
            if (self.passwordsMatch === true) {
                this.$store
                    .dispatch("registerUser", {
                        email: self.email,
                        password: self.password,
                    })
                    .then((response) => {
                        if (response.status == 200) {
                            this.$router.push({ name: "login" });
                        } else {
                            alert(response);
                        }
                    })
                    .catch((err) => {
                        console.log(err);
                    });
            }
        },
    },
};
</script>

<style scoped>
.login-container {
    margin-top: 2.5%;
    margin-bottom: 2.5%;
}
.login-form-1 {
    padding: 1%;
    box-shadow: 0 5px 8px 0 rgba(0, 0, 0, 0.2), 0 9px 26px 0 rgba(0, 0, 0, 0.19);
}
.login-form-1 h3 {
    text-align: center;
    color: #333;
}
.login-container form {
    padding: 10%;
}
.btnSubmit {
    width: 50%;
    border-radius: 1rem;
    padding: 1.5%;
    border: none;
    cursor: pointer;
}
.login-form-1 .btnSubmit {
    font-weight: 600;
    color: #fff;
    background-color: #0062cc;
}
.login-form-1 .ForgetPwd {
    color: #0062cc;
    font-weight: 600;
    text-decoration: none;
}
</style>