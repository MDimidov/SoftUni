function loadRepos() {
	const username = document.querySelector("#username").value;
	const url = `https://api.github.com/users/${username}/repos`;
	const reposList = document.querySelector("#repos");
	reposList.innerHTML = '';

	fetch(url)
		.then((response) => {
			if(!response.ok){
				throw new Error(`User not found: ${response.status}`);
			}
			
			return response.json()
		})
		.then((data) => {
			if (data.length === 0) {
				const listItem = document.createElement("li");
				listItem.textContent = "No repositories found.";
				reposList.appendChild(listItem);
				return;
			}

			for (const repo of data) {
				const listItem = document.createElement('li');
				const link = document.createElement('a');
				
				link.href = repo.html_url;
				link.textContent = repo.full_name;
				link.target = "_blank";

				listItem.appendChild(link);
				reposList.appendChild(listItem);
			}
		})
		.catch((error) => {
			const listItem = document.createElement("li");
      		listItem.textContent = `Error: ${error.message}`;
      		reposList.appendChild(listItem);
		});
}