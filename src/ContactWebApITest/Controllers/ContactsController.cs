using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContactWebApITest.Models;
using Microsoft.AspNetCore.Cors;

namespace ContactWebApITest.Controllers
{
    [Route("api/[controller]")]

    public class ContactsController : Controller
    {

        private IContactsService _contact;
        public ContactsController(IContactsService contact)
        {
            _contact = contact;
        }

        // GET api/values
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            try
            {
                return Json(_contact.GetAll());

            }
            catch (Exception ex)
            {

                return Json("noall");

                throw ex; //handle by elmah

            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id) //called by angulat js
        {
            try
            {
                return Json(_contact.GetAll().Where(x => x.Id == id));

            }
            catch (Exception ex)
            {

                return Json("noid");

                throw ex; //handle by elmah

            }
        }


     
    }

}
