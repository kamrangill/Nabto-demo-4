using Foundation;
using Nabto.IOS.Wrapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nabto.iOS.Services
{
    public static class NabtoManager
    {
        public static NabtoClient Client;
        public static nabto_tunnel_t TunnelInstance;
        public static nabto_status_t isApiInitialized;
        public static nabto_status_t SessionStatus;
        public static string Email;
        public static string Password;
        public static nabto_status_t StartNabtoClient()
        {
             Client = new NabtoClient();
            isApiInitialized= Client.Startup;
            
            return isApiInitialized;
         
        }
        public static nabto_status_t OpenSession(string Email,string Password)
        {
            //Save Credentails locally
            NabtoManager.Email = Email;
            NabtoManager.Password = Password;

            //Open Session
            SessionStatus =  Client.OpenSession(Email, Password);

            return SessionStatus;
        }

        public static string CallQuery(string URL, string query_XMLData)
        {
            string JsonResponse = string.Empty;

            try
            {

                byte errorMessage = 0;
                var status = Client.RpcSetDefaultInterface(query_XMLData, ref errorMessage);




                if (status == nabto_status_t.Ok)
                {
                    IntPtr buff =IntPtr.Zero;
                    status = Client.RpcInvoke(URL, ref buff);
                   
                    //TO Do Get the Correct Lenght of Json From IntPtr
                 //Workround to get the Length of JsonResponse from Pointer.
                      int Length = ((byte)buff);
                  
                    if (Length<74)
                    {
                        Length = 74;
                    }

                    StringBuilder Jsondata = new StringBuilder();
                    bool readbytes = true;
                    int countbracs = 0;
                    for (int m = 0; m < Length; m++)
                    {
                        byte b = Marshal.ReadByte(buff, m);


                        if (((char)b).ToString() == "}")
                        {
                            countbracs= countbracs+1;
                         
                        }


                        if (readbytes)
                        {
                           
                            Jsondata.Append((char)b);
                     

                            if (countbracs==3)
                            {
                                readbytes = false;
                            }
                        }
                        else
                        {
                        
                            break;
                        }
                        
                    }

                    string locastring = Jsondata.ToString();
                     locastring = locastring.Replace("\"", "\'");
                    JsonResponse = Regex.Replace(locastring, @"\r\n?|\n", "");
                    Debug.Write(JsonResponse);
                }
            }
            catch (Exception ex)
            {
                JsonResponse = ex.Message;
             
            }
            



            return JsonResponse;
        }
      

        public static Dictionary<String, Object> parse(byte[] json)
        {
            string jsonStr = Encoding.UTF8.GetString(json);
            return JsonConvert.DeserializeObject<Dictionary<String, Object>>(jsonStr);
        }

       
    }
}
