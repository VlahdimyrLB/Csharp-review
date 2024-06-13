using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Movie
    {
        /*
         * public - can be accessed anywhere
         * private - can only be accessed within this class
         */
       
        public string title;
        public string director;
        private string rating; // close of the access

        public Movie(string aTitle, string aDirector, string aRating)
        {
            title = aTitle;
            director = aDirector;
            Rating = aRating; // sets rating through the Rating setter
        }

        // GET-SET - use to have access to private attributes
        public string Rating
        {
            // get - to get the attribute we want
            get 
            { 
                return rating; 
            }

            // set the rating
            // we can set rules for future modifications
            set 
            {
                // value is whatever is passed in
                if (value == "G" || value == "PG" || value == "PG-13" || value == "R" || value == "NR") 
                {
                    rating = value;
                } else
                {
                    rating = "NR"; // set to NR by default
                }
            }
        }
    }
}
