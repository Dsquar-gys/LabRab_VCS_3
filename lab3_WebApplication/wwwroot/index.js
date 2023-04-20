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
      case ('v'):
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

  table_1(data)
}

function table_1(data) {
  const grid = document.getElementById('output');
  grid.style.gridTemplateColumns = "repeat(3, 1fr)"
  grid.innerHTML = ''
  let div;
  for (let i in data) {
    div = document.createElement('div')
    
      div.innerHTML += `<p>${i}</p>`
    
    grid.append(div);
  }
  for (let i in data) {
    div = document.createElement('div')
    let j;
    for (j of data[i]) {
      div.innerHTML += `<p>${j}</p>`
    }
    grid.append(div);
  }
  const elem = document.getElementById('element')
  elem.parentNode.removeChild(elem);
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
  
  table_1(data)
}

function M(data) {
  console.log(data)
  const doc = document.getElementById('graph')
  doc.innerHTML = ''
  doc.innerHTML += '<canvas id="myChart1"></canvas>'
  
  const ctx1 = document.getElementById('myChart1');
  const chart1 = new Chart(ctx1, {
    type: 'line',
    data: {labels: [], datasets: [{label: '', borderWidth: 1, data: [[]],},{label: '', borderWidth: 1, data: [[]],}]},
    options: {scales: {y: {beginAtZero: true}}},
  });
  
  for (let i = 0; i < data.days.length; i++) {
    chart1.data.datasets[0].data[i] = data.days[i].distance
    chart1.data.datasets[1].data[i] = data.days[i].minutes
    chart1.data.labels[i] = data.days[i].number;
  }

  chart1.update()
  
  const grid = document.getElementById('output');
  
  grid.style.gridTemplateColumns = "repeat(9, 1fr)"
  
  grid.innerHTML = ''
  let div;
  
  let j;
  let i;
  
  for (i in data.days[0])
    grid.innerHTML += `<p>${i}</p>`
  
  for (let h = 0; h < data.days.length; h++) {
    for (i in data.days[h]) {
      j= data.days[h]
      grid.innerHTML += `<p>${(isFinite(j[i])) ? j[i].toFixed(1) : j[i]}</p>`
    }
  }
  
  const element = document.createElement('div')
  element.id = 'element'
  element.innerText = data.sum
  document.getElementById('container').append(element)
}

function V(data) {
  const doc = document.getElementById('graph')
  doc.innerHTML = ''
  doc.innerHTML += '<canvas id="myChart1"></canvas>'
  console.log(data)
  const ctx1 = document.getElementById('myChart1');
  const chart1 = new Chart(ctx1, {
    type: 'line',
    data: {labels: [], datasets: [
      {label: '', borderWidth: 1, data: [[]],},
        {label: '', borderWidth: 1, data: [[]],},
        {label: '', borderWidth: 1, data: [[]],}
      ]},
    options: {scales: {y: {beginAtZero: true}}},
  });
  
  
  for (let i = 0; i < data.days.length; i++) {
    chart1.data.datasets[0].data[i] = data.days[i].max
    chart1.data.datasets[1].data[i] = data.days[i].min
    chart1.data.datasets[2].data[i] = data.days[i].average
    chart1.data.labels[i] = data.days[i].number;
  }
  
  
  
  chart1.update()
  
  const grid = document.getElementById('output');
  
  grid.style.gridTemplateColumns = "repeat(4, 1fr)"
  
  grid.innerHTML = ''
  let div;
  
  let j;
  let i;
  
  for (i in data.days[0])
    grid.innerHTML += `<p>${i}</p>`
  
  for (let h = 0; h < data.days.length; h++) {
    for (i in data.days[h]) {
      j= data.days[h]
      grid.innerHTML += `<p>${(isFinite(j[i])) ? j[i].toFixed(1) : j[i]}</p>`
    }
  }
  const element = document.createElement('div')
  element.id = 'element'
  element.innerText = `${data.indexDay}: ${data.maxValue}`
  document.getElementById('container').append(element)
}


