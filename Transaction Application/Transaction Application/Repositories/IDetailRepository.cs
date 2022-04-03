using System.Collections.Generic;
using Transaction_Application.Models;

namespace Transaction_Application.Repositories
{
    public interface IDetailRepository
    {
        // Virtual function to add a row to a table Transaction
        public void AddDetail(Transaction transaction);

        // Virtual function to delete all rows from table Transaction
        public void DeleteAll();

        // Virtual function to delete a row having a specific id from table Transaction
        public void DeleteDetailById(int id);

        // Virtual function to fetch a row having a specific id from table Transaction
        public Transaction GetDetailById(int id);

        // Virtual function to fetch all rows from table Transaction
        public List<Transaction> GetDetails();

        // Virtual function to update a specific row having a specific id form table Transaction
        public void UpdateDetail(Transaction transaction);
    }
}
