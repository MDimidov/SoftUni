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

// -----------------Method 2--------------------

function attachEventsListeners() {

    
    const selectedBtn = {
        elements: ['days', 'hours', 'minutes', 'seconds'],
    };

    const daysInput = document.querySelector(`#${selectedBtn.elements[0]}`);
    const hoursInput = document.querySelector(`#${selectedBtn.elements[1]}`);
    const minutesInput = document.querySelector(`#${selectedBtn.elements[2]}`);
    const secondsInput = document.querySelector(`#${selectedBtn.elements[3]}`);

   for (const element of selectedBtn.elements) {
    const inputNum = document.querySelector(`#${element}`);
    const btn = document.querySelector(`#${element}Btn`);

    btn.addEventListener('click', () => {
            switch (element) {
                case selectedBtn.elements[0]:
                    hoursInput.value = inputNum.value * 24;
                    minutesInput.value = inputNum.value * 60 * 24;
                    secondsInput.value = inputNum.value * 60 * 60 *24;
                    break;

                case selectedBtn.elements[1]:
                    daysInput.value = inputNum.value / 24;
                    minutesInput.value = inputNum.value * 60;
                    secondsInput.value = minutesInput.value * 60;
                    break;

                case selectedBtn.elements[2]:
                    hoursInput.value = inputNum.value / 60;
                    daysInput.value = hoursInput.value / 24;
                    secondsInput.value = inputNum.value * 60;
                    break;
            
                case selectedBtn.elements[3]:
                    minutesInput.value = inputNum.value / 60;
                    hoursInput.value = minutesInput.value / 60;
                    daysInput.value = hoursInput.value / 24;
                    break;
            } 
    });
   }
}