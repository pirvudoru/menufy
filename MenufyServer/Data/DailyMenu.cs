using System.Collections.Generic;

namespace MenufyServer.Data
{
    public class DailyMenu : Identifiable
    {
        public ICollection<Meal> Meals { get; set; }
    }
}