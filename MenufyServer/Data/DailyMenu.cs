using System.Collections.Generic;

namespace MenufyServer.Data
{
    public class DailyMenu
    {
        public ICollection<Meal> Meals { get; set; }
    }
}