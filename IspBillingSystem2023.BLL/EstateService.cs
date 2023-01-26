using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IspBillingSystem2023.DAL.Entities;
using IspBillingSystem2023.DAL.Repositories;
namespace IspBillingSystem2023.BLL

{
    internal class EstateService
    {
        private readonly EstateRepository _database;
        public EstateService(EstateRepository database)
        {
            _database = database;
        }

        public bool Create(string address, int serviceNumber, decimal total, int subjectId)
        {
            Estate estate = new Estate()
            {
                Address = address,
                ServiceNumber = serviceNumber,
                Total = total,
                SubjectId = subjectId
            };

            return _database.Add(estate);
        }

        public Estate GetById(int id)
        {
            return _database.GetById(id);
        }

        public List<Estate> GetAll()
        {
            return _database.GetAll();
        }

        public bool Update(int id, string address, int serviceNumber, decimal total, int subjectId)
        {
            if (_database.GetById(id) != null)
            {
                Estate estate = new Estate()
                {
                    Id = id,
                    Address = address,
                    ServiceNumber = serviceNumber,
                    Total = total,
                    SubjectId = subjectId
                };

                return _database.Edit(estate);
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            return _database.Delete(id);
        }
    }
}
