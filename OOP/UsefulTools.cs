using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    // static class - now we cant be able to instatiate this class // or create instance of UsefulTools
    static class UsefulTools
    {
        public static void SayHi(string name)
        {
            Console.WriteLine("Hi" + name);
        }
    }
}
