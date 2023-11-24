//          Meethod1

// function RoadRadar(speed, roadType) {

//     let maxSpeed = 0;
//     switch (roadType) {
//         case 'motorway':
//             maxSpeed = 130;
//             break;
//         case 'interstate':
//             maxSpeed = 90;
//             break;

//         case 'city':
//             maxSpeed = 50;
//             break;

//         case 'residential':
//             maxSpeed = 20;
//             break;
//         default:
//             break;
//     }

//     let overSpeed = speed - maxSpeed;
//     let status = '';

//     if (overSpeed <= 20) {
//         status = 'speeding';
//     } else if (overSpeed <= 40) {
//         status = 'excessive speeding';
//     }
//     else {
//         status = 'reckless driving';
//     }

//     if (overSpeed <= 0) {
//         console.log(`Driving ${speed} km/h in a ${maxSpeed} zone`)
//     } else {
//         console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of ${maxSpeed} - ${status}`);

//     }
// }

//          Method2

function RoadRadar(speed, area) {
  const speedLimits = {
    motorway: 130,
    interstate: 90,
    city: 50,
    residential: 20,
  };

  const currentSpeedLimit = speedLimits[area];
  const speedOverLimit = speed - currentSpeedLimit;

  if (speedOverLimit <= 0) {
    console.log(`Driving ${speed} km/h in a ${currentSpeedLimit} zone`);
    return;
  }

  const speedingMessage =
    speedOverLimit <= 20
      ? "speeding"
      : speedOverLimit <= 40
      ? "excessive speeding"
      : "reckless driving";

  console.log(
    `The speed is ${speedOverLimit} km/h faster than the allowed speed of ${currentSpeedLimit} - ${speedingMessage}`
  );
}

RoadRadar(120, "interstate");
