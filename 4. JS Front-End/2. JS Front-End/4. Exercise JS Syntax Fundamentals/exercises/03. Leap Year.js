function isYearLeap(year) {
    if(year % 4 === 0){
        if (year % 100 === 0 && year % 400 != 0) {
            console.log('no');
        } else{            
         console.log('yes');
        }
    }else{
        console.log('no');
    }


}

isYearLeap(1984);

// --------------Variant 2---------------------

function isYearLeap(year) {
    if((year % 4 === 0 && year % 100 !== 0) || year % 400 === 0 ){
        console.log('yes');
    } else{
        console.log('no');
    }
}

isYearLeap(2003);