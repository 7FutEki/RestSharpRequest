using Newtonsoft.Json;
using RestSharp;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using TestApi;

string host = "http://localhost:5000/Catalog/";
string token = "a7b25d781e794003b3e4e1e43fa34ded";
string urlget =  $"GetGoods?token={token}";
string urladd = "AddGood";
string urldelete = "DeleteGood";

Good good = new Good()
{
    idGood = Guid.NewGuid(),
    name = "testdelete",
    price = 0
};

Metods m = new Metods();
m.PostGood(host, urladd, token, good);
m.DeleteGood(host, urldelete, token, good.idGood);
List<Good> s = m.GetGoods(host, urlget);

foreach (var item in s)
{
    Console.WriteLine(item.idGood);
    Console.WriteLine(item.name);
    Console.WriteLine(item.price);
}

