function extractUniqueWords(input) {
    let arr = [];

    for (let i = 0; i < input.length; i++) {
        let part = input[i].split(/\W+/).filter(item => item);

        for (let j = 0; j < part.length; j++) {
            if (!arr.includes(part[j].toLowerCase())) {
                arr.push(part[j].toLowerCase());
            }
        }
    }

    console.log(arr.join(", "));
}

extractUniqueWords(['Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Pellentesque quis hendrerit dui.', 
'Quisque fringilla est urna, vitae efficitur urna vestibulum fringilla.', 
'Vestibulum dolor diam, dignissim quis varius non, fermentum non felis.', 
'Vestibulum ultrices ex massa, sit amet faucibus nunc aliquam ut.', 
'Morbi in ipsum varius, pharetra diam vel, mattis arcu.', 
'Integer ac turpis commodo, varius nulla sed, elementum lectus.', 
'Vivamus turpis dui, malesuada ac turpis dapibus, congue egestas metus.']);