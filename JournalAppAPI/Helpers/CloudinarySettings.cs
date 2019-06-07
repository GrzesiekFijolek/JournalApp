using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalAppAPI.Helpers
{
    public class CloudinarySettings
    {
        public string CloudName { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }

        public static readonly string url = "https://res.cloudinary.com/xvite/image/upload/";
        public static readonly string transformationHuge = "c_fill,h_500,w_900/";
        public static readonly string transformationLarge = "c_fill,h_350,w_630/";
        public static readonly string transformationBig = "c_fill,h_220,w_400/";
        public static readonly string transformationMedium = "c_fill,h_170,w_300/";
        public static readonly string transformationSmall = "c_fill,h_55,w_110/";

        public static void Transformations(string url, out string urlHuge, out string urlLarge, out string urlBig, out string urlMedium, out string urlSmall)
        {
            urlHuge = CloudinarySettings.url + CloudinarySettings.transformationHuge + url;
            urlLarge = CloudinarySettings.url + CloudinarySettings.transformationLarge + url;
            urlBig = CloudinarySettings.url + CloudinarySettings.transformationBig + url;
            urlMedium = CloudinarySettings.url + CloudinarySettings.transformationMedium + url;
            urlSmall = CloudinarySettings.url + CloudinarySettings.transformationSmall + url;
        }
    }
}

