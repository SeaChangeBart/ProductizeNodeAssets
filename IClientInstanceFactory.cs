namespace MakeSomeFoldersFree
{
    public interface IClientInstanceFactory<out T>
        where T : class
    {
        T CreateInstance();
    }
}