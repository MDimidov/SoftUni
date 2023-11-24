function Promotions(dayType, age) {
    let result;
    if (dayType === 'Weekday') {
        if (age >= 0 && age <= 18) {
            result = 12;
        } else if (age > 18 && age <= 64) {
            result = 18;
        }
        else if (age > 64 && age <= 122) {
            result = 12;
        }
        else{
            console.log('Error!');
            return;
        }
    } else if (dayType === 'Weekend') {
        if (age >= 0 && age <= 18) {
            result = 15;
        } else if (age > 18 && age <= 64) {
            result = 20;
        }
        else if (age > 64 && age <= 122) {
            result = 15;
        }
        else{
            console.log('Error!');
            return;
        }
    }
    else{
        if (age >= 0 && age <= 18) {
            result = 5;
        } else if (age > 18 && age <= 64) {
            result = 12;
        }
        else if (age > 64 && age <= 122) {
            result = 10;
        }
        else{
            console.log('Error!');
            return;
        }
    }

    console.log(`${result}$`)
}

Promotions('Holiday', 15 );