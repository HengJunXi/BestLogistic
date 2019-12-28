using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BestLogistic.Controllers
{
    public static class Utility
    {
        public static readonly Dictionary<string, string> StateCodeMap = new Dictionary<string, string>()
        {
            { "KDH", "Kedah" },
            { "PLS", "Perlis" },
            { "PJY", "Wilayah Persekutuan Putra Jaya" },
            { "SGR", "Selangor" },
            { "KTN", "Kelantan" },
            { "KUL", "Wilayah Persekutuan Kuala Lumpur" },
            { "PHG", "Pahang" },
            { "MLK", "Melaka" },
            { "JHR", "Johor" },
            { "PRK", "Perak" },
            { "NSN", "Negeri Sembilan" },
            { "TRG", "Terengganu" },
            { "PNG", "Pulau Pinang" },
        };

        public static readonly string[] UserIdType =
        {
            "IC Number",
            "Old IC Number",
            "Passport"
        };
    }
}