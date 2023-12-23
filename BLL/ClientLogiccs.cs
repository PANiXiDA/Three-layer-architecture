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
    public class ClientLogic : IClientLogic
    {
        private IBaseClients baseClients;

        public ClientLogic(IBaseClients baseClients)
        {
            this.baseClients = baseClients;
        }

        public void AddCD(string name)
        {
            baseClients.AddCD(name);

        }
        public void RemoveCD(string name) //удаление  CD
        {
            baseClients.RemoveCD(name);
        }

        public void AddSong(string cdName, string title, string artist) //добавление новой песни
        {
            baseClients.AddSong(cdName, title, artist);
        }

        public void RemoveSong(string cdName, string title, string artist) //добавление новой песни
        {
            baseClients.RemoveSong(cdName, title, artist);
        }
        public List<CD> PrintCatalog()
        {
            return baseClients.PrintCatalog();
        }

        public CD PrintCD(string name)
        {
            return baseClients.PrintCD(name);
        }

        public List<Song> FindSongsByArtist(string artist)
        {
            return baseClients.FindSongsByArtist(artist);
        }

        public void SortSongs(string cdName, string sortBy)
        {
            baseClients.SortSongs(cdName, sortBy);
        }

        public void SaveBaseCatalog()
        {
            baseClients.SaveBaseCatalog();
        }
    }
}
