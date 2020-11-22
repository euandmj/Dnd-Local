namespace DndL.Game.Base
{
    public interface IStat<T>
    {
        public string Name { get; init; }
        public T Value { get; set; }
    }
}
