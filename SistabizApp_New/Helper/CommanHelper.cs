using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.Helper
{
    public static class CommanHelper
    {
        public static string GetServiceRequestStatus(int Status)
        {
            switch (Status)
            {
                case 1:
                    return Constant.Pending;
                  
                case 2:
                    return Constant.Approved;
                default:
                    return Constant.Reject;
                   
            }
        }

        public static string GetDigitalLibraryPaymentType(int type)
        {
            switch (type)
            {
                case 1:
                    return Constant.Paid;

                case 2:
                    return Constant.Free;
                default:
                    return Constant.Reject;

            }
        }
        public static string GetServiceRequestFor(int RequestType)
        {
            switch (RequestType)
            {
                case 1:
                    return Constant.Coch;

                case 2:
                    return Constant.ServiceProvider;
                default:
                    return "None";

            }
        }

        public static string GetEventStatus(int Status)
        {
            switch (Status)
            {
                case 0:
                    return Constant.Pending;

                case 1:
                    return Constant.Reject;
                case 2:
                    return Constant.Cancel;
                default:
                    return "";

            }
        }

        public static string GetGroupType(int? Status)
        {
            switch (Status)
            {
                case 1:
                    return Constant.Public;

                case 2:
                    return Constant.Private;
                default:
                    return Constant.Public;

            }
        }

        public static string GetmeetingTypes(int? type)
        {
            switch (type)
            {
                case 1:
                    return Constant.Virtual;

                case 2:
                    return Constant.Physical;
                default:
                    return Constant.Virtual;

            }
        }
    }
}
