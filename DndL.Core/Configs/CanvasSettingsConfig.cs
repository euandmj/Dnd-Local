namespace DndL.Core.Configs
{
    public struct CanvasSettingsConfig
    {
        public bool IsFogEnabled { get; init; }
        public int Rows { get; init; }
        public int Columns { get; init; }


        public static bool operator == (CanvasSettingsConfig a, CanvasSettingsConfig b)
        {
            throw new System.NotImplementedException();
        }

        public static bool operator != (CanvasSettingsConfig a, CanvasSettingsConfig b)
        {
            throw new System.NotImplementedException();
        }
    }
}
