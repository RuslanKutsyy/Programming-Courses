function JSONtoHTMLtable(input) {
    let strArr = '<table>\n';
    let objects = JSON.parse(input);
    let keys = Object.keys(objects[0]);
    strArr += '   <tr>';
    
    for (let key in objects[0]) {
        strArr+= `<th>${key}</th>`;
    }
    strArr+=`</tr>\n`;

    for (let user of objects) {
        strArr += '   <tr>';
        let values = Object.values(user);
        values.forEach(element => {
            if (isNumber(element)) {
                strArr += `<td>${Number(element)}</td>`;
            } else {
                strArr += `\<td>${escapeHtml(element)}</td>`;
            }
        });
        strArr += '</tr>\n'
    }
    strArr += '</table>';
    console.log(strArr);

    function escapeHtml(data) {
        return data.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;").replace(/"/g, "&quot;").replace(/'/g, "&#39;");
    }

    function isNumber(param) {
        let num = Number(param);
        if (Number.isNaN(num)) {
            return false;
        }
        return true;
    }
}

JSONtoHTMLtable(['[{"Name":"Pesho <div>-a","Age":20,"City":"Sofia"},{"Name":"Gosho","Age":18,"City":"Plovdiv"},{"Name":"Angel","Age":18,"City":"Veliko Tarnovo"}]']);
/*
<table>
   <tr><th>Name</th><th>Age</th><th>City</th></tr>
   <tr><td>Pesho &lt;div&gt;-a</td><td>20</td><td>Sofia</td></tr>
   <tr><td>Gosho</td><td>18</td><td>Plovdiv</td></tr>
   <tr><td>Angel</td><td>18</td><td>Veliko Tarnovo</td></tr>
</table>
*/
