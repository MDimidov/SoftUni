function lockedProfile() {
    const buttons = Array.from(document.querySelectorAll("button"));
    for (const button of buttons) {
        button.addEventListener('click', showOrHideProfile);
    }

    function showOrHideProfile(e) {
        let buttonName = e.target.textContent;
        let isProfileUnlocked = e.target.parentElement.querySelector("input[value=unlock]").checked;
        let showOrHideInfo = e.target.parentElement.querySelector("div[id]");

        if (!isProfileUnlocked) {
            return;
        }

        if (buttonName === "Show more") {
            e.target.textContent = "Hide it";
            showOrHideInfo.style.display = "block";
        } else {
            e.target.textContent = "Show more"
            showOrHideInfo.style.display = "";
        }
    }
}