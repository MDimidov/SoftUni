function AgeType(age) {

    let result;

    switch (true) {
        case (age >= 0 && age <= 2):
            result = 'baby';
            break;
    
        case (age >= 3 && age <= 13):
            result = 'child';
            break;

        case (age >= 14 && age <= 19):
            result = 'teenager';
            break;

        case (age >= 20 && age <= 65):
            result = 'adult';
            break;

        case age >= 66:
            result = 'elder';
            break;

        default:
            result = 'out of bounds';
            break;
    }

    console.log(result);
}


AgeType(20);


// --------------Variant 2---------------------

function AgeTypes(age){

    const baby = "baby";
    const child = "child";
    const teenager = "teenager";
    const adult = "adult";
    const elder = "elder";

    let result = "out of bounds";

    switch (true) {
        case (age >= 66):
            result = elder;
            break;

        case age >= 20:
            result = adult;
            break;
    
        case age >= 14:
            result = teenager;
            break;

        case age >= 3:
            result = child;
            break;

        case age >= 0:
            result = baby;
            break;
    }

    console.log(result);
}

AgeTypes(69);