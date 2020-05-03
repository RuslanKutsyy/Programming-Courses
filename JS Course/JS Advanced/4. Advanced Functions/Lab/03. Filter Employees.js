function filterEmployees(data, criteriaAsText) {
  let employeeArr = JSON.parse(data);
  let criteria = criteriaAsText.split('-')[0];
  let filteredData = [];
  if (criteria === 'all') {
    filteredData = employeeArr;
  } else {
    let criteriaValue = criteriaAsText.split('-')[1];
    filteredData = employeeArr.filter(obj => obj[criteria] === criteriaValue);
  }

  return filteredData.forEach(el => console.log(`${filteredData.indexOf(el)}. ${el.first_name} ${el.last_name} - ${el.email}`));
}

filterEmployees(`[{
  "id": "1",
  "first_name": "Kaylee",
  "last_name": "Johnson",
  "email": "k0@cnn.com",
  "gender": "Female"
}, {
  "id": "2",
  "first_name": "Kizzee",
  "last_name": "Johnson",
  "email": "kjost1@forbes.com",
  "gender": "Female"
}, {
  "id": "3",
  "first_name": "Evanne",
  "last_name": "Maldin",
  "email": "emaldin2@hostgator.com",
  "gender": "Male"
}, {
  "id": "4",
  "first_name": "Evanne",
  "last_name": "Johnson",
  "email": "ev2@hostgator.com",
  "gender": "Male"
}]`,
'all'
);