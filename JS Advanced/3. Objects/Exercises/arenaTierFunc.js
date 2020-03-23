function arenaTierFunc(input) {
    let arena = new Map();

    for (let text of input) {
        if (text !== 'Ave Cesar') {
            let commandData = text.split(' -> ');

            if (commandData.length === 1) {
                let data = text.split(' vs ');
                let firstName = data[0];
                let secondName = data[1];
                if (arena.has(firstName) && arena.has(secondName)) {
                    
                    for (let skill of Array.from(arena.get(firstName).keys())) {
                        for (let secondGladSkill of Array.from(arena.get(secondName).keys())) {
                            if (skill === secondGladSkill) {
                                compareGladiators(firstName, secondName) ? arena.delete(secondName) : arena.delete(firstName);
                                break;
                            }
                        }
                    }
                }

            }   else {
                let gladiator = commandData[0];
                let technique = commandData[1];
                let skill = Number(commandData[2]);

                if (!arena.has(gladiator)) {
                arena.set(gladiator, new Map());
                }

                if (!arena.get(gladiator).has(technique)) {
                arena.get(gladiator).set(technique, 0);
                }

                if (arena.get(gladiator).get(technique) < skill) {
                arena.get(gladiator).set(technique, skill);
                }
            }
            
        }        
    }
    
    let orderedArena = Array.from(arena.keys()).sort((a, b) => sorting(a, b));

    printData();

    function compareGladiators(firstName, secondName) {
        let firstGladSum = Array.from(arena.get(firstName).values()).reduce((sum, currentValue) => sum + currentValue);
        let secondGladSum = Array.from(arena.get(secondName).values()).reduce((sum, currentValue) => sum + currentValue);

        return firstGladSum > secondGladSum ? true : false;
    }

    function sorting(a, b) {
        let skillSumA = Array.from(arena.get(a).values()).reduce((sum, currentValue) => sum + currentValue);
        let skillSumB = Array.from(arena.get(b).values()).reduce((sum, currentValue) => sum + currentValue);
        
        if (skillSumA !== skillSumB) {
            return skillSumB - skillSumA;
        } else {
            return a.localeCompare(b);
        }
    }

    function printData() {
        for (let key of orderedArena) {
            let totalSkill = Array.from(arena.get(key).values()).reduce((sum, currentValue) => sum + currentValue);
            console.log(`${key}: ${totalSkill} skill`);
            for (let [technique, skill] of arena.get(key)) {
                console.log(`- ${technique} <!> ${skill}`);
            }
        }
    }
}

arenaTierFunc(['Pesho -> Duck -> 400',
    'Julius -> Shield -> 150',
    'Gladius -> Heal -> 200',
    'Gladius -> Support -> 250',
    'Gladius -> Shield -> 250',
    'Pesho vs Gladius',
    'Gladius vs Julius',
    'Gladius vs Gosho',
    'Ave Cesar']
    );