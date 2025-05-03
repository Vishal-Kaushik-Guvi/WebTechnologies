let car = {
    brand: "Toyota",
    model: "Corolla",
    year: 2020,
    displayInfo: function() {
        return `Car Info: ${this.brand} ${this.model}, Year: ${this.year}`;
    }
};

console.log(car.brand);
console.log(car.model); 
console.log(car.year); 

console.log(car.displayInfo());
