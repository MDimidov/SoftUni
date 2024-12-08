function loadCommits() {
    const username = document.querySelector("#username").value;
    const repoName = document.querySelector("#repo").value;
	const url = `https://api.github.com/repos/${username}/${repoName}/commits`;
	const commitsList = document.querySelector("#commits");
	commitsList.innerHTML = '';

    fetch(url)
        .then((response) => {
            if(!response.ok){
				throw new Error(`User not found: ${response.status}`);
			}
			
			return response.json()
        })
        .then((data) => {
            for (const commitInfo of data) {
                const commitItem = document.createElement("li");
                commitItem.textContent = `${commitInfo.commit.author.name}: ${commitInfo.commit.message}`;
                commitsList.appendChild(commitItem);
            }
        })
        .catch((error) => {
            const commitItem = document.createElement("li");
                commitItem.textContent = `${error}`;
                commitsList.appendChild(commitItem);
        });
}