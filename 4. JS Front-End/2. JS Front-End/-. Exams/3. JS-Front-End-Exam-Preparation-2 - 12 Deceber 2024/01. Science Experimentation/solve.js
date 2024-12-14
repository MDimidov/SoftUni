function solve(inputArr) {
    const numChems = Number(inputArr.shift());
    const chemicalsArr = inputArr.splice(0, numChems);

    const chemicals = chemicalsArr.reduce((chems, curr) => {
        const [name, quantity] = curr.split(' # ');
        chems[name] = {
            name,
            quantity: Number(quantity)
        }

        return chems;
    }, {});

    while (inputArr[0] !== 'End') {
        const comandsArr = inputArr.shift().split(' # ');
        const command = comandsArr.shift();
        const chemName = comandsArr.shift();
        let amount;

        switch (command) {
            case 'Mix':
                const chemName2 = comandsArr.shift();
                amount = Number(comandsArr.shift());

                if (chemicals[chemName].quantity >= amount && chemicals[chemName2].quantity >= amount) {
                    chemicals[chemName].quantity -= amount;
                    chemicals[chemName2].quantity -= amount;

                    console.log(`${chemName} and ${chemName2} have been mixed. ${amount} units of each were used.`)
                } else {
                    console.log(`Insufficient quantity of ${chemName}/${chemName2} to mix.`);
                }
                break;

            case 'Replenish':
                amount = Number(comandsArr.shift());

                if (!chemicals[chemName]) {
                    console.log(`The Chemical ${chemName} is not available in the lab.`);
                    continue;
                } else if (chemicals[chemName].quantity + amount > 500) {
                    amount = 500 - chemicals[chemName].quantity;
                    console.log(`${chemName} quantity increased by ${amount} units, reaching maximum capacity of 500 units!`);
                } else {
                    console.log(`${chemName} quantity increased by ${amount} units!`)
                }

                chemicals[chemName].quantity += amount;
                break;

            case 'Add Formula':
                const formula = comandsArr.shift();

                if (chemicals[chemName]) {
                    const isItHasFormula = Boolean(chemicals[chemName].formula);
                    if(!isItHasFormula) chemicals[chemName].formula = [];
                    chemicals[chemName].formula.push(formula);
                    
                    console.log(`${chemName} has been assigned the formula ${formula}.`);
                } else {
                    console.log(`The Chemical ${chemName} is not available in the lab.`);
                }
                break;
        }
    }

    Object.keys(chemicals).forEach(key => {
        if (chemicals[key].formula) {
            console.log(`Chemical: ${key}, Quantity: ${chemicals[key].quantity}, Formula: ${chemicals[key].formula.join(', ')}`);
        } else {
            console.log(`Chemical: ${key}, Quantity: ${chemicals[key].quantity}`);
        }
    })
}

// solve(['4',
//   'Water # 200',
//   'Salt # 100',
//   'Acid # 50',
//   'Base # 80',
//   'Mix # Water # Salt # 50',
//   'Replenish # Salt # 150',
//   'Add Formula # Acid # H2SO4',
//   'End']);

  solve([ '3',
    'Sodium # 300',
    'Chlorine # 100',
    'Hydrogen # 200',
    'Mix # Sodium # Chlorine # 200',
    'Replenish # Sodium # 250',
    'Add Formula # Sulfuric Acid # H2SO4',
    'Add Formula # Sodium # Na',
    'Mix # Hydrogen # Chlorine # 50',
    'End']);