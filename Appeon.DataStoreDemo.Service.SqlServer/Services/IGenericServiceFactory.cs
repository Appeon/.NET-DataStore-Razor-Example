namespace Appeon.DataStoreDemo.Services
{
    public interface IGenericServiceFactory
    {
        IGenericService<TModel> Get<TModel>();
    }
}
