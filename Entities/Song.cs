using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    [Serializable]
    public class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public Song(string title, string artist)
        {
            Title = title;
            Artist = artist;
        }
        public override string ToString()
        {
            return String.Format("- {0} ({1})", Title, Artist);
        }
    }
}
