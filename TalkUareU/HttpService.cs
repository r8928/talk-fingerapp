using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;

namespace TalkUareU
{
    internal class HttpService
    {
        public static string token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJkaXNwbGF5X25hbWUiOiJSYXNoaWQiLCJyb2xlIjoxLCJsb2NhdGlvbiI6MSwic3ViIjoxMDIyLCJpc3MiOiJodHRwczovL2Rldi50YWxrbW9iaWxlbmV0LmNvbS9hcGkvdjEvc2lnbmluIiwiaWF0IjoxNTc2MDIwNjI1LCJleHAiOjE1NzYwODU0MjUsIm5iZiI6MTU3NjAyMDYyNSwianRpIjoiQjFmQ1N5N1BkVlpycGVXaSJ9.D1LOljKLveSx8jf7ms-rieu_tJ5vfVxrqVy_7HVz1Oc";
        private string API_ENDPOINT = "https://dev.talkmobilenet.com/api/v1/";

        public HttpResponse get(string url)
        {

            var request = (HttpWebRequest)WebRequest.Create(createURL(url));
            request.Method = "GET";

            return GetResponse(request);

        }

        public HttpResponse post(string url, string json)
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(createURL(url));
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                //streamWriter.Write(jsonStringify(json));

                json = json.Replace("'", "\"");

                //json = jsonStringify(jsonParse(json));
                //System.Windows.Forms.MessageBox.Show(json);

                streamWriter.Write(json);
            }

            return GetResponse(httpWebRequest);
        }

        public HttpResponse GetResponse(HttpWebRequest request)
        {
            try
            {
                HttpWebResponse htResp = (HttpWebResponse)request.GetResponse();

                string StatusCode = JsonConvert.SerializeObject(htResp.StatusCode);

                StreamReader sr = new StreamReader(htResp.GetResponseStream());

                return new HttpResponse(sr.ReadToEnd(), StatusCode);

            }
            catch (WebException e)
            {
                if (e.Response != null)
                {

                    string StatusCode = JsonConvert.SerializeObject(e.Status);

                    string error = "";
                    using (var errorResponse = (HttpWebResponse)e.Response)
                    {
                        using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                        {
                            error = reader.ReadToEnd();
                        }
                    }

                    return new HttpResponse(error, e.Status.ToString() + " " + StatusCode);

                }
            }
            return new HttpResponse("", "");

        }

        private string createURL(string url)
        {
            string token_delim = "?";
            if (url.Contains("?"))
            {
                token_delim = "&";
            }

            return API_ENDPOINT + url + token_delim + "token=" + HttpService.token;
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

        public JObject jsonParse(string str)
        {
            return JObject.Parse(str);
        }

        public string jsonStringify(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

    }

    internal class HttpResponse
    {
        public HttpResponse(string httpresp, string statuscode)
        {
            //System.Int32.TryParse(statuscode, out code);

            try
            {
                if (httpresp.Length > 0)
                {

                    if (statuscode == "200")
                    {
                        if(resp.Contains("<title>Welcome To Talk Mobile</title>"))
                        {
                            httpresp = "404";
                            statuscode = "404";
                        }
                        else
                        {
                        ok = true;
                        }
                    }

                    json = JObject.Parse(httpresp);
                    if (json.HasValues)
                    {
                        hasJson = true;
                    }
                }
            }
            catch (System.Exception) { }
        }

        public string resp { get; } = "";
        public string code { get; } = "";
        public JObject json { get; } = null;
        public bool ok { get; } = false;
        public bool hasJson { get; } = false;

    }
}