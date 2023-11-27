function cityTaxes(name, population, treasury) {
  return {
    name,
    population,
    treasury,
    taxRate: 10,
    collectTaxes() {
      this.treasury += Math.floor((this.population * this.taxRate) / 100);
    },
    applyGrowth(percentage) {
      this.population += Math.floor((this.population * this.percentage) / 100);
    },
    applyRecession(percentage) {
      this.treasury = Math.floor((this.treasury * this.percentage) / 100);
    },
  };
}

const city = cityTaxes("Tortuga", 7000, 15000);
console.log(city);
