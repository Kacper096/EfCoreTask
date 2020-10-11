namespace EfCoreTask.Data
{
    public interface IDbManager
    {
        void CreateIfNotExsits();
        void ReCreate();
        void DisableLazyLoading();
        void EnableLazyLoading();
    }
}