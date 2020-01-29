function scoreToHTML(input) {
    let htmlData = ['<table>', '\t<tr><th>name</th><th>score</th></tr>', '</table>'];
    let data = JSON.parse(input);

    for (let i = 0; i < data.length; i++) {
        let str = `   <tr><td>${escapeHtml(data[i].name)}</td><td>${data[i].score}</td></tr>`;
        htmlData.splice(2 + i, 0, str);
    }
    console.log(htmlData.join('\n'));


    function escapeHtml(data) {
        return data.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;").replace(/"/g, "&quot;").replace(/'/g, "&#39;");
     }
}

scoreToHTML(['[{"name":"Pesho & Kiro","score":479},{"name":"Gosho, Maria & Viki","score":205}]']);