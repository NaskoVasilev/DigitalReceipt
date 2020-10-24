<template>
    <div class="hello">
        <h1>{{ msg }}</h1>
        <ul class="reader-wrapper">
            <qrcode-stream @decode="onDecode" class="reader"></qrcode-stream>
        </ul>
    </div>
</template>

<script>
export default {
    data() {
        return {
            msg: "Scan your customer's QR code",
        };
    },
    computed: {
        userId: function () {
            return this.$store.getters.userId;
        },
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
.reader-wrapper {
    margin-left: 20%;
    margin-right: 20%;
}
</style>