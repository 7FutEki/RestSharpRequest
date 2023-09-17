using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi
{
    public class Metods
    {

        public List<Good> GetGoods(string host, string geturl)
        {
            var options = new RestClientOptions(host);
            var client = new RestClient(options);
            var request = new RestRequest(geturl);
            var response = client.Execute(request);
            List<Good> s = JsonConvert.DeserializeObject<List<Good>>(response.Content);
            return s;
        }


        public void PostGood(string host, string posturl, string token, Good good)
        {
            var options = new RestClientOptions(host);
            var client = new RestClient(options);
            var request = new RestRequest(posturl);
            var json = JsonConvert.SerializeObject(good);
            request.AddJsonBody(json);
            request.AddHeader("token", token);
            client.ExecutePost(request);
        }


        public void DeleteGood(string host, string deleteurl, string token, Guid guidGood)
        {
            var options = new RestClientOptions(host);
            var client = new RestClient(options);
            var request = new RestRequest(deleteurl);
            request.AddHeader("token", token);
            request.AddHeader("guidGood", guidGood);
            client.Delete(request);
        }

    }
}
