using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnimalsParty.Repositories;
using AnimalsParty.Models;

namespace AnimalsParty.Services.EntityServices
{
    public class BaseService<T> where T : BaseModel, new()
    {
        private readonly BaseRepository<T> repository;
        public BaseService()
        {
            repository = new BaseRepository<T>();
        }

        public List<T> GetAll()
        {
            return repository.GetAll();
        }

        public T GetByID(int id)
        {
            return repository.GetByID(id);
        }

        public void Save(T item)
        {
            repository.Save(item);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}