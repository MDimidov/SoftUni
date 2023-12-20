function operateWithAstronauts(inputArr) {
    const astronautsCount = Number(inputArr.shift());
    const totalAstronauts = [];

    const commands = {
        "Explore": (astronaut, energyNeeded) => {
            if (astronaut && astronaut.energy >= energyNeeded) {
                astronaut.energy -= energyNeeded;
                console.log(`${astronaut.name} has successfully explored a new area and now has ${astronaut.energy} energy!`)
            }
            else if (astronaut) {
                console.log(`${astronaut.name} does not have enough energy to explore!`)
            }
        },

        "Refuel": (astronaut, amount) => {
            const refuelEnergy = Math.min(amount, 200 - astronaut.energy);
            astronaut.energy += refuelEnergy;
            console.log(`${astronaut.name} refueled their energy by ${refuelEnergy}!`)
        },

        "Breathe": (astronaut, amount) => {
            const refuelOxygen = Math.min(amount, 100 - astronaut.oxygen);
            astronaut.oxygen += refuelOxygen;
            console.log(`${astronaut.name} took a breath and recovered ${refuelOxygen} oxygen!`)
        },
    }

    for (let i = 0; i < astronautsCount; i++) {
        const [name, oxygen, energy] = inputArr.shift().split(" ");
        const astronaut = {
            name,
            oxygen: Number(oxygen),
            energy: Number(energy),
        }

        totalAstronauts.push(astronaut);
    }

    while (inputArr[0] != 'End') {
        let [command, name, value] = inputArr.shift().split(' - ');
        const astronaut = totalAstronauts.find(a => a.name === name);
        value = Number(value);
        commands[command](astronaut, value);
    }

    for (const astronaut of totalAstronauts) {
        console.log(`Astronaut: ${astronaut.name}, Oxygen: ${astronaut.oxygen}, Energy: ${astronaut.energy}`)
    }
}

operateWithAstronauts(['3',
    'John 50 120',
    'Kate 80 180',
    'Rob 70 150',
    'Explore - John - 50',
    'Refuel - Kate - 30',
    'Breathe - Rob - 20',
    'End']
)