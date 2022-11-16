using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Claims;

namespace LeadershipUI.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            //Verify the credential
            if (Credential.Username == "******" && Credential.Password == "******")
            {
                //Creating the security context
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, "******") };

                var identity = new ClaimsIdentity(claims, "******");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("******", claimsPrincipal);

                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
    public class Credential
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
