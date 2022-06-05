using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SistabizApp_New.Helper
{
    public class PushNotification
    {

        //public static void SendNotificationKeepSafe911ToDeviceUsingFCM(List<NotificationInfo> notifications, int type = 0)
        //{
        //    try
        //    {

        //        string appid = string.Empty;
        //        string sendid = string.Empty;
               


        //        foreach (var notification in notifications)
        //        {
        //            if (!string.IsNullOrEmpty(notification.FirebaseDeviceId))
        //            {
        //                var data = new
        //                {
        //                    to = notification.FirebaseDeviceId,
        //                    notification = new
        //                    {
        //                        body = notification.Message,
        //                        title = notification.Title,
        //                        icon = "icon",
        //                        sound = "Enabled"

        //                    },
                           

        //                    priority = "high"
        //                };

        //                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
        //                tRequest.Method = "post";
        //                tRequest.ContentType = "application/json";
        //                //var serializer = new JavaScriptSerializer();
        //                var json =data;
        //                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
        //                tRequest.Headers.Add(string.Format("Authorization: key={0}", appid));
        //                tRequest.Headers.Add(string.Format("Sender: id={0}", sendid));
        //                tRequest.ContentLength = byteArray.Length;

        //                using (Stream dataStream = tRequest.GetRequestStream())
        //                {
        //                    dataStream.Write(byteArray, 0, byteArray.Length);
        //                    using (WebResponse tResponse = tRequest.GetResponse())
        //                    {
        //                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
        //                        {
        //                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
        //                            {
        //                                String sResponseFromServer = tReader.ReadToEnd();
        //                            }
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
