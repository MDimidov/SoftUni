function attachEventsListeners() {
    const [input, btn, output] = Array.from(document.querySelectorAll("input"));
    const [inputUnit, outputUnit] = Array.from(document.querySelectorAll("select"));
    const convert = {
        'km': 1000,
        'm': 1,
        'cm': 0.01,
        'mm': 0.001,
        'mi': 1609.34,
        'yrd': 0.9144,
        'ft': 0.3048,
        'in': 0.0254
    }

    btn.addEventListener('click', () => {
        let inputDistance = Number(input.value);
        let inputUnits = inputUnit.value;
        let outputUnits = outputUnit.value;
        output.value = inputDistance * convert[inputUnits] / convert[outputUnits]
    })
}

// -----------------Method 2--------------------

function attachEventsListeners() {
    const [input, button, output] = document.querySelectorAll('input');
    const [inputUnits, outputUnits] = document.querySelectorAll('select');

    const convert = {
        'km': 1000,
        'm': 1,
        'cm': 0.01,
        'mm': 0.001,
        'mi': 1609.34,
        'yrd': 0.9144,
        'ft': 0.3048,
        'in': 0.0254
    };

    button.addEventListener('click', () => {
        const inputMeters = Number(input.value) * convert[inputUnits.value];
        output.value = Number(inputMeters / convert[outputUnits.value]);
    });
}