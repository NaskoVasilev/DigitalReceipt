<template>
    <div class="hello">
        <h1>{{ msg }}</h1>
        <ul>
            <qrcode :width="600" :value="userId"></qrcode>
        </ul>
    </div>
</template>

<script>
export default {
    name: "HelloWorld",
    computed: {
        userId: function () {
            return this.$store.getters.userId;
        },
    },
    data() {
        return {
            msg: "Show this to your cashier",
        };
    },
    methods: {
        logOut: function () {
            this.$store.dispatch("destroyToken");
            this.$router.push({ name: "login" });
        },
        onDecode: function (decodedString) {
            alert(decodedString);
        },
    },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
    margin: 40px 0 0;
}
ul {
    list-style-type: none;
    padding: 0;
}
li {
    display: inline-block;
    margin: 0 10px;
}
a {
    color: #42b983;
}
.reader {
    width: 200px;
    height: 200px;
}
</style>
