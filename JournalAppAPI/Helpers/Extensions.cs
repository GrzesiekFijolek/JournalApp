using CloudinaryDotNet;
using JournalAppAPI.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalAppAPI.Helpers
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        public static Transformation SquareTransformation()
        {
            return new Transformation()
                .Width(130).Height(130).Crop("scale");
        }

        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        //public static Transformation HugeTransformation()
        //{
        //    return new Transformation()
        //        .Width(900).Height(500).Crop("fill").Gravity("face");
        //}
        //public static Transformation LargeTransformation()
        //{
        //    return new Transformation()
        //        .Width(630).Height(350).Crop("fill").Gravity("face");
        //}

        //public static Transformation BigTransformation()
        //{
        //    return new Transformation()
        //        .Width(400).Height(220).Crop("fill").Gravity("face");
        //}

        //public static Transformation MediumTransformation()
        //{
        //    return new Transformation()
        //        .Width(305).Height(170).Crop("fill").Gravity("face");
        //}

        //public static Transformation SmallTransformation()
        //{
        //    return new Transformation()
        //        .Width(100).Height(55).Crop("fill").Gravity("face");
        //}
    }
}
