using System.Xml.Linq;

namespace WebAPI.Models
{
    public class UploadViewModel
    {
        public string Name { get; set; }
        public string? PhotoUrl { get; set; }
        public UploadViewModel(string name, string? photoUrl) {
            Name = name;
            PhotoUrl = photoUrl;
        }

    }
}
