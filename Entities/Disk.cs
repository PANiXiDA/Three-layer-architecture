using System;
using System.Collections;
using System.Collections.Generic;

namespace Entities
{
    [Serializable]
    public class CD
    {
        public string Name { get; set; }
        public List<Song> Songs { get; set; }
        public CD(string name)
        {
            Name = name;
            Songs = new List<Song>();
        }
        public override string ToString()
        {
            string CDs = $"В каталоге : " + Songs.Count + " дисков";
            for (int i = 0; i < Songs.Count; i++)
            {
                CDs += Environment.NewLine + Songs[i].ToString();
            }
            return CDs;
        }
    }
}