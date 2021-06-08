using System;
using System.Collections.Generic;

namespace Library
{
    /*
    */
    public class PersonProfile
    {
        public string Name {get;}

        public int Price {get;}

        public string Location {get;}

        public List<Category> selectedCategory {get;}

        public PersonProfile(string name, int price, string location)
        {
            this.Name = name;
            this.Price = price;
            this.Location = location;
        }
    }
}
