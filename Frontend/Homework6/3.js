let array = ["HTML", 11, "Javascript", 2, "CSS", 23, 12];
array.push(-54);
array.unshift(1000)
array = array.filter(el => el !== "Javascript")
array = array.filter(el => typeof(el) === 'number')

const newArr = array.map(el => {
    return Math.pow(el, 2)
})

console.log(array)
console.log(newArr)
console.log(Math.max.apply(Math, newArr))
