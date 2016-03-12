namespace MenufyServer.Data
{
    public class Meal : Identifiable
    {
        public int Servings { get; set; }

        public Recipe Recipe { get; set; }
    }
}