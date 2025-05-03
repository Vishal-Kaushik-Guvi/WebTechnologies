let student = {
    name: "Vishal",
    age: 24,
    grade: "A",
    status: "active"
};

for (let key in student) {
    if (key === "age") {
        continue; 
    }
    if (key === "grade") {
        break; 
    }
    console.log(key + ": " + student[key]);
}
