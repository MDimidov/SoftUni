//With chatGPT Help
// function storeUniqueArray(input) {
//   const arrays = input.map((str) => JSON.parse(str));

//   const sortedArrayOfArrays = arrays.map((subarray) =>
//     subarray.sort((a, b) => b - a)
//   );

//   // Функция за сравнение на масиви
//   function arraysEqual(arr1, arr2) {
//     if (arr1.length !== arr2.length) return false;
//     for (let i = 0; i < arr1.length; i++) {
//       if (arr1[i] !== arr2[i]) return false;
//     }
//     return true;
//   }

//   // Филтриране на уникалните масиви
//   const uniqueArrays = sortedArrayOfArrays.filter((subarray, index) => {
//     return (
//       sortedArrayOfArrays.findIndex((arr) => arraysEqual(arr, subarray)) ===
//       index
//     );
//   });

//   uniqueArrays
//     .sort((a, b) => a.length - b.length)
//     .forEach((element) => {
//       console.log(`[${element.join(", ")}]`);
//     });
// }

//Own decision

function removeDublicates(inputArr) {
  const removed = inputArr
    .reduce((acc, curr) => {
      let test = JSON.parse(curr);
      acc.push(test.sort((a, b) => b - a));
      return acc;
    }, [])
    .sort((a, b) => a.length - b.length);

  const result = new Set();

  removed.forEach((element) => {
    result.add(`[${element.join(", ")}]`);
  });

  result.forEach((element) => {
    console.log(element);
  });
}

storeUniqueArray([
  "[-3, -2, -1, 0, 1, 2, 3, 4]",
  "[10, 1, -17, 0, 2, 13]",
  "[4, -3, 3, -2, 2, -1, 1, 0]",
]);

// function storeUniqueArray(input) {
//   const arrays = input.map(JSON.parse);

//   const sortedArrayOfArrays = arrays.map((subarray) =>
//     subarray.sort((a, b) => b - a)
//   );

//   for (let i = 0; i < sortedArrayOfArrays.length; i++) {
//     const element = sortedArrayOfArrays[i];
//     for (let j = 0; j < sortedArrayOfArrays.length; j++) {
//       if (i === j) {
//         continue;
//       }
//       const repiter = sortedArrayOfArrays[j];
//       if (element === repiter) {
//         sortedArrayOfArrays.splice(j, 1);
//         // j--;
//       }
//     }
//   }

//   console.log(JSON.stringify(sortedArrayOfArrays));
// }

// storeUniqueArray([
//   "[-3, -2, -1, 0, 1, 2, 3, 4]",
//   "[10, 1, -17, 0, 2, 13]",
//   "[4, -3, 3, -2, 2, -1, 1, 0]",
// ]);
