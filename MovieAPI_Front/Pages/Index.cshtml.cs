using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieAPI_Front.Models;

namespace MovieAPI_Front.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }

        public List<User> Users = new List<User>();
        private readonly HttpClient _httpClient;

        public IndexModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult OnGet()
        {
            Users = Users.ToList();

            var loggedEmail = Request.Cookies["LoggedEmail"];
            var loggedName = Request.Cookies["LoggedName"];

            if (loggedEmail == null)
            {
                return RedirectToPage("/Login", new { Error = "You have to login!" });
            }
            return Page();
        }

        public IActionResult OnPostLogout()
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(-1);

            Response.Cookies.Append("LoggedEmail", "", options);
            Response.Cookies.Append("LoggedName", "", options);

            return RedirectToPage("/Index");
        }



    }
}