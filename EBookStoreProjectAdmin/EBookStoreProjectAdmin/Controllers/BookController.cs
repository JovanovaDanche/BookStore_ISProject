using Microsoft.AspNetCore.Mvc;
using ExcelDataReader;
using Newtonsoft.Json;
using System.Text;
using EBookStoreProjectAdmin.Models;
using System.Net.Http;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EBookStoreProjectAdmin.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ImportBooks(IFormFile file) //imeto na ovaa promenliva treba da e како во Index.cshtml за User
        {
            // make a copy
            string pathToUpload = $"{Directory.GetCurrentDirectory()}\\files\\{file.FileName}";

            using (FileStream fileStream = System.IO.File.Create(pathToUpload))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            //read from file
            List<Book> books = getAllBooksFromFile(file.FileName);

            HttpClient client = new HttpClient();
            string URL = "https://localhost:7052/api/Admin/ImportAllBooks";

            HttpContent content = new StringContent(JsonConvert.SerializeObject(books), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(URL, content).Result;

            var data = response.Content.ReadAsStringAsync().Result;
            return RedirectToAction("Index", "Order");
        }

        private List<Book> getAllBooksFromFile(string fileName)
        {
            List<Book> books = new List<Book>();
            string filePath = $"{Directory.GetCurrentDirectory()}\\files\\{fileName}";
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        string authorFirstName = reader.GetValue(8)?.ToString()?.Split(' ')[0];
                        string authorLastName = reader.GetValue(8)?.ToString()?.Split(' ')[1];
                        string publisherName = reader.GetValue(7)?.ToString();

                        // Directly add the book without checking if author or publisher exist
                        books.Add(new Book
                        {
                            Title = reader.GetValue(0).ToString(),
                            BookCover = reader.GetValue(1).ToString(),
                            Description = reader.GetValue(2).ToString(),
                            Rating = Convert.ToDouble(reader.GetValue(3)),
                            Genre = reader.GetValue(4).ToString(),
                            QuantityAvaiable = Convert.ToInt32(reader.GetValue(5)),
                            Price = Convert.ToDouble(reader.GetValue(6)),
                            Publisher = new Publisher { Name = publisherName },
                            Author = new Author { Name = authorFirstName, Surname = authorLastName }
                        });
                    }
                }
            }
            return books;
        }
    }
}
