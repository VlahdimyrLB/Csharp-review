using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Song
    {
        public string title;
        public string artist;
        public int duration;

        // static attribute = attribute that isnt unique to each of the object
        // its specific to class itself, not the object
        // use the static keyword
        public static int songCount = 0;

        public Song(string aTitle, string aArtist, int aDuration) 
        { 
            title = aTitle;
            artist = aArtist;
            duration = aDuration;

            songCount++; // every song object is created, songCount gets incremented
        }

        public int getSongCount()
        {
            return songCount;
        }

        
    }
}
