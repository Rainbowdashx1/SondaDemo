using Newtonsoft.Json;
using SondaDemo.CrossCutting;
using SondaDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SondaDemo.Context
{
    public class MethodApi
    {
        ApiConnection AC;
        public MethodApi() 
        {
            AC = new ApiConnection();
        }

        public ResponseApi Login(Login L) 
        {
            ResponseApi resultado = JsonConvert.DeserializeObject<ResponseApi>(AC.LinkApi(ConfigClass.UrlApi + "api/RequestLogin", JsonConvert.SerializeObject(L), "POST", "{}"));
            return resultado;
        }
        public ResponseApi CreateUser(CreateUser CU)
        {
            ResponseApi resultado = JsonConvert.DeserializeObject<ResponseApi>(AC.LinkApi(ConfigClass.UrlApi + "api/RequestCreateUser", JsonConvert.SerializeObject(CU), "POST", "{}"));
            return resultado;
        }
    }
}
