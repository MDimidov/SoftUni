function validate() {
    const email = document.querySelector("#email");
    email.addEventListener("change", checkMail);

    function checkMail(e) {
        let pattern = /^[a-z]+\@[a-z]+\.[a-z]+$/gm;
        if (pattern.test(email.value)) {
            email.classList.remove("error");
        } else {
            email.classList.add("error");
        }
    }
}