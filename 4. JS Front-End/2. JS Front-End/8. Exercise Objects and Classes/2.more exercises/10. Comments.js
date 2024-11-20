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

// showComments([
//   "user Mark",
//   "Mark posts on someArticle: NoTitle, stupidComment",
//   "article Bobby",
//   "article Steven",
//   "user Liam",
//   "user Henry",
//   "Mark posts on Bobby: Is, I do really like them",
//   "Mark posts on Steven: title, Run",
//   "someUser posts on Movies: Like",
// ]);

// -----------------Method 2--------------------

function showComments(inputArr) {
  const users = [];
  const articles = [];
  const comments = [];

  inputArr.forEach((command) => {
    if (command.includes('user')) {
      addUser(command);
    } else if (command.includes('article')) {
      addArticle(command);
    } else if (command.includes('posts on')) {
      const commentInfo = getCommentInfo(command);
      if (isUserAndArticleValid(commentInfo.user, commentInfo.article)) {
        addComment(commentInfo);  
      }
    }
  });
  
  function addUser(userCommand) {
    const [_, userName] = userCommand.split('user ');
    users.push(userName);
  }

  function addArticle(articleCommand) {
    const [_, article] = articleCommand.split('article ');
    articles.push(article);
  }

  function getCommentInfo(commentCommand) {
  const [user, comments] = commentCommand.split(' posts on ');
  const [article, comment] = comments.split(': ');
  const [commentTitle, commentContent] = comment.split(', ');

  return {
    user,
    article,
    commentTitle,
    commentContent,
  };
  }

  function isUserAndArticleValid(user, article) {
    return users.includes(user) && articles.includes(article);
  }

  function addComment(commentInfo) {
    comments.push(commentInfo);
  }
  
  // Групиране на коментарите по статии
  const groupedComments = comments.reduce((acc, comment) => {
    if (!acc[comment.article]) {
      acc[comment.article] = [];
    }
    acc[comment.article].push(comment);
    return acc;
  }, {});

  // Сортиране на статиите по брой коментари (низходящо)

  const sortedArticles = Object.entries(groupedComments)
    .sort((a, b) => b[1].length - a[1].length)
    .map(([article, comments]) => ({
      article,
      comments: comments.sort((a, b) => a.user.localeCompare(b.user)), // Сортиране на коментарите по име на потребителя
    }));



  // Форматиране и извеждане на резултата

  sortedArticles.forEach(({ article, comments }) => {
    console.log(`Comments on ${article}`);
    comments.forEach(({ user, commentTitle, commentContent }) => {
      console.log(`--- From user ${user}: ${commentTitle} - ${commentContent}`);
    });
  });
}

showComments([
  'user aUser123', 
  'someUser posts on someArticle: NoTitle, stupidComment', 
  'article Books',
  'article Movies', 
  'article Shopping', 'user someUser', 
  'user uSeR4', 'user lastUser', 
  'uSeR4 posts on Books: I like books, I do really like them', 
  'uSeR4 posts on Movies: I also like movies, I really do', 
  'someUser posts on Shopping: title, I go shopping every day',
  'someUser posts on Movies: Like, I also like movies very much'
]);