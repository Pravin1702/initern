using ExcelReaderWeb.Models;
using Microsoft.AspNetCore.Mvc;
using ExcelDataReader;

namespace ExcelReaderWeb.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View(new List<UserModel>());
        }
        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            List<UserModel> users = new List<UserModel>();
            var fileName = "./Data.xlsx";
          
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {

                    while (reader.Read()) //Each row of the file
                    {
                        users.Add(new UserModel
                        {
                            Id = reader.GetValue(0).ToString(),
                            Region = reader.GetValue(1).ToString(),
                            Reg = reader.GetValue(2).ToString(),
                            Item = reader.GetValue(3).ToString(),
                            Units = reader.GetValue(4).ToString()
                        });
                    }
                }
            }
            return View(users);
        }

    }
}