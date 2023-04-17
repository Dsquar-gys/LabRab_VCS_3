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
  const response = await fetch(`/api/${type}`, {
    method: "GET",
    headers: { "Accept": "application/json" }
  });
  if (response.ok === true) {
    const data = await response.json();
    
    switch (type) {
      case ('d'):
        D(data);
        break;
      case ('z'):
        Z(data);
        break;
      case ('m'):
        M(data);
        break;
      case ('V'):
        V(data);
        break;
    }
  }
  else {
    // если произошла ошибка, получаем сообщение об ошибке
    const error = await response.json();
    console.log(error.message); // и выводим его на консоль
  }
}

function D(data) {
  console.log(data)
  const doc = document.getElementById('graph')
  doc.innerHTML = ''
/*  const c1 = document.createElement('canvas')*/
  doc.innerHTML += '<canvas id="myChart1"></canvas>'
  doc.innerHTML += '<canvas id="myChart2" ></canvas>'
  
  const ctx1 = document.getElementById('myChart1');
  const chart1 = new Chart(ctx1, {type: 'line', data: {labels: [], datasets: [{label: '', borderWidth: 1, data: [],}]}, options: {scales: {y: {beginAtZero: true}}},});
  
  const ctx2 = document.getElementById('myChart2');
  const chart2 =  new Chart(ctx2, {
    type: 'line',
    data: {
      labels: [],
      datasets: [{
        label: '',
        data: [],
        borderWidth: 1,
        title: 'fas',
      }]
    },
    options: {
      scales: {
        y: {
          beginAtZero: true
        
        }
      },

    }
  });

  for (let i = 0; i < data.data.length; i++) {
    chart1.data.datasets[0].data[i] = data.data[i]
    chart2.data.datasets[0].data[i] = data.valueChanges[i]
  }
  
  chart1.data.labels = data.yearTable;
  chart2.data.labels = data.yearTable;
  
  chart1.update()
  chart2.update()

  table(data)
}

function table(data) {
  const grid = document.getElementById('output');
  grid.innerHTML = ''
  let div;
  for (let i in data) {
    div = document.createElement('div')
    let j;
    for (j of data[i]) {
      div.innerHTML += `<p>${j}</p>`
    }
    grid.append(div);
  }
  
}

function Z(data) {
  console.log(data)
  const doc = document.getElementById('graph')
  doc.innerHTML = ''
  /*  const c1 = document.createElement('canvas')*/
  doc.innerHTML += '<canvas id="myChart1"></canvas>'
  doc.innerHTML += '<canvas id="myChart2" ></canvas>'
  
  const ctx1 = document.getElementById('myChart1');
  const chart1 = new Chart(ctx1, {type: 'line', data: {labels: [], datasets: [{label: '', borderWidth: 1, data: [],}]}, options: {scales: {y: {beginAtZero: true}}},});
  
  const ctx2 = document.getElementById('myChart2');
  const chart2 =  new Chart(ctx2, {
    type: 'line',
    data: {
      labels: [],
      datasets: [{
        label: '',
        data: [],
        borderWidth: 1,
        title: 'fas',
      }]
    },
    options: {
      scales: {
        y: {
          beginAtZero: true
          
        }
      },
      
    }
  });
  
  for (let i = 0; i < data.data.length; i++) {
    chart1.data.datasets[0].data[i] = data.data[i]
    chart2.data.datasets[0].data[i] = data.percentChanges[i]
  }
  
  chart1.data.labels = data.years;
  chart2.data.labels = data.years;
  
  chart1.update()
  chart2.update()
  
  table(data)
}

function M(data) {
  const doc = document.getElementById('graph')
  doc.innerHTML = ''
  doc.innerHTML += '<canvas id="myChart1"></canvas>'
  
  const ctx1 = document.getElementById('myChart1');
  const chart1 = new Chart(ctx1, {
    type: 'line',
    data: {labels: [], datasets: [{label: '', borderWidth: 1, data: [[],[]],}]},
    options: {scales: {y: {beginAtZero: true}}},
  });
  
  
  for (let i = 0; i < data.Days.length; i++) {
    chart1.data.datasets[0].data[i] = data.Days[i].MaxSpeed
    chart1.data.datasets[1].data[i] = data.Days[i].Distance
    chart1.data.labels[i] = data.Days[i].Number;
  }
  
  
  
  chart1.update()
  
  table(data)
}

