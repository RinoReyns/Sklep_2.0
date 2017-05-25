namespace ProjectShop
{
    /// <summary>
    /// Klasa, która zawiera pola do przechowywania danych użytkownika.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Imię użytkownika 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Nazwisko użytkownika
        /// </summary>
        public string Surename{ get; set; }   
        /// <summary>
        /// Adres użytkownika
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Telefon użytkownika
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// Konstruktor klasy Person, który tworzy obiekt klasy z domyślnie pustymi wartościmi dla każdej propercji.
        /// </summary>
        public Person()
        {}
        /// <summary>
        /// Konstruktor klasy Persone, który tworzy obiekt klasy oraz nadaje wartości poszczególnym propercją zgodnie z wartościami przekazanymi przez
        /// parametr "p".
        /// </summary>
        /// <param name="p"> Obiek klasy osoba, która zawiera dane użytkownika.</param>
        public Person(Person p)
        {
            this.Name = p.Name;
            this.Surename = p.Surename;
            this.Address = p.Address;
            this.Telephone = p.Telephone;
        }

    }
}
