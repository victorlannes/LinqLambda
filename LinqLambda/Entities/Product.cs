using System.Globalization;


namespace LinqLambda.Entities {
     class Product {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Tier { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }

        public override string ToString() {
            return Id + ", " + Name + ", " + Price.ToString("F2", CultureInfo.InvariantCulture) + ", " + Category.Name;
        }

    }
}
