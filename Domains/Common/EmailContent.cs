using System.Collections.Generic;

namespace Domains
{
    public class EmailContent
    {
        public List<string> To = new List<string>();

        public List<string> CC = new List<string>();

        public string Subject;

        public string Body;
    }
}
