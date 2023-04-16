
const ctx = document.getElementById('myChart');

const chart = new Chart(ctx, {
  type: 'line',
  data: {
    labels: [],
    datasets: [{
      label: 'Статистика за последние 15 лет',
      borderWidth: 1,
      data: [],
    }]
  },
  options: {
    scales: {
      y: {
        beginAtZero: true
      }
    },
    responsive: true
  }
});

document.getElementById('dmitrichenko').addEventListener('click', () => {
  get('d');
})

document.getElementById('zhukovsky').addEventListener('click', () => {
  get('z');
})

document.getElementById('miagkov').addEventListener('click', () => {
  get('m');
})

document.getElementById('voronov').addEventListener('click', () => {
  get('v');
})


async function get(type) {
  const response = await fetch(`/api/dmitrichenko`, {
    method: "GET",
    headers: { "Accept": "application/json" }
  });
  if (response.ok === true) {
    const data = await response.json();
    
    switch (type) {
      case ('d'):
        D(data);
        break;
    }

    chart.update()
  }
  else {
    // если произошла ошибка, получаем сообщение об ошибке
    const error = await response.json();
    console.log(error.message); // и выводим его на консоль
  }
}

function D(data) {
  chart.data.datasets.push({
    borderWidth: 1,
    data: [],
  })
  for (let i = 0; i < data.data.length; i++) {
    chart.data.datasets[0].data[i] = data.data[i]
    chart.data.datasets[1].data[i] = data.valueChanges[i]
  }
  
  chart.data.labels = data.yearTable;
}

/*function Z(data) {
  for (let i = 0; i < data.data.length; i++) {
    chart.data.datasets[0].data[i] = data.data[i]
  }
  console.log(data);
  for (let i = 0; i < data.valueChanges.length; i++) {
    chart.data.datasets[0].data[i] = data.valueChanges[i]
  }
  chart.data.labels = data.yearTable;*/

