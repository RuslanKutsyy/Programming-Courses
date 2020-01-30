function parseDatafFromJSON(input) {
    let stringToPrint = "<table>\n";
    
    for (let i = 0; i < input.length; i++) {
        stringToPrint +='\t<tr>\n';
        let employeeData = JSON.parse(input[i]);

        stringToPrint+= `\t\t<td>${employeeData.name}</td>\n` + `\t\t<td>${employeeData.position}</td>\n`
        + `\t\t<td>${employeeData.salary}</td>\n` + '\t</tr>\n';
    }

    stringToPrint+= '</table>';

    console.log(stringToPrint);
}

parseDatafFromJSON(['{"name":"Pesho","position":"Promenliva","salary":100000}',
'{"name":"Teo","position":"Lecturer","salary":1000}',
'{"name":"Georgi","position":"Lecturer","salary":1000}']
);