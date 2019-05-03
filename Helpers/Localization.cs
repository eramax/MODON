namespace Helpers
{
    public enum Language : int
    {
        Ar = 0,
        En = 1
    }

    public static class Localization
    {
        public static string GetLocalizedText(Language language, string text, string text_LS)
        {
            if (string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text_LS))
                return text_LS;

            if (!string.IsNullOrWhiteSpace(text) && string.IsNullOrWhiteSpace(text_LS))
                return text;
            return language == Language.Ar ? text_LS : text;
        }

        public static Language GetLanguage(string name)
        {
            if (name == Language.En.ToString().ToLower())
            {
                return Language.En;
            }
            else//if (name == Language.Ar.ToString().ToLower())
            {
                return Language.Ar;
            }
        }
    }
}
