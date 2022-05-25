using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.Helper
{
    public class Constant
    {
        public const string Success = "Success";
        public const string Error = "Error";

        public const string Pending = "Pending";
        public const string Approved = "Approved";
        public const string Reject = "Reject";
        public const string Cancel = "Cancel";
        public const string Attend = "Attend";
        public const string Coch = "Coch";
        public const string Public = "Public";
        public const string Private = "Private";
        public const string Paid = "Paid";
        public const string Free = "Free";
        public const string ServiceProvider = "Service Provider";
        public const string BaseUrl = "http://localhost:58870/";
        public const string ProfilePath = @"wwwroot\Profiles";
        public const string MemberPost = @"wwwroot\MemberPost";
        public const string Event = @"wwwroot\Events";
        public const string Group = @"wwwroot\Groups";
        public const string GroupIcon = @"wwwroot\GroupIcon";

        public const string DigitalLibrary = @"wwwroot\DigitalLibrary";
        //DigitalLibrary
        public const string Post = @"wwwroot\Post";
        public const string livebaseurl = "http://34.228.199.228:8070/";
        public const string MemberIcon = "http://34.228.199.228:8070/images/member.png";
        public const string CoachIcon = "http://34.228.199.228:8070/images/coach.svg";
        public const string ServiceProviderIcon = "http://34.228.199.228:8070/images/coach.svg";
        public const string localbaseUrl = "http://localhost:58870/";
        public const string Virtual = "Virtual";
        public const string Physical = "Physical";


    }
    public class Role
    {
        public const int Member = 1;
        public const int Coaches = 1;
        public const int ServiceProvider = 1;
    }

    public class DataOrdering
    {
        public const int Asc = 1;
        public const int Desc =2;
       
    }
}
