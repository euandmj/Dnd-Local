namespace DndL.Core.Configs
{
    public interface IExportable<T>
    {
        public void Import(T item);
        public T Export();
    }
}
