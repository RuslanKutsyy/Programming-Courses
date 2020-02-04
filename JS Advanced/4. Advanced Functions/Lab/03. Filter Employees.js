function filterEmployees(data, criteria) {
    let employees = JSON.parse(data);
    let criteriaData = criteria.split('-');
    let criteriaName = criteriaData[0];
    let criteriaValue = criteriaData[1];
    let arr = Array.from(employees.filter(employee => employee[criteriaName] === criteriaValue));

    for (let i = 0; i < arr.length; i++) {
        console.log(`${i}. ${arr[i].first_name} ${arr[i].last_name} - ${arr[i].email}`);
    }
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
 'last_name-Johnson'
);