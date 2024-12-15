function solve(inputArr) {
    const num = Number(inputArr.shift());
    const farmersArr = inputArr.splice(0, num);

    const farmers = farmersArr.reduce((acc, curr) => {
        let [name, workArea, tasks] = curr.split(' ');
        tasks = tasks.split(',');

        acc[name] = {
            name,
            workArea,
            tasks
        };

        return acc;
    }, {});

    while (inputArr[0] !== 'End') {
        const commandLine = inputArr.shift().split(' / ');
        const command = commandLine.shift();
        const farmerName = commandLine.shift();

        switch (command) {
            case 'Execute':
                let workArea = commandLine.shift();
                let task = commandLine.shift();

                if (farmers[farmerName].workArea === workArea && 
                    farmers[farmerName].tasks.includes(task)) {
                    console.log(`${farmerName} has executed the task: ${task}!`);
                } else {
                    console.log(`${farmerName} cannot execute the task: ${task}.`);
                }
                break;
        
            case 'Change Area':
                let newWorkArea = commandLine.shift();
                farmers[farmerName].workArea = newWorkArea;
                
                console.log(`${farmerName} has changed their work area to: ${newWorkArea}`);
                break;
            case 'Learn Task':
                let newTask = commandLine.shift();

                if (farmers[farmerName].tasks.includes(newTask)) {
                    console.log(`${farmerName} already knows how to perform ${newTask}!`);
                } else {
                    farmers[farmerName].tasks.push(newTask);
                    console.log(`${farmerName} has learned a new task: ${newTask}.`);
                }
                break;
        }
    }

    Object.keys(farmers).forEach(key => {
        console.log(`Farmer: ${farmers[key].name}, Area: ${farmers[key].workArea}, Tasks: ${farmers[key].tasks.sort().join(', ')}`)
    })
}

// solve([
//     "2",
//     "John garden watering,weeding",
//     "Mary barn feeding,cleaning",
//     "Execute / John / garden / watering",
//     "Execute / Mary / garden / feeding",
//     "Learn Task / John / planting",
//     "Execute / John / garden / planting",
//     "Change Area / Mary / garden",
//     "Execute / Mary / garden / cleaning",
//     "End"
//   ]);

solve([
    "3",
    "Alex apiary harvesting,honeycomb",
    "Emma barn milking,cleaning",
    "Chris garden planting,weeding",
    "Execute / Alex / apiary / harvesting",
    "Learn Task / Alex / beeswax",
    "Execute / Alex / apiary / beeswax",
    "Change Area / Emma / apiary",
    "Execute / Emma / apiary / milking",
    "Execute / Chris / garden / watering",
    "Learn Task / Chris / pruning",
    "Execute / Chris / garden / pruning",
    "End"
  ]);