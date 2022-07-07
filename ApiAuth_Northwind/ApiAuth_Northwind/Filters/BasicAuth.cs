using ApiAuth_Northwind.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ApiAuth_Northwind.Filters
{
    public class BasicAuth: AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null) //header bolumunde bir yetkilendirme var mi 
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "Yetkisiz Giris Yapilamaz!");
            }
            else
            {
                var authParameter = actionContext.Request.Headers.Authorization.Parameter; //Base64
                string decodeAuthParameter = Encoding.UTF8.GetString(Convert.FromBase64String(authParameter)); //firstname:lastname

                string[] firstnameAndlastnameArray = decodeAuthParameter.Split(':'); //2 index'li bir array olusur. 0'da admin, 1'de 1234 bulunur.

                string firstName = firstnameAndlastnameArray[0]; //userName'i 0. index'ten al
                string lastName = firstnameAndlastnameArray[1]; //password'u 1. index'ten al

                //Username burada string bir yapi.Yani metinsel. metinsel ifadelere izin tayin etme islemi dogrudan yapilamiyor. Bu nedenle kullanilan username'e bir identity atamasi yapilmasi gerekiyor. bu identity atandiktan sonra da ona bir rol tayin edilebilir.

                if (LoginCredentials.AnyUser(firstName, lastName))
                {
                    GenericIdentity identity = new GenericIdentity(firstName);
                    Thread.CurrentPrincipal = new GenericPrincipal(identity, null); //null kisminda kullanicinin rolu belirtilir. ornegin sadece admin giris yapabilsin isteniyorsa null yerine girisi kabul edilecek kullanicilarin rolleri belirtilir.

                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "Yetkisiz Giris Yapilamaz!");
                }
            }


            base.OnAuthorization(actionContext); //bu kisim otomatik geliyor. silinse de olur silinmese de.
        }
    }
}