let student = {
    name: "Vishal",
    age: 24,
    grade: "A"
};

for (let key in student) {
    console.log(key + ": " + student[key]);
}
