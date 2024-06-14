using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Chef
    {
        public void MakeChicken()
        {
            Console.WriteLine("The Chef makes Chicken");
        }

        public void MakeSalad()
        {
            Console.WriteLine("The Chef makes Salad!");
        }

        // virtual is used to be overriden/overridable
        // basically the sub class can change the functionality of this method
        public virtual void MakeSpecialDish()
        {
            Console.WriteLine("The Chef makes BBQ Ribs (special dish)");
        }
    }
}
