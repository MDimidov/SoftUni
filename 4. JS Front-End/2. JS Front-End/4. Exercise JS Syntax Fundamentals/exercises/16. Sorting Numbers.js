function SortNums(array) {
  let smallArray = array.sort((a, b) => a - b);
  let finalArray = [];
  const length = smallArray.length;

  for (let i = 0; i < length; i++) {
    if (i % 2 === 0) {
      finalArray.push(smallArray.shift());
    } else {
      finalArray.push(smallArray.pop());
    }
  }

  finalArray.forEach((element) => {
    console.log(element);
  });
}

SortNums([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);



// --------------Variant 2---------------------


function SortNums(array) {
  let sortArray = array.sort((a, b) => a - b);
  const finalArray = sortArray.reduce((acc, _, index) => {
    if (index % 2 === 0) {
      acc.push(sortArray.shift());
    } else {
      acc.push(sortArray.pop());
    }

    return acc;
  }, []);

    console.log(finalArray);
}

SortNums([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);