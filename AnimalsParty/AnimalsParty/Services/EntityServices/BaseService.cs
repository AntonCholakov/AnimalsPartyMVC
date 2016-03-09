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
        protected UnitOfWork unitOfWork;

        public BaseService()
        {
            this.unitOfWork = new UnitOfWork();
            repository = new BaseRepository<T>(this.unitOfWork);
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
            try
            {
                repository.Save(item);
                this.unitOfWork.Commit();
            }
            catch (Exception)
            {
                this.unitOfWork.RollBack();
            }
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}