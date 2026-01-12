namespace Honeycomb
{
    public partial class Engine
    {
        public Engine()
        {
            new Scene2D("Game2D");
            Log.Info("Loaded default scene \"Game2D\"");
        }
    }
}