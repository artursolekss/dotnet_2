using Microsoft.AspNetCore.Mvc;
using MyFirstWebApp.Models;

namespace MyFirstWebApp.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index(PersonModel personModel)
        {


            string welcomeString = "";
            if (personModel.Name != "" && personModel.Surname != ""
                && personModel.Name != null && personModel.Surname != null)
            {
                welcomeString = "Welcome " + personModel.Name + " " + personModel.Surname + "!";
                personModel.OpenConnection();
                personModel.AddToDatabase();
            }

            this.ViewData["listOfPersons"] = personModel.GetPersons();
            this.ViewData["welcomeStr"] = welcomeString;
            return this.View();
        }
    }
}
