using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContactWebApITest.Models;
using Microsoft.Extensions.Logging;
using ContactWebApITest.Logging;

namespace ContactWebApITest.Controllers
{
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private IContactsService _contact;
        private readonly ILogger<ContactsController> _logger;


        public ContactsController(IContactsService contact, ILogger<ContactsController> logger)
        {
            _contact = contact;
            _logger = logger;
        }
        // GET api/values
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            try
            {
                _logger.LogInformation(LoggingEvents.LIST_ITEMS, "Listing all contacts");

                return Json(_contact.GetAll());

            }
            catch (Exception ex)
            {
                _logger.LogInformation(LoggingEvents.GET_ITEM_NOTFOUND, "all contacts not found");

                return Json("");

                throw ex; //handle by elmah

            }
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id) 
        {
            try
            {
                _logger.LogInformation(LoggingEvents.LIST_ITEMS, "List each name");

                return Json(_contact.GetAll().Where(x => x.Id == id));

            }
            catch (Exception ex)
            {
                _logger.LogInformation(LoggingEvents.GET_ITEM_NOTFOUND, "name not found");
                return Json("");

                throw ex; //handle by elmah

            }
        }


    


    }


}
