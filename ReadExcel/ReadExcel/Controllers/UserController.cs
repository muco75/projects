using Microsoft.AspNetCore.Mvc;
using ReadExcel.Models;
using ExcelDataReader;

namespace ReadExcel.Controllers

{

    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<UserModel> users = GetUserData();
            return View(users);
        }
        private List<UserModel> GetUserData()
        {
            List<UserModel> users = new List<UserModel>();
            var fileName = "./SampleData.xlsx";                                                       /*  <<<<<<<------------- hier naam wijzigen van excel bestand*/
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        users.Add(new UserModel
                        {
                            Name = reader.GetValue(0).ToString(),
                            Imei = reader.GetValue(1).ToString(),
                            Brand = reader.GetValue(2).ToString(),
                            Model = reader.GetValue(3).ToString(),
                            StickerNumber = reader.GetValue(4).ToString(),
                        });
                    }
                }
            }
            return users;
        }

        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            List<UserModel> users = new List<UserModel>();
            var fileName = "./SampleData.xlsx";                                                                     /*  <<<<<<<------------- hier naam wijzigen van excel bestand*/

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {

                    while (reader.Read()) //Each ROW
                    {
                        users.Add(new UserModel
                        {
                            Name = reader.GetValue(0).ToString(),
                            Imei = reader.GetValue(1).ToString(),
                        });
                    }
                }
            }
            var searchItem = form["searchItem"].ToString();
            var filteredUsers = users.Where(u => u.Name.Contains(searchItem, StringComparison.OrdinalIgnoreCase)).ToList();


            return View(filteredUsers);
        }
    }

}