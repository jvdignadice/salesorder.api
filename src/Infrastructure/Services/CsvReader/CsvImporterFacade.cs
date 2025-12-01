namespace Infrastructure.Services.CsvReader
{
    public class CsvImporterFacade
    {
        private readonly CsvTypeDetector _detector;
        private readonly ICsvImporterService _importer;

        public CsvImporterFacade(
            CsvTypeDetector detector,
            ICsvImporterService importer)
        {
            _detector = detector;
            _importer = importer;
        }

        public async Task ImportAutoAsync(Stream csvStream)
        {
            // Read only first line (header)
            using var reader = new StreamReader(csvStream, leaveOpen: true);

            var headerLine = await reader.ReadLineAsync();
            if (headerLine == null)
                throw new Exception("CSV header missing");

            var header = headerLine.Split(',')
                                   .Select(h => h.Trim())
                                   .ToArray();

            // Reset stream for actual processing
            csvStream.Position = 0;

            // Detect the entity type
            var type = _detector.DetectCsvType(header);

            if (type == null)
                throw new Exception("Unknown CSV format — no matching entity found.");

            // Call importer using reflection
            var method = typeof(ICsvImporterService)
                .GetMethod(nameof(ICsvImporterService.ImportAsync))
                !.MakeGenericMethod(type);

            await (Task)method.Invoke(_importer, new object[] { csvStream, 500 })!;
        }
    }
}
