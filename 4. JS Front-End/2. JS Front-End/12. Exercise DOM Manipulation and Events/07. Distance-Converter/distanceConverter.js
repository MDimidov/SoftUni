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