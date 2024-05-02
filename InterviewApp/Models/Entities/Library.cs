using Microsoft.EntityFrameworkCore;

namespace InterviewApp.Models.Entities
{
    [Keyless]
    public class Library
    {
        public bool HasBooks { get; set; }
        public int Books { get; set; }
    }
}
