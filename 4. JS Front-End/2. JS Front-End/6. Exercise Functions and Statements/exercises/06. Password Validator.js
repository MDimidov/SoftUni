function passValidator(pass) {
  function onlyLettersAndNumbers(str) {
    return /^[A-Za-z0-9]*$/.test(str);
  }

  function atLeast2Digits(str) {
    let matches = str.match(/(\d)/);
    if (matches != null && matches.length >= 2) {
      return true;
    } else {
      return false;
    }
  }

  const errors = [];
  if (pass.length < 6 || pass.length > 10) {
    errors.push("Password must be between 6 and 10 characters");
  }
  if (!onlyLettersAndNumbers(pass)) {
    errors.push("Password must consist only of letters and digits");
  }
  if (!atLeast2Digits(pass)) {
    errors.push("Password must have at least 2 digits");
  }

  if (errors.length > 0) {
    console.log(errors.join("\n"));
  } else {
    console.log("Password is valid");
  }
}

// passValidator("Pa$s$s");


// -----------------Method 2--------------------


function passValidator(pass) {
  const passwordLength = pass.length >= 6 && pass.length <= 10;

  const regex = /^[a-zA-Z\d]+$/;
  const onlyLettersAndNumbers = regex.test(pass); 
  
  const atLeast2Digits = (pass.match(/\d/g) || []).length >= 2; 

  if (!passwordLength) {
    console.log('Password must be between 6 and 10 characters');
  }
  
  if (!onlyLettersAndNumbers) {
    console.log('Password must consist only of letters and digits');
  }

  if (!atLeast2Digits) {
    console.log('Password must have at least 2 digits');
  }

  if (passwordLength && onlyLettersAndNumbers && atLeast2Digits) {
    console.log('Password is valid');
  }
}

// passValidator("logIn");
// passValidator("MyPass123");
passValidator("Pa$s$s");