using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;

namespace TalkUareU
{
    public class HttpService
    {

        public static string token = "eyJkaXNwbGF5X25hbWUiOiJNb29qaWQiLCJyb2xlIjoxLCJsb2NhdGlvbiI6MSwic3ViIjo4NTEsImlzcyI6Imh0dHBzOi8vYm9vbS50YWxrbW9iaWxlbmV0LmNvbS9hcGkvdjEvc2lnbmluIiwiaWF0IjoxNTc2MTE3MTgzLCJleHAiOjE1NzYxODE5ODMsIm5iZiI6MTU3NjExNzE4MywianRpIjoibndpc0t6T2UzOGpmc1J3UCJ9";
        public static string hIdToken = "";

        public HelperClass hlp;
        public MessageClass msg;
        internal Properties.Settings p { get; set; }

#if DEBUG
        public static bool HttpDebuging = true;
#else
        public static bool HttpDebuging = false;
#endif

        public HttpResponse Get(string url)
        {

            var request = (HttpWebRequest)WebRequest.Create(createURL(url));
            request.Method = "GET";

            try
            {
                return GetResponse(request, url, "", request.Method);
            }
            catch (Exception)
            {
                return new HttpResponse("", "Connection Error");
            }

        }

        public HttpResponse Post(string url, string json)
        {

            var request = (HttpWebRequest)WebRequest.Create(createURL(url));
            request.ContentType = "application/json";
            request.Method = "POST";

            try
            {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    //streamWriter.Write(jsonStringify(json));

                    json = json.Replace("'", "\"");

                    //json = jsonStringify(jsonParse(json));
                    //System.Windows.Forms.MessageBox.Show(json);

                    streamWriter.Write(json);
                }

                return GetResponse(request, url, json, request.Method);
            }
            catch (Exception)
            {
                return new HttpResponse("", "Connection Error");
            }

        }

        public HttpResponse GetResponse(HttpWebRequest request, string url, string json, string method)
        {
            try
            {
                HttpWebResponse htResp = (HttpWebResponse)request.GetResponse();

                string StatusCode = JsonConvert.SerializeObject(htResp.StatusCode);

                StreamReader sr = new StreamReader(htResp.GetResponseStream());

                string response = sr.ReadToEnd();

                logResponse(url, json, response, StatusCode);
                return new HttpResponse(response, StatusCode);

            }
            catch (WebException e)
            {
                if (e.Response != null)
                {

                    string StatusCode = JsonConvert.SerializeObject(e.Status);

                    string response = "";
                    using (var errorResponse = (HttpWebResponse)e.Response)
                    {
                        using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                        {
                            response = reader.ReadToEnd();
                        }
                    }
                    StatusCode = e.Status.ToString() + " " + StatusCode;

                    logResponse(url, json, response, StatusCode);
                    return new HttpResponse(response, StatusCode);

                }
            }
            logResponse(url, json, "", "");
            return new HttpResponse("", "");
        }

        private string createURL(string url)
        {
            string token_delim = "?";
            if (url.Contains("?"))
            {
                token_delim = "&";
            }

            return p.API_ENDPOINT + url + token_delim + "token=" + token + "&hidtoken=" + hIdToken;
        }

        public void UploadNew(string actionUrl, string path, string token, string secret, string location, string role, string file)
        {

            //var client = new HttpClient();
            //var formData = new MultipartFormDataContent();

            //formData.Add(new StringContent(path), "path");
            //formData.Add(new StringContent(token), "token");
            //formData.Add(new StringContent(secret), "secret");
            //formData.Add(new StringContent(path), "path");
            //formData.Add(new StringContent(location), "location");
            //formData.Add(new StringContent(role), "role");

            //formData.Add(new ByteArrayContent(File.ReadAllBytes(file)), "file", Path.GetFileName(file));

            //Console.Write(formData.ToString());
            //var response = client.PostAsync(actionUrl, formData).Result;

            //client.Dispose();
            //Console.WriteLine(response.Content.ReadAsStringAsync().Result);

        }

        public bool WebCallCheck()
        {
            string StatusCode = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://google.com");
                request.Method = "GET";
                HttpWebResponse htResp = (HttpWebResponse)request.GetResponse();
                StatusCode = JsonConvert.SerializeObject(htResp.StatusCode);
            }
            catch (Exception) { }

            return StatusCode == "200";
        }

        private void logResponse(string url, string request, string response, string statuscode)
        {
            if (HttpDebuging == false)
            {
                return;
            }

            string outp =
                Environment.NewLine +
                "URL: " + url +
                Environment.NewLine +
                "Request: " + request +
                Environment.NewLine +
                "Status: " + statuscode +
                Environment.NewLine +
                "Response: " + response;

            hlp.log(outp);
        }

        public JObject jsonParse(string str)
        {
            return JObject.Parse(str);
        }

        public string jsonStringify(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /**
         * Standard error handling function
         */
        public void StdErr(HttpResponse res)
        {
            if (res.hasJson)
            {
                msg.warn((string)res.json["message"]);
            }
            else
            {
                msg.error("Unknown error");
            }
        }

    }

    public class HttpResponse
    {
        private MessageClass msg = new MessageClass();
        public HttpResponse(string httpresp, string statuscode)
        {

            resp = httpresp;
            code = statuscode;

            try
            {
                if (!String.IsNullOrEmpty(resp))
                {
                    if (resp.Contains("<title>Welcome To Talk Mobile</title>"))
                    {
                        resp = "404";
                        code = "404";
                    }
                    else if (resp.Equals("token_error"))
                    {
                        msg.error("App validation failed");
                    }
                    else if (code == "200")
                    {
                        ok = true;
                    }

                    json = JObject.Parse(resp);
                    if (json.HasValues)
                    {
                        hasJson = true;
                    }
                }
            }
            catch (Exception) { }

        }

        public string resp { get; } = "";
        public string code { get; } = "";
        public JObject json { get; } = null;
        public bool ok { get; } = false;
        public bool hasJson { get; } = false;

    }
}