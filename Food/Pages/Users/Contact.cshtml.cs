using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Food.Repositories;
using Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace Foodie.Pages.Users
{
	[Authorize(Roles = "User")]
	public class ContactModel : PageModel
    {
        private readonly IContactRepository _contactRepository;

        public ContactModel(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [BindProperty]
        public Contact Contact { get; set; }
        public string Message { get; set; }
        public string MessageClass { get; set; }
        public string NameError { get; set; }
        public string EmailError { get; set; }
        public string SubjectError { get; set; }
        public string MessageError { get; set; }

        public void OnGet()
        {
            // Initializes the Contact object if needed
            Contact = new Contact();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Validate the model
            if (ModelState.IsValid)
            {
                try
                {
                    // Adding new contact message to the database
                    await _contactRepository.Add(Contact);

                    // Set success message
                    Message = "Thanks for reaching out! We will look into your query.";
                    MessageClass = "alert alert-success";

                    // Clear the form after successful submission
                    Contact = new Contact();
                }
                catch (Exception ex)
                {
                    // Error handling
                    Message = $"Error: {ex.Message}";
                    MessageClass = "alert alert-danger";
                }
            }
            else
            {
                // If validation fails, set error messages
                NameError = ModelState["Contact.Name"]?.Errors[0]?.ErrorMessage;
                EmailError = ModelState["Contact.Email"]?.Errors[0]?.ErrorMessage;
                SubjectError = ModelState["Contact.Subject"]?.Errors[0]?.ErrorMessage;
                MessageError = ModelState["Contact.Message"]?.Errors[0]?.ErrorMessage;
            }

            return Page();
        }
    }
}
