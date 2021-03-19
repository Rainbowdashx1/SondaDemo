using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace SondaDemo.Context
{
    public class ApiConnection
    {
        public string LinkApi(string Url, string _jsonInput, string Method, string TypeReturnError = "[]", string Content_Type = "application/json", int Timeout = 60)
        {
            try
            {
                string Sendmessage = _jsonInput;
                byte[] data = UTF8Encoding.UTF8.GetBytes(Sendmessage);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Timeout = (Timeout * 1000);
                request.Method = Method;
                request.ContentLength = data.Length;
                request.ContentType = Content_Type;
                Stream postStream = request.GetRequestStream();
                postStream.Write(data, 0, data.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string respuesta = reader.ReadToEnd();
                postStream.Dispose();
                response.Dispose();
                reader.Dispose();
                return respuesta;
            }
            catch (Exception ex)
            {
                if (TypeReturnError == "[]")
                    return "[]";
                else
                    return "{}";
            }
        }
    }
}
