namespace MenufyServer.Data
{
    public class RecipeStep : Identifiable
    {
        public int Ordinal { get; set; }

        public string Description { get; set; }
    }
}