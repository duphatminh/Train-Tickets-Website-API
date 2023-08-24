using System.ComponentModel.DataAnnotations;

namespace TrainTicketsWebsite.Utilities;

public static class ValidationHelper
{
    public static bool IsEmail(string email)
    {
        return new EmailAddressAttribute().IsValid(email);
    }
}