using System.Collections.Generic;

namespace MenufyServer.Data
{
    public class UserProfile : Identifiable
    {
        public int BirthDateYear { get; set; }

        public string Gender { get; set; }

        public ICollection<Menu> Menus { get; set; }

        public string Height { get; set; }

        public string Lifestyle { get; set; }

        public string Weight { get; set; }

        public string Constitution { get; set; }

        public string UserId { get; set; }
    }
}