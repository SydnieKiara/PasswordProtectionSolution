namespace PasswordProtection
{
    public static class Password
    {
        public static string Evaluate(string password)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
                return "INELIGIBLE";

            bool hasUpper = false, hasLower = false, hasDigit = false, hasSymbol = false;

            foreach (char c in password)
            {
                if (!hasUpper && char.IsUpper(c)) hasUpper = true;
                else if (!hasLower && char.IsLower(c)) hasLower = true;
                else if (!hasDigit && char.IsDigit(c)) hasDigit = true;
                else if (!hasSymbol && !char.IsLetterOrDigit(c)) hasSymbol = true;

                if (hasUpper && hasLower && hasDigit && hasSymbol)
                    break;
            }

            int count = (hasUpper ? 1 : 0) + (hasLower ? 1 : 0) + (hasDigit ? 1 : 0) + (hasSymbol ? 1 : 0);

            return count switch
            {
                0 => "INELIGIBLE",
                1 => "WEAK",
                2 or 3 => "MEDIUM",
                4 => "STRONG",
                _ => "INELIGIBLE"
            };
        }




    }
}
