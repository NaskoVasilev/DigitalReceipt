<template>
    <div class="container login-container">
        <div class="login-form-1">
            <h2>Statistics</h2>
            <bar-chart
                v-if="loadedDataNames"
                :chartdata="chartByName"
                :options="options"
            />
            <bar-chart
                v-if="loadedDataCategories"
                :chartdata="chartByCategory"
                :options="options"
            />
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
// import BarChart from "./Chart";

export default {
    name: "Stats",
    components: {
        // BarChart,
    },
    data: () => ({
        loadedDataNames: false,
        loadedDataCategories: false,
        statisticsByName: [],
        statisticsByCategory: [],
        chartByName: {
            labels: [],
            datasets: [
                {
                    label: "Data by product name",
                    backgroundColor: "blue",
                    data: [],
                },
            ],
        },
        chartByCategory: {
            labels: [],
            datasets: [
                {
                    label: "Data by product category",
                    backgroundColor: "green",
                    data: [],
                },
            ],
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
        },
    }),
    methods: {
        fetchStatisticsByProductNameData: function () {
            let self = this;
            return new Promise((resolve, reject) => {
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
            return new Promise((resolve, reject) => {
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
        populateChartByNameData: function () {
            for (const stat of this.statisticsByName) {
                this.chartByName.labels.push(stat.key);
                this.chartByName.datasets[0].data.push(stat.value);
            }
            console.log(this.statisticsByName);
            console.log(this.chartByName);
            this.loadedDataNames = true;
        },
        populateChartByCategoryData: function () {
            for (const stat of this.statisticsByCategory) {
                this.chartByCategory.labels.push(stat.key);
                this.chartByCategory.datasets[0].data.push(stat.value);
                console.log("Hi");
                console.log(stat);
            }
            console.log(this.chartByCategory);
            this.loadedDataCategories = true;
        },
    },
    mounted: function () {
        // console.log(BarChart);
        this.loadedDataNames = false;
        this.loadedDataCategories = false;
        this.fetchStatisticsByProductNameData().then(() => {
            this.populateChartByNameData();
        });
        this.fetchStatisticsByProductCategoryData().then(() => {
            this.populateChartByCategoryData();
        });
    },
};
</script>