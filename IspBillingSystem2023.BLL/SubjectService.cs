using System;
using System.Collections.Generic;
using System.Net;
using IspBillingSystem2023.DAL.Entities;
using IspBillingSystem2023.DAL.Repositories;


namespace IspBillingSystem2023.BLL
{
    public class SubjectService
    {
        private readonly SubjectRepository _database;
        public SubjectService(SubjectRepository database)
        {
            _database = database;
        }

        public bool Create(string name, string taxNumber, string address, bool isCompany)
        {
            Subject subject = new Subject()
            {
                Name = name,
                TaxNumber = taxNumber,
                Address = address,
                IsCompany = isCompany
            };

            return _database.Add(subject);
        }

        public Subject GetById(int id)
        {
            return _database.GetById(id);
        }

        public List<Subject> GetAll()
        {
            return _database.GetAll();
        }

        public bool Update(int id,string name, string taxNumber, string address, bool isCompany)
        {
            if(_database.GetById(id) != null)
            {
                Subject subject = new Subject()
                {
                    Id = id,
                    Name = name,
                    TaxNumber = taxNumber,
                    Address = address,
                    IsCompany = isCompany
                };

                return _database.Edit(subject);
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
