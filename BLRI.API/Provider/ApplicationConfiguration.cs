using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLRI.API.Provider
{
    public static class ApplicationConfiguration
    {
        public static string JwtSecurityKey => "BLRI@GOV@BD=2019";
        public static string TokenIssuer => "blri.com.bd";
        public static string TokenIAudience => "blri.com.bd";
        public static int TokenExpiration => 7;

    }
}
