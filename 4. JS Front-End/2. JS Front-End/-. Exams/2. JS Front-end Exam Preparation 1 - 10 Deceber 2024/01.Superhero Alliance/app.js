function solve(inputArr) {
    const numHeroes = Number(inputArr.shift());
    const heroesArr = inputArr.splice(0, numHeroes);

    const heroes = heroesArr.reduce((heroes, hero) => {
        let [name, powers, energy] = hero.split('-');
        powers = powers.split(',');
        energy = Number(energy);
        
        heroes[name] = {powers, energy};
        return heroes;
    }, {});

    for (let entry of inputArr) {
        if (entry === 'Evil Defeated!') break;

        entry = entry.split(' * ');
        const command = entry.shift();
        const heroName = entry.shift()
        
        switch (command) {
            case 'Use Power':
                const power = entry.shift();
                let energy = Number(entry.shift());

                if (heroes[heroName].powers.includes(power) && heroes[heroName].energy >= energy) {
                    heroes[heroName].energy -= energy;
                    console.log(`${heroName} has used ${power} and now has ${heroes[heroName].energy} energy!`);
                } else {
                    console.log(`${heroName} is unable to use ${power} or lacks energy!`)
                }
                break;
        
            case 'Train':
                let gainedEnergy = Number(entry.shift());

                if (heroes[heroName].energy === 100){
                    console.log(`${heroName} is already at full energy!`);
                    continue;
                } else if (heroes[heroName].energy + gainedEnergy > 100) {
                    gainedEnergy = 100 - heroes[heroName].energy;                    
                } 

                heroes[heroName].energy += gainedEnergy;
                console.log(`${heroName} has trained and gained ${gainedEnergy} energy!`);
                break;
            case 'Learn':
                let superpower = entry.shift();

                if (heroes[heroName].powers.includes(superpower)){
                    console.log(`${heroName} already knows ${superpower}.`);
                    continue;
                } else {
                    heroes[heroName].powers.push(superpower);      
                    console.log(`${heroName} has learned ${superpower}!`);
                } 
                break;
        }
    }

    let result = '';
    for (const name of Object.keys(heroes)) {
        result += `Superhero: ${name}\n`;
        result += `- Superpowers: ${heroes[name].powers.join(', ')}\n`;
        result += `- Energy: ${heroes[name].energy}\n`;
    }

    console.log(result);
}

solve([
    "3",
    "Iron Man-Repulsor Beams,Flight-80",
    "Thor-Lightning Strike,Hammer Throw-10",
    "Hulk-Super Strength-60",
    "Use Power * Iron Man * Flight * 30",
    "Train * Thor * 20",
    "Train * Hulk * 50",
    "Learn * Hulk * Thunderclap",
    "Use Power * Hulk * Thunderclap * 70",
    "Evil Defeated!"
]);