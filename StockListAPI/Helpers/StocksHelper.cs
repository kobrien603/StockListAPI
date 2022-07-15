using Newtonsoft.Json;
using System.Net;
using System.Reflection.PortableExecutable;

namespace StockListAPI.Helpers
{
    public class StocksHelper
    {
        public List<string> GetStockList()
        {
            List<string> stocks = new();

            try
            {
                WebClient client = new();
                Stream stream = client.OpenRead("http://ftp.nasdaqtrader.com/dynamic/SymDir/otherlisted.txt");
                StreamReader reader = new StreamReader(stream);

                if (reader != null)
                {
                    // parse each row into list
                    List<string> strContent = new();
                    while (!reader.EndOfStream)
                    {
                        strContent.Add(reader.ReadLine() ?? "");
                    }

                    if (strContent.Count > 0)
                    {
                        // remove first and last row bc it contains header and footer data we don't need
                        strContent.RemoveAt(0);
                        strContent.RemoveAt(strContent.Count - 1);

                        // parse list and grab all text before "|" - that is the stock code

                        foreach (string row in strContent)
                        {
                            var split = row.Split('|');
                            if (split.Length > 0)
                            {
                                stocks.Add(split[0]);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {

            }

            return stocks;
        }
    }
}
