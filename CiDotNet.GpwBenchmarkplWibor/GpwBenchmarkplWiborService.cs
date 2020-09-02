using CiDotNet.Calc.Wibor;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CiDotNet.GpwBenchmarkplWibor
{
    public class GpwBenchmarkplWiborService : IXiborService
    {
        private const string GpWBenchmarkUrl = "https://gpwbenchmark.pl";
        public decimal ProvideInterbankOfferedRate3M()
        {
            var web = new HtmlWeb();
            var doc = web.Load(GpWBenchmarkUrl);
            var node = doc.DocumentNode.SelectSingleNode("//div[@class='wibor-lg']");
            var m3TableNode = node?.SelectSingleNode("//td[contains(text(),'3M')]")?.ParentNode;
            var interestRateText = m3TableNode?.SelectSingleNode("td[3]")?.InnerText;
            if(!string.IsNullOrEmpty(interestRateText))
            {
                interestRateText = interestRateText.Substring(0, interestRateText.IndexOf('%')).Replace(',','.');
            }
            else
            {
                throw new NullReferenceException("Wibor 3m interest rate not found on gpwbenchmark.pl!");
            }
            return decimal.Parse(interestRateText,CultureInfo.InvariantCulture);
        }
    }
}
