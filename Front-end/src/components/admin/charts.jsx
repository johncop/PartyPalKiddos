import { Line } from "react-chartjs-2";
import { Bar } from "react-chartjs-2";
import { Pie } from "react-chartjs-2";
export const Charts = () => {
  const data = {
    labels: [
      "Mar 1",
      "Mar 2",
      "Mar 3",
      "Mar 4",
      "Mar 5",
      "Mar 6",
      "Mar 7",
      "Mar 8",
      "Mar 9",
      "Mar 10",
      "Mar 11",
      "Mar 12",
      "Mar 13",
    ],
    datasets: [
      {
        label: "Sessions",
        lineTension: 0.3,
        backgroundColor: "rgba(2,117,216,0.2)",
        borderColor: "rgba(2,117,216,1)",
        pointRadius: 5,
        pointBackgroundColor: "rgba(2,117,216,1)",
        pointBorderColor: "rgba(255,255,255,0.8)",
        pointHoverRadius: 5,
        pointHoverBackgroundColor: "rgba(2,117,216,1)",
        pointHitRadius: 50,
        pointBorderWidth: 2,
        data: [
          10000, 30162, 26263, 18394, 18287, 28682, 31274, 33259, 25849, 24159,
          32651, 31984, 38451,
        ],
      },
    ],
  };
  const dataBar = {
    labels: ["January", "February", "March", "April", "May", "June"],
    datasets: [
      {
        label: "Revenue",
        backgroundColor: "rgba(2,117,216,1)",
        borderColor: "rgba(2,117,216,1)",
        data: [4215, 5312, 6251, 7841, 9821, 14984],
      },
    ],
  };
  const dataPie = {
    labels: ["Blue", "Red", "Yellow", "Green"],
    datasets: [{
      data: [12.21, 15.58, 11.25, 8.32],
      backgroundColor: ['#007bff', '#dc3545', '#ffc107', '#28a745'],
    }],
  }
  return (
    <>
      <div class="container-fluid px-4">
        <h1 class="mt-4">Charts</h1>
        <ol class="breadcrumb mb-4">
          <li class="breadcrumb-item">
            <a href="index.html">Dashboard</a>
          </li>
          <li class="breadcrumb-item active">Charts</li>
        </ol>
        <div class="card mb-4">
          <div class="card-body">
            Chart.js is a third party plugin that is used to generate the charts
            in this template. The charts below have been customized - for
            further customization options, please visit the official
            <a target="_blank" href="https://www.chartjs.org/docs/latest/">
              Chart.js documentation
            </a>
            .
          </div>
        </div>
        <div class="card mb-4">
          <div class="card-header">
            <i class="fas fa-chart-area me-1"></i>
            Area Chart Example
          </div>
          <div class="card-body">
            <Line data={data} />
          </div>
          <div class="card-footer small text-muted">
            Updated yesterday at 11:59 PM
          </div>
        </div>
        <div class="row">
          <div class="col-lg-6">
            <div class="card mb-4">
              <div class="card-header">
                <i class="fas fa-chart-bar me-1"></i>
                Bar Chart Example
              </div>
              <div class="card-body">
                <Bar data={dataBar}/>
              </div>
              <div class="card-footer small text-muted">
                Updated yesterday at 11:59 PM
              </div>
            </div>
          </div>
          <div class="col-lg-6">
            <div class="card mb-4">
              <div class="card-header">
                <i class="fas fa-chart-pie me-1"></i>
                Pie Chart Example
              </div>
              <div class="card-body">
                <Pie data={dataPie}/>
              </div>
              <div class="card-footer small text-muted">
                Updated yesterday at 11:59 PM
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};
