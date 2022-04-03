using System;
using System.Collections.Generic;
using Transaction_Application.Models;
using Transaction_Application.Repositories;

namespace Transaction_Application.Services
{
    public class DetailService : IDetailService
    {
        private readonly IDetailRepository repository;
        public DetailService(IDetailRepository detailRepository)
        {
            repository = detailRepository;
        }


        // Function to add a row to a table Transaction
        public void AddDetail(Transaction transaction)
        {
            // Checking whether the primary key is not defined by the user
            if (transaction.Id != 0)
            {
                // Throwing a new SystemException
                throw new SystemException();
            }                

            // Adding the detail to table Transaction
            repository.AddDetail(transaction);
        }


        // Function to delete all rows from table Transaction
        public void DeleteAll()
        {
            repository.DeleteAll();
        }

        
        // Function to delete row having a specific id from table Transaction
        public void DeleteDetailById(int id)
        {
            try
            {
                // Checking whether the row having a specific id exists
                var data = repository.GetDetailById(id);

                if(data != null)
                {
                    // Deleting the row having a specific id
                    repository.DeleteDetailById(id);
                }
            }
            catch
            {
                // Throwning a new SystemException
                throw new SystemException();
            }
        }

        
        // Function to fetch a row having a specific id from table Transaction
        public Transaction GetDetailById(int id)
        {
            return repository.GetDetailById(id);
        }

        
        // Function to fetch all rows from table Transaction
        public List<Transaction> GetDetails()
        {
            return repository.GetDetails();
        }


        // Function to update a row from table Transaction having a specific id
        public void UpdateDetail(Transaction transaction)
        {
            try
            {
                // Check whether row having the desired id exists
                var data = repository.GetDetailById(transaction.Id);

                if(data != null)
                {
                    // Updating the row having the desired id
                    repository.UpdateDetail(transaction);
                }                   
            }
            catch
            {
                // Throwing a new SystemException
                throw new SystemException();
            }   
        }
    }
}
