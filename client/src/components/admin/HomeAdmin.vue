<template>
    <div class="hello">
        <h1>{{ msg }}</h1>
        <b-alert
            class="mx-3"
            :show="dismissCountDown"
            @dismissed="onDismissed"
            @dismiss-count-down="this.countDownChanged"
            variant="success"
            v-if="this.alert != null && isBad === false"
        >
            {{ this.alert }}
        </b-alert>
        <b-alert
            class="mx-3"
            :show="dismissCountDown"
            @dismissed="onDismissed"
            @dismiss-count-down="this.countDownChanged"
            variant="warning"
            v-if="this.alert != null && isBad === true"
        >
            {{ this.alert }}
        </b-alert>
        <ul class="reader-wrapper">
            <qrcode-stream @decode="onDecode" class="reader"></qrcode-stream>
        </ul>
    </div>
</template>

<script>
export default {
    data() {
        return {
            dismissSecs: 0,
            dismissCountDown: 0,
            isBad: false,
            alert: null,
            msg: "Scan your customer's QR code",
        };
    },
    computed: {
        userId: function () {
            return this.$store.getters.userId;
        },
    },
    methods: {
        onDismissed: function () {
            this.dismissCountDown = 0;
            this.alert = null;
        },
        countDownChanged(dismissCountDown) {
            this.dismissCountDown = dismissCountDown;
            if (this.dismissCountDown === 0) this.dismissCountDown = 5;
        },
        showAlert() {
            this.dismissCountDown = this.dismissSecs;
        },
        logOut: function () {
            this.$store.dispatch("destroyToken");
            this.$router.push({ name: "login" });
        },
        onDecode: function (decodedString) {
            if (this.isGuid(decodedString) === true) {
                this.$http
                    .post("/api/Receipts", {
                        date: "2020-10-25T00:00:00",
                        cashierName: "QR Test Cashier",
                        number: this.getRandomInt(1000, 9999).toString(),
                        fiscalNumber:
                            "BMLF" + this.getRandomInt(1000, 9999).toString(),
                        uic: this.getRandomInt(1000000, 9999999).toString(),
                        companyAddress: "Test Address",
                        storeName: "Test Store",
                        storeAddress: "Test Address 2",
                        companyName: "QR Test Company",
                        taxNumber:
                            "BG" + this.getRandomInt(100000, 999999).toString(),
                        clientNumber: this.getRandomInt(
                            1000000,
                            9999999
                        ).toString(),
                        idFiscalNumber:
                            "BML" + this.getRandomInt(1000, 9999).toString(),
                        userId: decodedString,
                        products: [
                            {
                                name: "Organic Face Mask",
                                barcode: "26394528",
                                price: 5.5,
                                discount: 0.0,
                                category: 2,
                                quantity: 1,
                            },
                        ],
                    })
                    .then(() => {
                        this.alert = "Success!";
                        this.isBad = false;
                        this.dismissCountDown = 4;
                    })
                    .catch(() => {
                        this.alert = "Invalid User";
                        this.isBad = true;
                        this.dismissCountDown = 4;
                    });
            } else {
                this.alert = "Invalid Client QR code";
                this.isBad = true;
                this.dismissCountDown = 4;
            }
        },
        isGuid: function (value) {
            var regex = /^[a-f0-9]{8}(?:-[a-f0-9]{4}){3}-[a-f0-9]{12}$/i;
            var match = regex.exec(value);
            return match != null;
        },
        getRandomInt: function (min, max) {
            min = Math.ceil(min);
            max = Math.floor(max);
            return Math.floor(Math.random() * (max - min) + min); //The maximum is exclusive and the minimum is inclusive
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