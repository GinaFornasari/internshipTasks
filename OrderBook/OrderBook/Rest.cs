using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OrderBook
{
    public class Rest
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public event Action<string> MessageUpdated;
        public Func<string> GetSelectedItem { get; set; }
        public async Task getOrderBookRest()
        {
            string symbol = GetSelectedItem?.Invoke() ?? string.Empty;
            int depth = 25;
            string result = await MakeRestCall($"https://www.bitmex.com/api/v1/orderBook/L2?symbol={symbol}&depth={depth}");
            if (result.Equals(String.Empty))
            {
                log.Error("Could not get a rest resoponse");
                MessageUpdated?.Invoke("Error while getting response" + Environment.NewLine);
            }
            else
            {
                MessageUpdated?.Invoke(format(result));
            }
        }
        static async Task<string> MakeRestCall(string apiUrl)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        log.Error("Response status code not succesful");
                        log.Error($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Something went wrong while trying to make a REST call");
                log.Error(ex.ToString());
            }
            return null;
        }
        public string format(string result)
        {
            List<Order> orders = new List<Order>();
            try
            {
                orders = JsonConvert.DeserializeObject<List<Order>>(result);
            }
            catch (Exception ex)
            {
                log.Error("Unable to read JSON file");
                log.Error(ex.ToString());
                return result;
            }
            string res = "";
            foreach (Order order in orders)
            {
                res += order.getOrder() + Environment.NewLine;
            }
            return res;
        }
    }
}
