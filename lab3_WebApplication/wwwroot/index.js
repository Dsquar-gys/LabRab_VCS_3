
const ctx = document.getElementById('myChart');

new Chart(ctx, {
  type: 'line',
  data: {
    labels: ['2008', '2009', '2010','2011', '2012', '2013', '2014', '2015', '2016','2017', '2018', '2019', '2020', '2021', '2022'],
    datasets: [{
      label: 'Статистика за последние 15 лет',
      data: [12, 19, 3, 5, 2, 3],
      borderWidth: 1,
      
      
    }]
  },
  options: {
    scales: {
      y: {
        beginAtZero: true
        
      }
    }
  }
});

document.getElementById('dmitrichenko').addEventListener('click', () => {
  getDmitrichenko();
})

async function getDmitrichenko() {
  const response = await fetch(`/api/dmitrichenko`, {
    method: "GET",
    headers: { "Accept": "application/json" }
  });
  if (response.ok === true) {
    const data = await response.json();
    
  }
  else {
    // если произошла ошибка, получаем сообщение об ошибке
    const error = await response.json();
    console.log(error.message); // и выводим его на консоль
  }
}