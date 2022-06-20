using CorePush.Google;
using Microsoft.Extensions.Options;
using SistabizApp_New.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static SistabizApp_New.Helper.GoogleNotification;

namespace SistabizApp_New.Services
{
    public interface INotificationService
    {
        Task<ResponseModel> SendNotification(NotificationModel notificationModel);
    }
    public class NotificationService : INotificationService
    {

        private readonly FcmNotificationSetting _fcmNotificationSetting;
        public NotificationService(IOptions<FcmNotificationSetting> settings)
        {
            _fcmNotificationSetting = settings.Value;
        }

        public async Task<ResponseModel> SendNotification(NotificationModel notificationModel)
        {
            ResponseModel response = new ResponseModel();

            string token = "dSLst0SrR4uLZG5YUTpWwE:APA91bGTzrhIwftQGeZXfrmV6dqehkOmqW0DanzYRLyB1u9Y-03-rf6GaXArrThAOl-10rNjKx8g6nSwOY5lQjyBUe7EGFCmEVsl7B7RCmebjrS8UMoW6wicEp0desZ686-s8no_Lj-1";
            try
            {
                if (notificationModel.IsAndroiodDevice)
                {
                    /* FCM Sender (Android Device) */
                    FcmSettings settings = new FcmSettings()
                    {
                        SenderId = _fcmNotificationSetting.SenderId,
                        ServerKey = _fcmNotificationSetting.ServerKey
                    };
                    HttpClient httpClient = new HttpClient();

                    string authorizationKey = string.Format("keyy={0}", settings.ServerKey);
                    string deviceToken = notificationModel.DeviceId;

                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authorizationKey);
                    httpClient.DefaultRequestHeaders.Accept
                            .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    DataPayload dataPayload = new DataPayload();
                    dataPayload.Title = notificationModel.Title;
                    dataPayload.Body = notificationModel.Body;

                    GoogleNotification notification = new GoogleNotification();
                    notification.Data = dataPayload;
                    notification.Notification = dataPayload;

                    var fcm = new FcmSender(settings, httpClient);
                    try
                    {
                        var fcmSendResponse = await fcm.SendAsync(token, notification);

                        if (fcmSendResponse.IsSuccess())
                        {
                            response.IsSuccess = true;
                            response.Message = "Notification sent successfully";
                            return response;
                        }
                        else
                        {
                            response.IsSuccess = false;
                            response.Message = fcmSendResponse.Results[0].Error;
                            return response;
                        }
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }

                    
                }
                else
                {
                    /* Code here for APN Sender (iOS Device) */
                    //var apn = new ApnSender(apnSettings, httpClient);
                    //await apn.SendAsync(notification, deviceToken);
                }
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Something went wrong";
                return response;
            }
        }
    
}
}
