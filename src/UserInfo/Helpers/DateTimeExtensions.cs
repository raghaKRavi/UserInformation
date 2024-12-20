namespace UserInfo.Helpers;

public static class DateTimeExtensions
{
    public static int ToAgeString(this DateOnly dob)
    {
        DateTime today = DateTime.Today;
        
        int years = today.Year - dob.Year;

        return years;
    }
}