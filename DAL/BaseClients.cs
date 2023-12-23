using Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace DAL
{
    public class BaseClients : IBaseClients
    {
        MusicCatalog catalog = new MusicCatalog();

        public BaseClients() //конструктор класса
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream f = new FileStream("data.dat", FileMode.OpenOrCreate);
            if (f.Length == 0) //файл пуст, создаю новую базу
            {
                catalog = new MusicCatalog();
            }
            else // иначе выполняю дисериализацию
            {
                catalog = (MusicCatalog)formatter.Deserialize(f);
            }
            f.Close();
        }

        ~BaseClients()
        {
            SaveBaseCatalog();
        }

        public void AddCD(string name) //добавление нового CD
        {
            catalog.AddCD(name);
        }
        public void RemoveCD(string name) //удаление  CD
        {
            catalog.RemoveCD(name);
        }

        public void AddSong(string cdName, string title, string artist) //добавление новой песни
        {
            catalog.AddSong(cdName, title, artist);
        }

        public void RemoveSong(string cdName, string title, string artist) //добавление новой песни
        {
            catalog.RemoveSong(cdName, title, artist);
        }
        public List<CD> PrintCatalog()
        {
            return catalog.PrintCatalog();
        }

        public CD PrintCD(string name)
        {
            return catalog.PrintCD(name);
        }

        public List<Song> FindSongsByArtist(string artist)
        {
            return catalog.FindSongsByArtist(artist);
        }

        public void SortSongs(string cdName, string sortBy)
        {
            catalog.SortSongs(cdName, sortBy);
        }

        public void SaveBaseCatalog()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream f = new FileStream("data.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(f, catalog);
            }
        }

    }
}