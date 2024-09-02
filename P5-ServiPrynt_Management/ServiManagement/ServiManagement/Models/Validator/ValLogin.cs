namespace ServiManagement.Models.Validator
{
    public static class ValLogin
    {
        public static bool Val(object obj)
        {
            if (obj == null) return false;
            if (!(bool)obj!) return false;
            return true;
        }
    }
}
