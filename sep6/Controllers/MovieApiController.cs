using System;

using System.Net;
using System.IO;
using System.Text;

using sep6.Models;
using Nancy.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace sep6.Controllers
{
    public class Methods
    {
        //transfer json to object
        public static T FromJSON<T>(string jsonString)
        {
            JavaScriptSerializer json = new JavaScriptSerializer();
            return json.Deserialize<T>(jsonString);
        }
    }
    public class ToJson
    {
        //transfer object to json file 
        public static string ToJSON(Object obj)
        {
            String str;
            if (obj is String || obj is Char)
            {
                str = obj.ToString();
            }
            else
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                str = serializer.Serialize(obj);
            }
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
            return str;
        }

    }

    [Route("[controller]")]
    [ApiController]
    public class MovieApiController: ControllerBase
    {
        public Array[] topTen;
        private readonly ILogger<MovieApiController> _logger;
        public MovieApiController(ILogger<MovieApiController> logger)
        {
            _logger = logger;
        }

        //1.1. GET: api/Movies/GetObjFromApi/?Title=
        [HttpGet("GetObjFromApi")]
        public string GetObjFromApi(string title)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.omdbapi.com/?t=" + title + "&apikey=9d4b7fd4");
            request.Method = "GET";
            request.ContentType = "application/json:charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.GetEncoding("utf-8"));

            string json = reader.ReadToEnd();

            reader.Close();
            stream.Close();
            response.Close();

            
            return json;
        }
        [HttpGet("GetImg")]
        public string GetImg(string title)
        {
            string json = GetObjFromApi(title);
            Rootobject obj = new Rootobject();

            Rootobject result = (Rootobject)Methods.FromJSON<Rootobject>(json);

            HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(result.Poster);
            request2.Method = "GET";
            request2.ContentType = "application/json:charset=UTF-8";

            HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
            Stream stream2 = response2.GetResponseStream();
            StreamReader reader2 = new StreamReader(stream2, Encoding.GetEncoding("utf-8"));

            string json2 = reader2.ReadToEnd();


            return json2;

        }
        [HttpPost("UpdateTopTenList")]
        public void UpdateTopTenList(Array[] topList)
        {
            topTen = topList;
        }

        [HttpGet("GetTopTenList")]
        public Array[] GetTopTenList()
        {
            return topTen;
        }
        /*[HttpGet("Test")]
        public string Test(string title)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.omdbapi.com/?t="+title +  "&apikey=9d4b7fd4");
            request.Method = "GET";
            request.ContentType = "application/json:charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.GetEncoding("utf-8"));

            string json = reader.ReadToEnd();

            reader.Close();
            stream.Close();
            response.Close();
            return json;
        }*/

    }
}
