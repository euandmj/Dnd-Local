namespace DndL.Game.Base
{
    public struct Stat<T>
    {
        public string Name { get; init; }
        public T Value { get; set; }
    }
}
