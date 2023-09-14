console.log("typeof number:", typeof 21)
console.log("typeof string:", typeof "string")
console.log("typeof boolean:", typeof true)
console.log("typeof undefined:", typeof undefined)
console.log("typeof null:", typeof null)
console.log("typeof object:", typeof {})


const myCurrentAge = +prompt('Cati ani aveti?')

// if else
 if (myCurrentAge > 25) {
     alert('Sunt mai mare de 25 de ani')
 } else alert('Am mai putin de 25 de ani')

// ternary
alert(myCurrentAge > 25 ? 'Sunt mai mare de 25 de ani' : 'Am mai putin de 25 de ani')

// switch

switch (myCurrentAge) {
    case myCurrentAge > 25:
        alert('Sunt mai mare de 25 de ani')
        break;
    case myCurrentAge < 25:
        alert('Am mai putin de 25 de ani')
        break;
}

