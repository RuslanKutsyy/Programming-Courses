function storeJuiceBottles(params) {
    let quantities = {};
    let bottles = {};

    for (let i = 0; i < params.length; i++) {
        let juiceData = params[i].split(" => ");
        let juice = juiceData[0];
        let quantity = Number(juiceData[1]);

        if (!quantities.hasOwnProperty(juice)) {
            quantities[juice] = 0;
        }

        quantities[juice] += quantity;

        if (quantities[juice]>=1000) {
            bottles[juice] = parseInt(quantities[juice]/1000);
        }
    }

    for (let key in bottles) {
        console.log(`${key} => ${bottles[key]}`);
    }
}

storeJuiceBottles(['Kiwi => 234',
'Pear => 2345',
'Watermelon => 3456',
'Kiwi => 4567',
'Pear => 5678',
'Watermelon => 6789']);