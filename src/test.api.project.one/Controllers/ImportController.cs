using Infrastructure.Services.CsvReader;
using Microsoft.AspNetCore.Mvc;

namespace test.api.project.one.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImportController : Controller
    {

        [HttpPost("import")]
        public async Task<IActionResult> ImportCsv(IFormFile file, [FromServices] CsvImporterFacade importer)
        {
            using var stream = file.OpenReadStream();
            await importer.ImportAutoAsync(stream);

            return Ok("CSV imported successfully!");
        }
       
    }
}
