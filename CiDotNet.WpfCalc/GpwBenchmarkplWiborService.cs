using CiDotNet.Calc.Wibor;
using System.Net;
using System.Text.RegularExpressions;

namespace CiDotNet.WpfCalc
{
    public class GpwBenchmarkplWiborService : IXiborService
    {
        public decimal ProvideInterbankOfferedRate3M()
        {
            using (var client = new WebClient())
            {
                // Get the HTML
                string result = client.DownloadString("https://gpwbenchmark.pl");

                // Get rid of whitespaces and newlines
                result = Regex.Replace(result, @"\s+", string.Empty);

                // Search Wibor3M
                var split = new Regex(@"ce]</td><tdclass=""mobile-1"">(.*?)%</td>").Split(result);

                // Parse string
                return decimal.Parse(split[1].Replace('.', ','));
            }
        }
    }
}
