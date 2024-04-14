using Core.Models;

namespace Innovation.Models
{
    public class ViewModel
    {
        public IEnumerable<Header>? Headers { get; set; }
        public IEnumerable<About>? Abouts { get; set; }
        public IEnumerable<MyServices>? myServices { get; set; }
        public IEnumerable<Contact>? Contacts { get; set; }
        public IEnumerable<Team>? Teams { get; set; }
    }
}
