function attachEventsListeners() {
    const daysBtn = document.querySelector("#daysBtn");
    const daysInput = document.querySelector("#days");
    const hoursBtn = document.querySelector("#hoursBtn");
    const hoursInput = document.querySelector("#hours");
    const minutesBtn = document.querySelector("#minutesBtn");
    const minutesInput = document.querySelector("#minutes");
    const secondsBtn = document.querySelector("#secondsBtn");
    const secondsInput = document.querySelector("#seconds");

    daysBtn.addEventListener("click", convertFromDays);
    hoursBtn.addEventListener("click", convertFromHours);
    minutesBtn.addEventListener("click", convertFromMinutes);
    secondsBtn.addEventListener("click", convertFromSeconds);

    function convertFromDays() {
        hoursInput.value = daysInput.value * 24;
        minutesInput.value = hoursInput.value * 60;
        secondsInput.value = minutesInput.value * 60;
    }

    function convertFromHours() {
        daysInput.value = hoursInput.value / 24;
        minutesInput.value = hoursInput.value * 60;
        secondsInput.value = minutesInput.value * 60;
    }

    function convertFromMinutes() {
        hoursInput.value = minutesInput.value / 60;
        daysInput.value = hoursInput.value / 24;
        secondsInput.value = minutesInput.value * 60;
    }

    function convertFromSeconds() {
        minutesInput.value = secondsInput.value / 60;
        hoursInput.value = minutesInput.value / 60;
        daysInput.value = hoursInput.value / 24;
    }

}