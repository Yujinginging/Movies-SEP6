using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace AzureFunction
{
    public static class GetMovieInfos
    {
        [FunctionName("GetObjFromApi")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            
            string name = req.Query["title"];
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.omdbapi.com/?t=" + name + "&apikey=9d4b7fd4");
            request.Method = "GET";
            request.ContentType = "application/json:charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.GetEncoding("utf-8"));

            string json = reader.ReadToEnd();

            reader.Close();
            stream.Close();
            response.Close();


           
            return new OkObjectResult(json);
        }
    }
}
