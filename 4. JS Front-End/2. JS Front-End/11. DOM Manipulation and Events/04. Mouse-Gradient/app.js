function attachGradientEvents() {
    const box = document.querySelector("#gradient");
    const result = document.querySelector("#result");

    box.addEventListener('mousemove', gradientMove);
    box.addEventListener('mouseout', gradientOut);

    function gradientMove(e) {
        let power = e.offsetX / (e.target.clientWidth - 1);
        power = Math.trunc(power * 100);
        result.textContent = power + "%";
    }

    function gradientOut(e) {
        result.textContent = "";
    }
}