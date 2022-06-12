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
    }
}
