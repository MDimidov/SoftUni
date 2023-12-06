function showComments(inputArr) {
  class Comments {
    constructor(article) {
      this.article = article;
      this.usersComents = [];
    }

    addUserComent(userComnent) {
      this.usersComents.push(userComnent);
    }

    sortUsersComents() {
      this.usersComents = this.usersComents.sort(function (a, b) {
        return a.localeCompare(b);
      });
    }

    printComments() {
      console.log(`Comments on ${this.article}`);
      this.usersComents.forEach((comment) => {
        console.log(comment);
      });
    }
  }
  const users = [];
  let articles = [];

  inputArr.forEach((curr) => {
    if (curr.includes("user")) {
      const user = curr.split("user ")[1];
      users.push(user);
    } else if (curr.includes("article")) {
      const article = curr.split("article ")[1];
      articles.push(new Comments(article));
    } else if (curr.includes("posts on")) {
      const [user, posts] = curr.split(" posts on ");
      isUserValid = users.find((x) => x === user);
      if (isUserValid) {
        const [article, comment] = posts.split(": ");
        const [comTitle, comContent] = comment.split(", ");

        const classs = articles.find((c) => c.article === article);
        if (classs) {
          const userComment = `--- From user ${user}: ${comTitle} - ${comContent}`;
          classs.addUserComent(userComment);
        }
      }
    }
  });

  articles = articles
    .sort((a, b) => b.usersComents.length - a.usersComents.length)
    .forEach((comment) => {
      comment.sortUsersComents();
      comment.printComments();
    });
}

showComments([
  "user Mark",
  "Mark posts on someArticle: NoTitle, stupidComment",
  "article Bobby",
  "article Steven",
  "user Liam",
  "user Henry",
  "Mark posts on Bobby: Is, I do really like them",
  "Mark posts on Steven: title, Run",
  "someUser posts on Movies: Like",
]);
