// Задание 1
const arr = 'Прохожу курс по #javascript и #web';
console.info(getHashTags('Прохожу курс по #javascript и #web'));

function getHashTags(text){
    var res = [];
    if(checkLang(text) && !doubleSpace(text)){
        text.split(" ").forEach( word =>{
            if (word[0] === '#') {
                res.push(word.slice(1))
            }
        })
        return res;
    }
    else{
        return undefined;
    }

}

function checkLang(text){
    let array = /^[a-zа-я# ]+$/i;
    return array.test(text);
}

function doubleSpace(text){
    let array = / {2} */i
    return array.test(text)
}

// Задание 2
const TASK_2 = ['web','JavaScript','Web','script','programming']
console.info(normalizeHashTags(TASK_2))
function normalizeHashTags(list){
    let set = new Set(list.map(item=>item.toLowerCase()))
    return Array.from(set).join(", ")
}