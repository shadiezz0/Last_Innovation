using Core.Models;

namespace Innovation.Models
{
    public class ViewModel
    {
        public IEnumerable<Header>? Headers { get; set; }
        public IEnumerable<About>? Abouts { get; set; }
        public IEnumerable<MyServices>? myServices { get; set; }
    }
}
