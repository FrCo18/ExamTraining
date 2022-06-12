using System.Text.RegularExpressions;

namespace ExamTraining.Helpers
{
    public static class StringHelpers
    {
        public static bool isValidEmail(string email)
        {
            Regex regex = new Regex(@"[\w\d]+@\w+\.\w+");
            return regex.IsMatch(email);
        }

        public static bool isNumber(string value)
        {
            Regex regex = new Regex(@"^\d{0,}[.]*\d+$");
            return regex.IsMatch(value);
        }
    }
}
