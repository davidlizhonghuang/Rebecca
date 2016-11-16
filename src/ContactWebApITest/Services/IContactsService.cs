using System.Collections.Generic;

namespace ContactWebApITest.Models
{
    public interface IContactsService
    {
        List<Contact> GetAll();
    }
}