namespace Appeon.DataStoreDemo.Services
{
    public interface ILoginService
    {
        bool UserIsExist(string userName);

        bool Login(string userName, string password);
    }
}
