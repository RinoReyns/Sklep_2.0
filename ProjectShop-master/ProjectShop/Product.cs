using System.Collections.Generic;

namespace ProjectShop
{
    /// <summary>
    /// Klasa abstrakcyjna, która w kolejnych wersjach zostanie wykorzystana jako jako ViewModel, na który zostaną zrzutowane wartości z bazy danych.
    /// Klas dziedziczy po interfejsie ICount.
    /// </summary>
    public abstract class Product : ICount
    {
        /// <summary>
        /// Nazwa produktu
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Cena produktu
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Ilość produktów
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Kolor produktu
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// Poducent produktu
        /// </summary>
        public string Producent { get; set; }
        /// <summary>
        /// Lista rozmiarów/ wielkości dostępnych produktów, w zależności od danych zapisanych w bazie danych.
        /// </summary>
        public List<string> Size = new List<string>();
        /// <summary>
        /// Rozmiar wybranego produktu
        /// </summary>
        public string SizeItem { get; set; }
        /// <summary>
        /// Dodatkowa cena, przy ubezpieczeniu produktu
        /// </summary>
        public int WithWarrentyElementsCounter { get; set; }

        /// <summary>
        /// Konstruktor klasy, podczas tworzenia obiektu dziedziczącego po klasie Product, który nadaje wartości domyślne konkretnym propercjom.
        /// </summary>
        protected Product()
        {
            this.Quantity = 1;
            this.Color = "1";
            this.WithWarrentyElementsCounter = 0;
        }
        /// <summary>
        /// Definicja działania metody Count zawartej w interfejsie ICount, po którym dziedziczy klasa Product.
        /// </summary>
        /// <param name="quantity"></param>
        /// <param name="price"></param>
        /// <param name="checkbox"></param>
        /// <returns></returns>
        public virtual double Count(int quantity, double price, bool? checkbox)
        {
            if (checkbox == true)            
                return ((quantity * price) + quantity*10);   
            else 
            return (quantity * price);
        }
    }
    public class Boot : Product
    {
        public Boot()
        {
            this.Name = "Boot";
            this.Price = 100;
            this.Producent = "Hugo Boss";
            Size.Add("38");
            Size.Add("39");
            Size.Add("40");
            Size.Add("41");
            Size.Add("42");
        }
    }

    public class Shoes : Product
    {
        public Shoes()
        {
            this.Name = "Shoes";
            this.Price = 30;
            this.Producent = "Hugo Boss";
            Size.Add("38");
            Size.Add("39");
            Size.Add("40");
            Size.Add("41");
            Size.Add("42");
        }
    }
    public class Dress: Product
    {
        public Dress()
        {
            this.Name = "Dress";
            this.Price = 1000;
            this.Producent = "Olivia";
            Size.Add("37");
            Size.Add("39");
            Size.Add("40");
        }
    }

    public class Micro : Product
    {
        public Micro()
        {
            this.Name = "Micro";
            this.Price = 20;
            this.Color = "0";
            this.Producent = "Flexic";
            Size.Add("Lack of sizes");
        }
    }

    public class Nails : Product
    {
        public Nails()
        {
            this.Name = "Nails";
            this.Price = 1;
            this.Color = "0";
            this.Producent = "Flexic";
            Size.Add("1 mm");
            Size.Add("2 mm");
            Size.Add("5 mm");
            Size.Add("10 mm");
        }
     override  public double Count(int quantity, double price, bool? checkbox)
        {
            if (checkbox == true)
                return (((quantity * price) + quantity * 10)/2);
            else
                return ((quantity * price)/2);
        }

    }

    public class Table : Product
    {
        public Table()
        {
            this.Name = "Table";
            this.Price = 299.99;
            this.Color = "1";
            this.Producent = "Tablex";
            Size.Add("1x1 m");
            Size.Add("2x5 m");
            Size.Add("3x1 m");
            Size.Add("18x35 m");
        }
    }

    public class Door : Product
    {
        public Door()
        {
            this.Name = "Door";
            this.Price = 153.58;
            this.Color = "1";
            this.Producent = "Doorex";
            Size.Add("2x1.5 m");
            Size.Add("3x3 m");  
        }
    }
    public class Cd : Product
    {
        public Cd()
        {
            this.Name = "CD";
            this.Price = 29.99;
            this.Color = "0";
            this.Producent = "CDDrex";
            Size.Add("Lack of sizes");
        }
    }

    public class Guitar : Product
    {
        public Guitar()
        {
            this.Name = "Guitar";
            this.Price = 1000;
            this.Color = "1";
            this.Producent = "Ibanez";
            Size.Add(@"25.5'");
            Size.Add(@"27'");
            Size.Add(@"24.75'");
        }
    }

    public class Amp : Product
    {
        public Amp()
        {
            this.Name = "AMP";
            this.Price = 13000;
            this.Color = "1";
            this.Producent = "Marshall";
            Size.Add("Combo");
            Size.Add("Head");
        }
    }
}
