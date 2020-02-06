namespace VSC
{
    public class Service
    {
        public string Name {get; set; }
        public decimal Price {get; set;}
        public Service(string name, decimal price) {
            Name = name;
            Price = price;
        }
    }
}
