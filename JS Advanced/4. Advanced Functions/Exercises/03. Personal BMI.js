function analyzeBMI(name, age, weight, height) {
    var somePatient = new Patient(name, age, weight, height);

    somePatient = statusCheck(somePatient);

    return somePatient;


    function statusCheck(object) {
        let status;

        if (object.BMI < 18.5) {
            status = "underweight";
        } else if (object.BMI < 25){
            status = "normal";
        } else if (object.BMI < 30){
            status = "overweight";
        } else if (object.BMI >= 30){
            status = "obese";
        }

        object.status = status;
        object.BMI = Math.round(object.BMI);

        if (status === "obese") {
            object.recommendation = 'admission required';
        }

        return object;
    }

    function Patient(name, age, weight, height) {
        this.name = name;
        this.personalInfo = {
            'age' : age,
            'weight': weight,
            'height' : height
        }
        this.BMI = Math.round(weight / (height / 100) / (height / 100));

        return this;
    }
}

analyzeBMI("Honey Boo Boo", 9, 57, 137);