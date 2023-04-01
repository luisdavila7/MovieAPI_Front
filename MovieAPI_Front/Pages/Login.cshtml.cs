using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieAPI_Front.Models;
using Newtonsoft.Json.Linq;

namespace MovieAPI_Front.Pages
{
    public class LoginModel : PageModel {

        [BindProperty]
        public User User { get; set; }

        public List<User> Users = new List<User>();
        private readonly HttpClient _httpClient;

        public string ErrorMessage { get; set; }
        public LoginModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> OnGet(string Error)
        {
            if (Request.Cookies["LoggedEmail"] != null)
            {
                return RedirectToPage("Index");
            }
            if (Error != null)
            {
                ErrorMessage = Error;
            }
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            var response = await _httpClient.GetAsync("https://localhost:7003/api/Users/Get");
            var values = await response.Content.ReadAsStringAsync();
            var obj = JObject.Parse(values);

            foreach (var item in obj["users"])
            {
                Users.Add(new User(item["email"].ToString(), item["password"].ToString(), item["name"].ToString()));
            }

            var currentUser = Users.FirstOrDefault(x => x.Email == User.Email && x.Password == User.Password);

            if (currentUser != null)
            {
                Response.Cookies.Append("LoggedEmail", currentUser.Email);
                Response.Cookies.Append("LoggedName", currentUser.Name);

                return RedirectToPage("/Index");
            }

            return RedirectToPage("/Login", new { Error = "Invalid Login!" });
        }

    }
}
