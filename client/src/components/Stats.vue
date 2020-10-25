<template>
    <div class="container login-container">
        <div class="login-form-1">
            <h2>Statistics</h2>
            <bar
                v-if="loadedDataNames"
                :chartdata="chartByName"
                :options="options"/>
            <bar
                v-if="loadedDataCategories"
                :chartdata="chartByCategory"
                :options="options"/>
            <!-- <b-tabs content-class="mt-3">
                <b-tab
                    v-for="stat in this.statisticsByName"
                    :title="stat.key"
                    :key="stat.value">
                    <p>{{stat}}</p>
                </b-tab>
            </b-tabs> -->
            <!-- <b-tabs content-class="mt-3">
                <b-tab
                    v-for="stat in this.statisticsByCategory"
                    :title="stat.key"
                    :key="stat.value">
                    <p>{{stat}}</p>
                </b-tab>
            </b-tabs> -->
        </div>
    </div>
</template>

<script>
import {Bar} from "vue-chartjs"

export default {
    components:{
        Bar
    },
    data: () => ({
        loadedDataNames: false,
        loadedDataCategories: false,
        statisticsByName: [],
        statisticsByCategory: [],
        chartByName: {
            labels: [],
            datasets: []
        },
        chartByCategory: {
            labels: [],
            datasets: []
        },
        options: {
            responsive: true,
            maintainAspectRatio: false
        }
    }),
    methods: {
        fetchStatisticsByProductNameData: function () {
            let self = this;
            return new Promise((resolve, reject)=>{
               this.$http
                .get("/api/Statistics/SpendingByProductName")
                .then((response) => {
                    self.statisticsByName = response.data;
                    resolve(response.data);
                })
                .catch((err) => {
                    console.log(err);
                    reject(err);
                }); 
            });
        },
        fetchStatisticsByProductCategoryData: function () {
            let self = this;
            return new Promise((resolve, reject)=>{
               this.$http
                .get("/api/Statistics/SpendingByProductCategory")
                .then((response) => {
                    self.statisticsByCategory = response.data;
                    resolve(response.data);
                })
                .catch((err) => {
                    console.log(err);
                    reject(err);
                }); 
            });
        },
        populateChartByNameData: function (){
            for (const stat of this.statisticsByName) {
                this.chartByName.labels.push(stat.key);
                this.chartByName.datasets.push({backgroundColor: '#000', data: stat.value})
            }
            console.log(this.statisticsByName)
            console.log(this.chartByName)
            this.loadedDataNames = true
        },
        populateChartByCategoryData: function (){
            for (const stat of this.statisticsByCategory) {
                this.chartByCategory.labels.push(stat.key);
                this.chartByCategory.datasets.push({backgroundColor: '#000', data: stat.value})
            }
            console.log(this.statisticsByName)
            console.log(this.chartByCategory)
            this.loadedDataCategories = true
        }
    },
    mounted: function () {
        this.loadedDataNames = false
        this.loadedDataCategories = false
        this.fetchStatisticsByProductNameData()
        .then(()=>{
            this.populateChartByNameData();
        });
        this.fetchStatisticsByProductCategoryData()
        .then(()=>{
            this.populateChartByCategoryData();
        });
    },
};
</script>