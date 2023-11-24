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