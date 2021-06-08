using System;
using System.Collections.Generic;

namespace Library
{
    /*
    */
    public class Category
    {
        public string Name {get;}

        public string ParentCategory {get;}

        public string Option {get;}

        public Category(string name, string parentCategory, string option)
        {
             this.Name = name;
             this.ParentCategory = parentCategory;
             this.Option = option;
        }
    }
}
