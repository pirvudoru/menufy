using System.Collections.Generic;

namespace MenufyServer.Data
{
    public class Menu : Identifiable
    {
        public ApplicationUser User { get; set; }

        public ICollection<DailyMenu> DailyMenus { get; set; }
    }
}