using System.Reflection;
using System.Web;

namespace web_propusk.Models
{
    public class Zai_Per
    {
        public  Zaivki zaivki { get; set; }
        public Person person { get; set; }
        public string Where { get; set; }
        public string Type { get; set; }
        public IFormFile Photo { get; set; }
    }
}
