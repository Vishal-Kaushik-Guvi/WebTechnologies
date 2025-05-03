let a = 10, b = 5;

let sum = a + b;
let difference = a - b;
let product = a * b;
let quotient = a / b;
let remainder = a % b;

let isEqual = (a == b);
let isNotEqual = (a != b);
let isGreater = (a > b);
let isLessOrEqual = (a <= b);

let logicalAnd = (a > 0 && b > 0);
let logicalOr = (a > 0 || b < 0);
let logicalNot = !(a > 0);

let x = 10;
x += 5;

console.log("Sum:", sum);
console.log("Difference:", difference);
console.log("Product:", product);
console.log("Quotient:", quotient);
console.log("Remainder:", remainder);

console.log("a == b:", isEqual);
console.log("a != b:", isNotEqual);
console.log("a > b:", isGreater);
console.log("a <= b:", isLessOrEqual);

console.log("a > 0 && b > 0:", logicalAnd);
console.log("a > 0 || b < 0:", logicalOr);
console.log("!(a > 0):", logicalNot);

console.log("x after x += 5:", x);