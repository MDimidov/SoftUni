function attachEvents() {

    const postsURL = 'http://localhost:3030/jsonstore/blog/posts';
    const commentsURL = 'http://localhost:3030/jsonstore/blog/comments';

    const btnLoadPost = document.querySelector('#btnLoadPosts');
    const postsEl = document.querySelector('#posts');
    const btnViewPost = document.querySelector('#btnViewPost');

    btnLoadPost.addEventListener('click', loadPosts);
    btnViewPost.addEventListener('click', viewPosts);

    function loadPosts() {
        postsEl.innerHTML = '';
        fetch(postsURL)
            .then((response) => response.json())
            .then((posts) => {
                for (const post of Object.values(posts)) {
                    const optionEl = document.createElement('option');
                    optionEl.textContent = post.title
                    Object.assign(optionEl, post);
                    postsEl.appendChild(optionEl);
                }
            })
            .catch((error) => console.error(error));
    }

    function viewPosts() {
        const postTitle = document.querySelector('#post-title');
        const postBody = document.querySelector('#post-body');
        const postComments = document.querySelector('#post-comments');
        const selectedOption = document.querySelector('#posts>option:checked');

        postTitle.textContent = selectedOption.title;
        postBody.textContent = selectedOption.body;
         

        fetch(commentsURL)
            .then((response) => response.json())
            .then((comments) => {
                for (const comment of Object.values(comments)) {
                    if(comment.postId === selectedOption.id){
                        const liEl = document.createElement('li');
                        liEl.id = comment.id;
                        liEl.textContent = comment.text;
                        postComments.appendChild(liEl);
                    }
                }
            })
            .catch((error) => console.error(error));
    }

}

attachEvents();