using System.Collections.Generic;
using System.Globalization;

namespace App.Infrastructure.Helpers
{
    public static class ConstHelper
    {
        public const string CultureNameTR = "tr-TR";
        public const string CultureNameEN = "en-US";

        public const string tr = "tr";
        public const string en = "en";

        public const string tr_txt = "tr-TR_txt";
        public const string en_txt = "en-US_txt";

        public const string __Lang = "__Lang";

        public const string Anonymous = "Anonymous";

        private static CultureInfo _cultureTR;
        public static CultureInfo CultureTR { get { return _cultureTR ?? (_cultureTR = new CultureInfo(CultureNameTR)); } }
        private static CultureInfo _cultureEN;
        public static CultureInfo CultureEN { get { return _cultureEN ?? (_cultureEN = new CultureInfo(CultureNameEN)); } }

        public const string Admin = "Admin";
        public const string Observer = "Observer";
        public const string WebApiUser = "WebApiUser";
        //public static List<string> Roles = new List<string> { Admin, Observer, WebApiUser };
        public static Dictionary<string, int> Roles = new Dictionary<string, int>();

        public enum RolesEnum
        {
            Admin,
            Observer,
            WebApiUser
        }
         
        public const string Imap4 = "Imap4";
        public const string Pop3 = "Pop3";

        public static Dictionary<MailProtocol, string> MailProtocols = new Dictionary<MailProtocol, string> { { MailProtocol.Imap4, "Imap4" }, { MailProtocol.Pop3, "POP3" } };

        public enum MailProtocol
        {
            Imap4,
            Pop3
        }

        public const string WebApiHost = "http://localhost:9000";

        public const int PageSize = 25;
    }
}
