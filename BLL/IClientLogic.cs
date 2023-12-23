using Entities;
using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace BLL
{
    public interface IClientLogic
    {
        void AddCD(string name);
        void RemoveCD(string name);
        void AddSong(string cdName, string title, string artist);
        void RemoveSong(string cdName, string title, string artist);
        List<CD> PrintCatalog();
        CD PrintCD(string name);
        List<Song> FindSongsByArtist(string artist);
        void SortSongs(string cdName, string sortBy);
        void SaveBaseCatalog();
    }
}
