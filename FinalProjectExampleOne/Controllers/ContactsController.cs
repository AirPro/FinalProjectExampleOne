using FinalProjectExampleOne.Data;
using FinalProjectExampleOne.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FinalProjectExampleOne.Controllers
{
    [ApiController]
    [Route("api/contacts")] // can change api/contacts to api/[controller]
    public class ContactsController : Controller
    {
        private readonly ContactsAPIDBContext dbContext;
        public ContactsController(ContactsAPIDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Return All Contacts
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            return Ok(await dbContext.Contacts.ToListAsync());
        }

        // Return a Single Contact
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetContact([FromRoute] Guid id)
        {
            var contact = await dbContext.Contacts.FindAsync(id);

            if (contact == null) { return NotFound(); }

            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(AddContactRequest addContactRequest)
        {
            var contact = new Contact()
            {
                Id = Guid.NewGuid(),
                FullName = addContactRequest.FullName,
                Birthdate = addContactRequest.Birthdate,
                CollegeProgram = addContactRequest.CollegeProgram,
                YearInProgram = addContactRequest.YearInProgram,
            };

            await dbContext.Contacts.AddAsync(contact);
            await dbContext.SaveChangesAsync();

            return Ok(contact);
        }

        [HttpPut]
        [Route("{id:guid}")]

        public async Task<IActionResult> UpdateContact([FromRoute] Guid id, UpdateContactRequest updateContactRequest)
        {
            var contact = await dbContext.Contacts.FindAsync(id);

            if (contact != null)
            {
                contact.FullName = updateContactRequest.FullName;
                contact.Birthdate = updateContactRequest.Birthdate;
                contact.CollegeProgram = updateContactRequest.CollegeProgram;
                contact.YearInProgram = updateContactRequest.YearInProgram;

                await dbContext.SaveChangesAsync();

                return Ok(contact);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
        {
            var contact = await dbContext.Contacts.FindAsync(id);

            if (contact != null) 
            { 
                dbContext.Remove(contact);
                await dbContext.SaveChangesAsync();
                return Ok(contact);
            }
            return NotFound();
        }
    }
}
