using HMO_Project.Api.Models.PostModels;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.StaticFiles;
using System.Text.RegularExpressions;

namespace HMO_Project.Api.Validation
{
    public static class ValidationData
    {

        public static string? ValidMemberPostModel(MemberPostModel memberPostModel)
        {
            if (tooEarlyDate(memberPostModel.BirthDate))
                return "birth date cant be more than 100 years ago";
            if (!IsValidDateTime(memberPostModel.BirthDate))
                return "birth date cant be bigger than current date";
            if (!IsValidNumber(memberPostModel.IdNumber, 9))
                return "id number must be 9 digits";
            if (!IsValidNumber(memberPostModel.PhoneNumber, 9))
                return "phone number must be 9 digits";
            if (!IsValidNumber(memberPostModel.MobilePhoneNumber, 10))
                return "mobile phone number nust be 10 digits";
            if (memberPostModel.ImageFile != null)
            {
                var contentType = memberPostModel.ImageFile.ContentType;

                // Check if the content type indicates an image
                if (!contentType.StartsWith("image/"))
                {
                    return "file is not an image";
                }
            }
            return null;
        }

        public static string? ValidKoronaDiseasePostModel(KoronaDiseasePostModel koronaDiseasePostModel)
        {
            if (!IsValidDateTime(koronaDiseasePostModel.DiagnosisDate))
                return "diagnosis date cant be bigger than current date";
            if (koronaDiseasePostModel.RecoveryDate != null)
            {
                if (koronaDiseasePostModel.RecoveryDate < koronaDiseasePostModel.DiagnosisDate)
                    return "recovery date cant be earlier than diagnosis date";
                if (!IsValidDateTime(koronaDiseasePostModel.RecoveryDate.Value))
                    return "recovery date cant be bigger than current date";
            }
            return null;
        }
        public static bool tooEarlyDate(DateTime date)
        {
            // Calculate DateTime for 100 years ago from today
            DateTime oneHundredYearsAgo = DateTime.Today.AddYears(-100);

            // Compare the DateTime with 100 years ago
            return date < oneHundredYearsAgo;
        }

        public static bool IsValidNumber(string number, int length)
        {
            return Regex.IsMatch(number, @"^\d{" + length + "}$");
        }

        public static bool IsValidDateTime(DateTime date)
        {
            return date <= DateTime.Now;
        }
    }
}
