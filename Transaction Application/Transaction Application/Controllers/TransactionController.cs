using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transaction_Application.Models;
using Transaction_Application.Services;

namespace Transaction_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IDetailService service;
        public TransactionController(IDetailService detailService)
        {
            service = detailService;
        }


        // Function to add data to table Transaction
        [HttpPost("AddDetail")]
        public IActionResult AddDetail([FromBody] Transaction transaction)
        {            
            try
            {
                service.AddDetail(transaction);
                return Ok(new { message = "The transaction detail is successfully saved into the database." });
            }
            catch
            {
                return BadRequest(new { message = "The system has thrown an exception. I guess the MySql Database is not operational or the property id is defined." });
            }
            
        }


        // Function to delete all rows from table Transaction
        [HttpDelete("DeleteAll")]
        public IActionResult DeleteAll()
        {
            try
            {
                service.DeleteAll();
                return Ok(new { message = "All the transaction details are deleted from the database successfully." });
            }
            catch
            {
                return BadRequest(new { message = "The system has thrown an exception. I guess the MySql Database is not operational." });
            }            
        }


        // Function to delete a row having a specific id from table Transaction
        [HttpDelete("DeleteDetailById/{id}")]
        public IActionResult DeleteDetailById(int id)
        {
            try
            {
                service.DeleteDetailById(id);
                return Ok(new { message = "The transaction detail has been deleted successfully from the database." });
            }
            catch
            {
                return BadRequest(new { message = "The system has thrown an exception. I guess the MySql Database is not operational or the detail does not exist." });
            }
        }


        // Function to fetch a specific row from table Transaction
        [HttpGet("GetDetailById/{id}")]
        public IActionResult GetDetailById(int id)
        {
            try
            {
                var transaction = service.GetDetailById(id);
                return Ok(transaction);
            }
            catch
            {
                return BadRequest(new { message = "The system has thrown an exception. I guess the MySql Database is not operational or the detail does not exist." });
            }
        }


        // Function to fetch all rows from table Transaction
        [HttpGet("GetDetails")]
        public IActionResult GetDetails()
        {
            try
            {
                var transactions = service.GetDetails();
                return Ok(transactions);
            }
            catch
            {
                return BadRequest(new { message = "The system has thrown an exception. I guess the MySql Database is not operational." });
            }
        }


        // Function to update a row having a specific id from table Transaction
        [HttpPut("UpdateDetail")]
        public IActionResult UpdateDetail([FromBody] Transaction transaction)
        {
            try
            {
                service.UpdateDetail(transaction);
                return Ok(new { message = "The transaction detail has been updated successfully." });
            }
            catch
            {
                return BadRequest(new { message = "The system has thrown an exception. I guess the MySql Database is not operational or the detail does not exist." });
            }
        }
    }
}
