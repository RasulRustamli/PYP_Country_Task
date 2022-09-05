using Newtonsoft.Json;
using PYP_Country_Task.Model;
using System.Net;


List<string> urls = new List<string>()
{
"http://country.io/names.json",
"http://country.io/phone.json",
"http://country.io/iso3.json",
"http://country.io/capital.json",
"http://country.io/currency.json",
"http://country.io/continent.json",
};


//HttpClient client=new HttpClient();
//var countryNames = await client.GetAsync("http://country.io/names.json");
//var countrynameStr = new WebClient().DownloadString(countryNames);



List<Country> countries = new List<Country>();

foreach (var url in urls)
{
    var response = new WebClient().DownloadString(url);
    var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);

    foreach (var item in data)
    {
        var country = countries.FirstOrDefault(x => x.Code == item.Key);
        if (country == null)
        {
            country = new Country();
            countries.Add(country);
        }

        if (url == urls[0])
        {
            country.Name = item.Value;
            country.Code = item.Key;


        }
        else if (url == urls[1])
        {
            country.Phone = item.Value;

        }
        else if (url == urls[2])
        {
            country.ISO = item.Value;

        }
        else if (url == urls[3])
        {
            country.Capital = item.Value;

        }
        else if (url == urls[4])
        {
            country.Currency = item.Value;

        }
        else if (url == urls[5])
        {
            country.Continent = item.Value;

        }
    }
}




Console.WriteLine("{0,-10}{1,-10}{2,-15}{3,-15}{4,-25}{5,-15}{6,-15}", "Phone", "ISO", "Capital", "Currency", "Continent", "Code", "Name");
Console.WriteLine("{0,-10}{1,-10}{2,-15}{3,-15}{4,-25}{5,-15}{6,-15}", "-------", "-----", "----------", "----------", "-----------------------", "----------", "----------");

int i = 0;
foreach (var item in countries)
{
    Console.WriteLine("{0,-10}{1,-10}{2,-15}{3,-15}{4,-25}{5,-15}{6,-15}", item.Phone, item.ISO, item.Capital, item.Currency, item.Continent, i, item.Name);
    
}

