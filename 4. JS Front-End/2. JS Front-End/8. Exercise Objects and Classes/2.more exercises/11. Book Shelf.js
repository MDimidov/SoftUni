function showShelf(inputArr) {
  class Shelf {
    constructor(id, genre) {
      this.id = id;
      this.genre = genre;
      this.books = [];
    }

    addBook(book) {
      if (book.genre === this.genre) {
        this.books.push(book);
      }
    }

    sortBooks() {
      this.books = this.books.sort((a) => a.title);
    }

    printResult() {
      console.log(`${this.id} ${this.genre}: ${this.books.length}`);
      this.books.forEach((book) => {
        console.log(`--> ${book.title}: ${book.author}`);
      });
    }
  }

  class Book {
    constructor(title, author, genre) {
      this.title = title;
      this.author = author;
      this.genre = genre;
    }
  }

  let shelfs = [];

  inputArr.forEach((row) => {
    if (row.includes("->")) {
      const [shelfId, shelfGenre] = row.split(" -> ");
      let shelf = shelfs.find((s) => s.id === shelfId);

      if (!shelf) {
        shelf = new Shelf(shelfId, shelfGenre);
        shelfs.push(shelf);
      }
    } else if (row.includes(":")) {
      const [bookTitle, bookInfo] = row.split(": ");
      const [bookAuthor, bookGenre] = bookInfo.split(", ");
      let shelf = shelfs.find((s) => s.genre === bookGenre);

      if (shelf) {
        shelf.addBook(new Book(bookTitle, bookAuthor, bookGenre));
      }
    }
  });

  shelfs
    .sort((a, b) => b.books.length - a.books.length)
    .forEach((shelf) => {
      shelf.sortBooks();
      shelf.printResult();
    });
}

showShelf([
  "1 -> mystery",
  "2 -> sci-fi",
  "Child of Silver: Bruce Rich, mystery",
  "Lions and Rats: Gabe Roads, history",
  "Effect of the Void: Shay B, romance",
  "Losing Dreams: Gail Starr, sci-fi",
  "Name of Earth: Jo Bell, sci-fi",
]);
