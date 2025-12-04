using Application.Features.Interfaces;

namespace Infrastructure.Services.CsvReader
{
  
    public class CsvImporterFacade
    {
            private readonly CsvTypeDetector _detector;
            private readonly ICsvImporterService _importer;
            private readonly IHeaderService _headerService; 

            public CsvImporterFacade(
                CsvTypeDetector detector,
                ICsvImporterService importer,
                IHeaderService headerService)  
            {
                _detector = detector;
                _importer = importer;
                _headerService = headerService;
            }

            public async Task ImportAutoAsync(Stream csvStream)
            {
                using var reader = new StreamReader(csvStream, leaveOpen: true);

                var headerLine = await reader.ReadLineAsync();
                if (headerLine == null)
                    throw new Exception("CSV header missing");

                var header = headerLine.Split(',')
                                       .Select(h => h.Trim())
                                       .ToArray();

                csvStream.Position = 0;

                var type = _detector.DetectCsvType(header, _headerService);

                if (type == null)
                    throw new Exception("Unknown CSV format — no matching entity found.");

                var method = typeof(ICsvImporterService)
                    .GetMethod(nameof(ICsvImporterService.ImportAsync))
                    !.MakeGenericMethod(type);

                await (Task)method.Invoke(_importer, new object[] { csvStream, 500 })!;
            }
        }
}
