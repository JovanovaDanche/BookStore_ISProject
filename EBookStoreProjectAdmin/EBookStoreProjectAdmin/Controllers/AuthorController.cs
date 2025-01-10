using ExcelDataReader;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using EBookStoreProjectAdmin.Models;

namespace EBookStoreProjectAdmin.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ImportAuthors(IFormFile file) //imeto na ovaa promenliva treba da e kako u Index.cshtml za User
        {
            //make a copy
            string pathToUpload = $"{Directory.GetCurrentDirectory()}\\files\\{file.FileName}";

            using (FileStream fileStream = System.IO.File.Create(pathToUpload))
            {
                file.CopyTo(fileStream); ;
                fileStream.Flush();
            }
            //read from file

            List<Author> authors = getAllAuthorsFromFile(file.FileName);

            HttpClient client = new HttpClient();
            string URL = "https://localhost:7052/api/Admin/ImportAllAuthors";

            HttpContent content = new StringContent(JsonConvert.SerializeObject(authors), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(URL, content).Result;

            var data = response.Content.ReadAsAsync<bool>().Result;
            return RedirectToAction("Index", "Order");

        }
        private List<Author> getAllAuthorsFromFile(string fileName)
        {
            List<Author> authors = new List<Author>();
            string filePath = $"{Directory.GetCurrentDirectory()}\\files\\{fileName}";
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
            {

                //za excelReader simnuvame paket ExcelDataReader
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        authors.Add(new Author
                        {
                            Name = reader.GetValue(0).ToString(),
                            Surname = reader.GetValue(1).ToString(),
                            AuthorImage = reader.GetValue(2).ToString(),
                            Biography = reader.GetValue(3).ToString()
                        });

                    }
                }
            }
            return authors;
        }
    }
}
