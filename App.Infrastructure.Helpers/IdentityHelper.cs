using System;
using System.Security.Principal;

namespace App.Infrastructure.Helpers
{
    public static class IdentityHelper
    {
        public static int GetUserId(this IIdentity identity)
        {
            return identity.IsAuthenticated ? Convert.ToInt32(identity.Name.Split('|')[0]) : 0;
        }

        public static string GetUserFullName(this IIdentity identity)
        {
            return identity.IsAuthenticated ? identity.Name.Split('|')[1] : string.Empty;
        }

        public static string GetUserName(this IIdentity identity)
        {
            return identity.IsAuthenticated ? identity.Name.Split('|')[2] : string.Empty;
        }

        public static string GetUserRoleName(this IIdentity identity)
        {
            return identity.IsAuthenticated ? identity.Name.Split('|')[3] : string.Empty;
        }
    }
}
