function VacationPrice(groupCount, groupType, dayOfWeek) {
    let discount = 1;
    let pricePerPerson = 0;
    if (groupType === 'Students') {

        if (groupCount >= 30) {
            discount = 0.85;
        }

        if (dayOfWeek === 'Friday') {
            pricePerPerson = 8.45;
        } else if (dayOfWeek === 'Saturday') {
            pricePerPerson = 9.80;
        } else if (dayOfWeek === 'Sunday'){
            pricePerPerson = 10.46;
        }
    } else if (groupType === 'Business') {

        if (groupCount >= 100) {
            groupCount -= 10;
        }

        if (dayOfWeek === 'Friday') {
            pricePerPerson = 10.90;
        } else if (dayOfWeek === 'Saturday') {
            pricePerPerson = 15.60;
        } else if (dayOfWeek === 'Sunday'){
            pricePerPerson = 16.00;
        }
    } else if (groupType === 'Regular') {
        
        if (groupCount >= 10 && groupCount <= 20) {
            discount = 0.95;
        }

        if (dayOfWeek === 'Friday') {
            pricePerPerson = 15.00;
        } else if (dayOfWeek === 'Saturday') {
            pricePerPerson = 20.00;
        } else if (dayOfWeek === 'Sunday'){
            pricePerPerson = 22.50;
        }
    }

    let result = groupCount * pricePerPerson * discount;
    console.log(`Total price: ${result.toFixed(2)}`)
}

VacationPrice(40, "Regular", "Saturday")


// --------------Variant 2---------------------


function VacationPrice(groupCount, groupType, dayOfWeek) {
    let price = 0;
    let discount = 1;

    if (groupType === "Students") {
        switch (dayOfWeek) {
            case "Friday":
                price = 8.45;
                break;
            case "Saturday":
                price = 9.8;
                break;
            case "Sunday":
                price = 10.46;
                break;
        }

        if(groupCount >= 30){
            discount -= 0.15; 
        }

    } else if (groupType === "Business") {
        switch (dayOfWeek) {
            case "Friday":
                price = 10.9;
                break;
            case "Saturday":
                price = 15.6;
                break;
            case "Sunday":
                price = 16;
                break;
        }

        if(groupCount >= 100){
            groupCount -= 10; 
        }

    } else if (groupType === "Regular") {
        switch (dayOfWeek) {
            case "Friday":
                price = 15.0;
                break;
            case "Saturday":
                price = 20.0;
                break;
            case "Sunday":
                price = 22.5;
                break;
        }

        if(groupCount >= 10 && groupCount <= 20){
            discount -= 0.05; 
        }
        
    }

    const totalPrice = price * discount * groupCount;

    console.log(`Total price: ${totalPrice.toFixed(2)}`)
}

VacationPrice(30, "Students", "Sunday")