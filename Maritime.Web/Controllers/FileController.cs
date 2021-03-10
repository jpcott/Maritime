using Maritime.Library.Utilities.Interface;
using Maritime.Repository.Model;
using Maritime.Repository.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;

namespace Maritime.Web.Controllers
{
    public class FileController : Controller
    {
        private readonly IBatchRandomNumberRepository batchRandomNumberRepository;
        private readonly ICsvRowParser csvRowParser;

        public FileController(IBatchRandomNumberRepository batchRandomNumberRepository, ICsvRowParser csvRowParser)
        {
            this.batchRandomNumberRepository = batchRandomNumberRepository;
            this.csvRowParser = csvRowParser;
        }

        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (!reader.EndOfStream)
                {
                    var numbers = csvRowParser.ParseAsDouble(reader.ReadLine());
                    batchRandomNumberRepository.Save(numbers.Select(n => new RandomNumber() { Number = n }));
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
