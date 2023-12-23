using System;
using System.Collections;
using System.Collections.Generic;

namespace Entities
{
    [Serializable]
    public class MusicCatalog
    {
        public List<CD> CDs { get; set; }
        public MusicCatalog()
        {
            CDs = new List<CD>();
        }
        public void AddCD(string name)
        {
            CD cd = CDs.Find(c => c.Name == name);
            if (cd == null)
            {
                CDs.Add(new CD(name));
            }
            else
            {
                Console.WriteLine("Такой диск уже есть");
            }

        }
        public void RemoveCD(string name)
        {
            CD cd = CDs.Find(c => c.Name == name);
            if (cd != null)
            {
                for (int i = 0; i < cd.Songs.Count; i++)
                {
                    string title = cd.Songs[i].Title;
                    string artist = cd.Songs[i].Artist;
                    cd.Songs.RemoveAll(song => cd.Songs[i].Title == title && cd.Songs[i].Artist == artist);
                }
                CDs.RemoveAll(cd => (cd.Name == name));
            }
            else
            {
                Console.WriteLine("Такого диска не существует");
            }
        }
        public void AddSong(string cdName, string title, string artist)
        {
            CD cd = CDs.Find(c => c.Name == cdName);
            if (cd != null)
            {
                if (cd.Songs.Find(c => c.Title == title) == null)
                {
                    cd.Songs.Add(new Song(title, artist));
                }
                else
                {
                    Console.WriteLine("Такая песня уже есть");
                }
            }
            else
            {
                Console.WriteLine("Такого диска не существует");
            }
        }
        public void RemoveSong(string cdName, string title, string artist)
        {
            CD cd = CDs.Find(c => c.Name == cdName);
            if (cd != null)
            {
                if (cd.Songs.Find(c => c.Title == title) != null)
                {
                    if (cd.Songs.Find(c => c.Artist == artist) != null)
                    {
                        cd.Songs.RemoveAll(song => song.Title == title && song.Artist == artist);
                    }
                    else
                    {
                        Console.WriteLine("У этого автора нет такой песни");
                    }
                }
                else
                {
                    Console.WriteLine("Такой песни не существует");
                }
            }
            else
            {
                Console.WriteLine("Такого диска не существует");
            }
        }
        public List<CD> PrintCatalog()
        {
            //Console.WriteLine("Music catalog:");
            //foreach (CD cd in CDs)
            //{
            //    Console.WriteLine($"{cd.Name}:");
            //    foreach (Song song in cd.Songs)
            //    {
            //        Console.WriteLine($"- {song.Title} ({song.Artist})");
            //    }
            //}
            return CDs;
        }
        public CD PrintCD(string name)
        {
            //CD cd = CDs.Find(c => c.Name == name);
            //if (cd != null)
            //{
            //    Console.WriteLine($"{cd.Name}:");
            //    foreach (Song song in cd.Songs)
            //    {
            //        Console.WriteLine($"- {song.Title} ({song.Artist})");
            //    }
            //}
            CD cd = CDs.Find(c => c.Name == name);
            return cd;
        }
        public List<Song> FindSongsByArtist(string artist)
        {
            List<Song> result = new List<Song>();
            foreach (CD cd in CDs)
            {
                foreach (Song song in cd.Songs)
                {
                    if (song.Artist == artist)
                    {
                        result.Add(song);
                    }
                }
            }
            return result;
        }
        public CD SortSongs(string cdName, string sortBy)
        {
            CD cd = CDs.Find(c => c.Name == cdName);
            if (cd != null)
            {
                if (sortBy == "title")
                {
                    cd.Songs.Sort((s1, s2) => s1.Title.CompareTo(s2.Title));
                }
                else if (sortBy == "artist")
                {
                    cd.Songs.Sort((s1, s2) => s1.Artist.CompareTo(s2.Artist));
                }
            }
            else
            {
                Console.WriteLine("Такого диска не существует");
            }
            return cd;
        }

        public override string ToString()
        {
            string catalog = $"В каталоге : " + CDs.Count + " дисков";
            for (int i = 0; i < CDs.Count; i++)
            {
                catalog += Environment.NewLine + CDs[i].ToString();
            }
            return catalog;
        }
    }
}