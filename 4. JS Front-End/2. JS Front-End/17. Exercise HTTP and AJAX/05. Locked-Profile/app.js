function lockedProfile() {
    const baseURL = 'http://localhost:3030/jsonstore/advanced/profiles';
    const mainDiv = document.querySelector('#main');
    mainDiv.innerHTML = '';

    getProfiles();

    function getProfiles() {
        fetch(baseURL)
            .then((response) => response.json())
            .then((profiles) => {
                for (const profile of Object.values(profiles)) {
                    let counter = 1;
                    createProfile(profile, counter);
                    counter++;
                }
                buttons = document.querySelectorAll('button');
            })
            .catch((error) => console.error(error));
    }

    function createProfile(profile, counter) {
        const profileDiv = document.createElement('div');
        profileDiv.classList.add('profile');
        profileDiv.innerHTML = addInnerHtml(profile.username, counter);
        profileDiv.appendChild(createInputEl('text', `user${counter}Username`,profile.username));

        const divUserInfo = document.createElement('div');
        divUserInfo.classList.add(`username-${profile.username}`);
        divUserInfo.style.display = 'none';
        divUserInfo.appendChild(document.createElement('hr'));

        const labelEmail = document.createElement('label');
        labelEmail.textContent = 'Email:';
        divUserInfo.appendChild(labelEmail);
        divUserInfo.appendChild(createInputEl('email', `user${counter}Email`,profile.email));
        const labelAge = document.createElement('label');
        divUserInfo.appendChild(labelAge);
        divUserInfo.appendChild(createInputEl('text', `user${counter}Age`,profile.age));

        profileDiv.appendChild(divUserInfo);

        const btnShow = document.createElement('button');
        btnShow.textContent = 'Show more';
        btnShow.addEventListener('click', iterateBtn);

        profileDiv.appendChild(btnShow);
        mainDiv.appendChild(profileDiv);
    }
    
function addInnerHtml(username, counter) {
    return `<img src="./iconProfile2.png" class="userIcon" />
				<label>Lock</label>
				<input type="radio" name="user${counter}Locked" value="lock" checked>
				<label>Unlock</label>
				<input type="radio" name="user${counter}Locked" value="unlock"><br>
				<hr>
				<label>Username</label>`;
}

    function createInputEl(type, nameValue, value) {
        const inputUsername = document.createElement('input');
        inputUsername.type = type;
        inputUsername.setAttribute('name', nameValue);
        inputUsername.setAttribute('value', value);
        inputUsername.value = value;
        inputUsername.disabled = true;
        inputUsername.readOnly = true;

        return inputUsername;
    }


    function iterateBtn(e) {
        const hiddenFields = e.target.parentElement.querySelector('div[class]');
        const isProfileLocked = e.target.parentElement.querySelector('input[value=lock]').checked;
        const btnName = e.target.textContent;
        if (isProfileLocked){
            return;
        }
        
        if (btnName === 'Show more') {
            e.target.textContent = 'Hide it';
            hiddenFields.style.display = 'block';
        } else {
            e.target.textContent = 'Show more';
            hiddenFields.style.display = 'none';
        }
    }
    
    
}