using Music.DataLayer.Contracts;
using domain= Music.Domain.Models;
using System;
using System.Collections.Generic;
namespace Music.DataLayer
{
    public class SongsDBFirstRepo : ISongsRepository
    {


        public domain.Song Create(domain.Song song)
        {
            throw new NotImplementedException();
        }

        public bool Delete(domain.Song song)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<domain.Song> GetAll(int skip = 0, int take = 100)
        {
            throw new NotImplementedException();
        }

        public domain.Song GetById(int id)
        {
            throw new NotImplementedException();
        }

        public domain.Song Update(domain.Song song)
        {
            throw new NotImplementedException();
        }
    }
}
