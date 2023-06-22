                                         // Задание 1
console.info(sum(12,33));
console.info(sum(101,'17'));

function sum(a,b){
    if(!isNaN(a) && !isNaN(b)){
        return Number(a) + Number(b);
    }
    else{
        return NaN;
    }
}

                                         // Задание 2

console.info(isValidTime(12,30));
console.info(isValidTime(12,61));

// Проверака на целые числа
function isInt(ints){
    for (i=0; i<ints.length;i++){
        if (!Number.isInteger(ints[i])){
            return false;
        }
    }
    return true;
}
// Проверка времени
function checkHour(hour){
    return 0 <= hour && hour <= 23;
}
function checkMinute(minute){
    return 0 <= minute && minute <= 59;
}
function isValidTime(hour,minute){
    if (isInt(hour,minute)){
        if(checkHour(hour) && checkMinute(minute)){
            return true;
        }
        else{
            return false;
        }
    }
}

                                      // Задание 3
console.info(addTime(12,30,30));
console.info(addTime(23,59,720));

function addTime (hours, minutes, interval) {

    if(isInt(hours,minutes,interval) && checkHour(hours) && checkMinute(minutes) && interval>=0){

        hours += Math.floor((minutes + interval)/60);

        minutes = (minutes + interval) % 60;  
        hours %= 24;
    
        if ( minutes >= 0 && minutes <= 9){
            minutes = "0" + minutes;
        }
    
        if ( hours >= 0 && hours <= 9){
            hours = "0" + hours;
        }
    
        return hours + ":" + minutes;
    }
    else{
        return undefined;
    }

};