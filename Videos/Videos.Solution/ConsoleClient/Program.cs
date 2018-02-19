using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml.Linq;

namespace ConsoleClient
{
	class Program
	{
		static void Main(string[] args)
		{
			var client = new HttpClient();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

			var response = client.GetAsync(new Uri(" http://localhost:50852/api/videos")).Result;

			if (response.IsSuccessStatusCode)
			{
				var doc = XDocument.Parse(response.Content.ReadAsStringAsync().Result);
				var ns = (XNamespace)"http://schemas.datacontract.org/2004/07/Videos.Web.Models";

				foreach (var title in doc.Descendants(ns + "Title"))
				{
					Console.WriteLine(title.Value);
				}
			}

			Console.ReadLine();
		}
	}
}
