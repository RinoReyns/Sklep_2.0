namespace ProjectShop
{
    public class Person
    {
        public string Name { get; set; }
        public string Surename{ get; set; }   
        public string Address { get; set; }
        public string Telephone { get; set; }

        public Person()
        {}
        public Person(Person p)
        {
            this.Name = p.Name;
            this.Surename = p.Surename;
            this.Address = p.Address;
            this.Telephone = p.Telephone;
        }

    }
}
