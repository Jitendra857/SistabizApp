using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SistabizApp_New.Helper
{
    public class PushNotification
    {

        public static async Task<bool> SendNotificationAsync(string token, string title, string body)
        {
             token = "dSLst0SrR4uLZG5YUTpWwE:APA91bGTzrhIwftQGeZXfrmV6dqehkOmqW0DanzYRLyB1u9Y-03-rf6GaXArrThAOl-10rNjKx8g6nSwOY5lQjyBUe7EGFCmEVsl7B7RCmebjrS8UMoW6wicEp0desZ686-s8no_Lj-1";

            using (var client = new HttpClient())
            {
                var firebaseOptionsServerId = "968722558832";
                var firebaseOptionsSenderId = "BBb59fJZ2oly7f-OshJa_A0yOaSWsoFEaL88BMZYevef5GTkxdreOveETPF4TgdVDr1NGsD_qnm23mhY06peoTE";

                client.BaseAddress = new Uri("https://fcm.googleapis.com");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization",
                    $"key={firebaseOptionsServerId}");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Sender", $"id={firebaseOptionsSenderId}");


                var data = new
                {
                    to = token,
                    notification = new
                    {
                        body = body,
                        title = title,
                    },
                    priority = "high"
                };

                var json = JsonConvert.SerializeObject(data);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var result = await client.PostAsync("/fcm/send", httpContent);
                return result.StatusCode.Equals(HttpStatusCode.OK);
            }
        }


        //public static void SendNotificationKeepSafe911ToDeviceUsingFCM(NotificationInfo notification, int type = 0)
        //{
        //    try
        //    {

        //        string appid = string.Empty;
        //        string sendid = string.Empty;




        //        if (!string.IsNullOrEmpty(notification.FirebaseDeviceId))
        //        {
        //            var data = new
        //            {
        //                to = notification.FirebaseDeviceId,
        //                notification = new
        //                {
        //                    body = notification.Message,
        //                    title = notification.Title,
        //                    icon = "icon",
        //                    sound = "Enabled"

        //                },


        //                priority = "high"
        //            };

        //            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
        //            tRequest.Method = "post";
        //            tRequest.ContentType = "application/json";
        //            //var serializer = new JavaScriptSerializer();
        //            var json = data;
        //            byte[] bytearray = Encoding.ASCII.GetBytes(author);

        //            Byte[] byteArray = Encoding.UTF8.GetBytes(json);
        //            tRequest.Headers.Add(string.Format("Authorization: key={0}", appid));
        //            tRequest.Headers.Add(string.Format("Sender: id={0}", sendid));
        //            tRequest.ContentLength = byteArray.Length;

        //            using (Stream dataStream = tRequest.GetRequestStream())
        //            {
        //                dataStream.Write(byteArray, 0, byteArray.Length);
        //                using (WebResponse tResponse = tRequest.GetResponse())
        //                {
        //                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
        //                    {
        //                        using (StreamReader tReader = new StreamReader(dataStreamResponse))
        //                        {
        //                            String sResponseFromServer = tReader.ReadToEnd();
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
