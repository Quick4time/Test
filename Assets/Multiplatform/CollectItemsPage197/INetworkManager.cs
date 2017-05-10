public interface INetworkManager
{
    ManagerStatus status { get; }

    void Startup(NetworkService service);
}
