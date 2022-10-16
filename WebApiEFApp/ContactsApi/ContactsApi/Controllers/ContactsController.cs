using ContactsApi.Data;
using ContactsApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactsApi.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactsController : Controller
    {
        public readonly ContactApiDbContext dbContext;
        public ContactsController(ContactApiDbContext dbcontext)
        {
            this.dbContext = dbcontext;
        }
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
         return Ok(await dbContext.Contacts.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(AddContactRequest addContactRequest)
        {
            var contact = new Contact()
            {
                Id = Guid.NewGuid(),
                Address = addContactRequest.Address,
                Email = addContactRequest.Email,
                FullName = addContactRequest.FullName,
                Phone = addContactRequest.Phone
            };

            await dbContext.Contacts.AddAsync(contact);
            await dbContext.SaveChangesAsync();
            return Ok(contact);
        }
    }
}
