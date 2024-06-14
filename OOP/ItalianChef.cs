using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    // ItialianChef : Chef - means ItalianChef inherit all the functions in Chef class
    internal class ItalianChef : Chef
    {
        // italian chef can do all the things the Chef can do in Chef class
        // Chef class - super class
        // ItalianChef class - sub class, it inherits from super class


        public void MakePasta()
        {
            Console.WriteLine("Italian Chef make Pasta");
        }


        // we can override the MakeSpecialDish since Italian Chef has his own special dish
        // make sure that the inherited method is VIRTUAL in the super class
        // and use override here
        public override void MakeSpecialDish()
        {
            Console.WriteLine("Italian Chef make Carbonara (special dish)");
        }
    }
}
