namespace Infrastructure.Services.CsvReader
{
    public class CsvTypeDetector
    {
        public Type? DetectCsvType(string[] csvHeader)
        {
            foreach (var kv in CsvHeaderRegistry.Headers)
            {
                var expected = kv.Value;

                if (HeadersMatch(csvHeader, expected))
                    return kv.Key;
            }

            return null;
        }

        private bool HeadersMatch(string[] actual, string[] expected)
        {
            return expected.All(e =>
                actual.Contains(e, StringComparer.OrdinalIgnoreCase));
        }
    }

}
