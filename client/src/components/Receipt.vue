<template>
    <div class="container login-container">
        <div class="login-form-1">
            <h2>Receipts</h2>
            <b-tabs content-class="mt-3">
                <b-tab
                    v-for="firm in this.firmsWithReceipts"
                    :title="firm.companyName"
                    :key="firm.companyName"
                    active
                >
                    <b-tabs content-class="mt-3">
                        <b-tab
                            v-for="(receipt, index) in firm.receipts"
                            :title="receipt.fiscalNumber"
                            :key="
                                receipt.fiscalNumber + firm.companyName + index
                            "
                            active
                            :title-link-class="'receipts-tab'"
                        >
                            <p>Date: {{ receipt.date | formatDate }}</p>
                            <p>Cashier name: {{ receipt.cashierName }}</p>
                            <p>Number: {{ receipt.number }}</p>
                            <p>Fiscal number: {{ receipt.fiscalNumber }}</p>
                            <p>UIC: {{ receipt.uic }}</p>
                            <p>Company address: {{ receipt.companyAddress }}</p>
                            <p>Store name: {{ receipt.storeName }}</p>
                            <p>Store address: {{ receipt.storeAddress }}</p>
                            <p>Company name: {{ receipt.companyName }}</p>
                            <p>Tax number: {{ receipt.taxNumber }}</p>
                            <p>Client number: {{ receipt.clientNumber }}</p>
                            <p>
                                ID fiscal Number: {{ receipt.idFiscalNumber }}
                            </p>
                        </b-tab>
                    </b-tabs>
                </b-tab>
            </b-tabs>
        </div>
    </div>
</template>

<script>
export default {
    data() {
        return {
            firmsWithReceipts: [],
        };
    },
    methods: {
        fetchReceipts: function () {
            let self = this;
            this.$http
                .get("/api/Receipts")
                .then((response) => {
                    self.firmsWithReceipts = response.data;
                })
                .catch((err) => {
                    console.log(err);
                });
        },
    },
    mounted: function () {
        this.fetchReceipts();
    },
};
</script>

<style scoped>
.login-container {
    margin-top: 5%;
    margin-bottom: 5%;
}
.login-form-1 {
    padding: 5%;
    box-shadow: 0 5px 8px 0 rgba(0, 0, 0, 0.2), 0 9px 26px 0 rgba(0, 0, 0, 0.19);
}
.login-form-1 h3 {
    text-align: center;
    color: #333;
}
.login-container form {
    padding: 10%;
}
.btnSubmit,
.btnRegister {
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
.login-form-1 .btnRegister {
    font-weight: 600;
    color: #fff;
    background-color: #b2b2b2;
}
.login-form-1 .ForgetPwd {
    color: #0062cc;
    font-weight: 600;
    text-decoration: none;
}
</style>