document.addEventListener("DOMContentLoaded", function () {
    var ctx = document.getElementById("lineChart").getContext("2d");
    var chart = new Chart(ctx, {
        type: "line",
        data: {
            labels: ["2013", "2014", "2015", "2016", "2017"],
            datasets: [{
                label: "Growth",
                data: [10, 19, 3, 5, 2],
                borderColor: "rgba(75, 192, 192, 1)",
                backgroundColor: "rgba(75, 192, 192, 0.2)",
                tension: 0.4,
                borderWidth: 2,
                fill: true
            }]
        },
        options: {
            responsive: true,
            plugins: {
                legend: { display: true }
            },
            scales: {
                y: { beginAtZero: true },
                x: { ticks: { color: "black" } }
            }
        }
    });
});
