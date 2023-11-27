function printSongs(array) {
  const numberOfSongs = array.shift();
  const typeList = array.pop();
  //   console.log(array);

  let songs = [];

  class Song {
    constructor(typeList, name, time) {
      this.typeList = typeList;
      this.name = name;
      this.time = time;
    }

    isSongCorrect(typeList) {
      if (typeList === "all") {
        console.log(this.name);
      } else if (typeList === this.typeList) {
        console.log(this.name);
      }
    }
  }

  for (let i = 0; i < array.length; i++) {
    const [typeList, name, time] = array[i].split("_");
    songs.push(new Song(typeList, name, time));
  }

  songs.forEach((song) => {
    song.isSongCorrect(typeList);
  });
}

printSongs([2, "like_Replay_3:15", "ban_Photoshop_3:48", "all"]);
