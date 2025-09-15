namespace PasswordProtection
{
    public static class Password
    {
        /// <summary>
        /// Evaluates the strength of a given password.
        /// The evaluation is based on the following criteria:
        /// 1. Password must be at least 8 characters long.
        /// 2. Contains at least one uppercase letter.
        /// 3. Contains at least one lowercase letter.
        /// 4. Contains at least one digit.
        /// 5. Contains at least one symbol (non-alphanumeric).
        /// Returns a classification: INELIGIBLE, WEAK, MEDIUM, or STRONG.
        /// </summary>
        /// <param name="password">The password string to evaluate.</param>
        /// <returns>
        /// A string representing the strength of the password:
        /// "INELIGIBLE" if null, whitespace, or too short;
        /// "WEAK" if only one criterion is met;
        /// "MEDIUM" if two or three criteria are met;
        /// "STRONG" if all four criteria are met.
        /// </returns>
        public static string Evaluate(string password)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
                return "INELIGIBLE";

            // New rule: Password must be at least 8 characters
            if (password.Length < 8)
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