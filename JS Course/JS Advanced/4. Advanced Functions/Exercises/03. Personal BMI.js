function analyzePersonalBMI(name, age, weight, height) {
    let person = {
        name: name,
        personalInfo: {
            age: age,
            weight: weight,
            height: height
        },
        BMI: weight / Math.pow(height / 100, 2),
        status: ''
    }

    if (person.BMI < 18.5) {
        person.status = 'underweight';
    } else if (person.BMI >= 18.5 && person.BMI < 25){
        person.status = 'normal';
    } else if (person.BMI >= 25 && person.BMI < 30) {
        person.status = 'overweight';
    } else if (person.BMI >= 30) {
        person.status = 'obese';
        person.recommendation = 'admission required';
    }
    person.BMI = Number(person.BMI.toFixed());

    return person;
}

console.log(analyzePersonalBMI("Honey Boo Boo", 9, 57, 137));