using System.Collections.Generic;

namespace FTask.AuthDatabase.Models
{
    public class GooglePayloadModel
    {
        public string Issuer { get; set; }
        public IList<string> Audience { get; set; }
        public string Subject { get; set; }
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Locale { get; set; }
        public long IssueAt { get; set; }
        public long ExpireAt { get; set; }
    }
}
