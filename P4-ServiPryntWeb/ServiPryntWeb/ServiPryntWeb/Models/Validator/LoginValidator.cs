namespace ServiPryntWeb.Models.Validator
{
    public static class LoginValidator
    {
        public static bool ValLog(object obj)
        {
            if (obj == null) return false;
            if (!(bool)obj!) return false;
            return true;
        }
    }
}
