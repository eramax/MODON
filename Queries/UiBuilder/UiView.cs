namespace UiBuilder
{
    public class UiView
    {
        public string Html { get; set; } 
        public string Scripts { get; set; }

        public static UiView operator +(UiView c1, UiView c2)
        {
            if (c2 == null) return c1;
            c1.Html += c2.Html;
            c1.Scripts += c2.Scripts;
            return c1;
        }
    }

}
