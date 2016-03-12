namespace MenufyServer.Data
{
    public class RecipeNutritionData : Identifiable
    {
        public decimal Amount { get; set; }

        public decimal PercentOfDailyValue { get; set; }

        public NutritionType NutritionType { get; set; }
    }
}