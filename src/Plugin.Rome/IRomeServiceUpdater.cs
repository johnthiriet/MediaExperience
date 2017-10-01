namespace Plugin.Rome
{
    public interface IRomeServiceUpdater
    {
        void Add(RomeRemoteSystem systemName);
        void Update(RomeRemoteSystem systemName);
        void Remove(RomeRemoteSystem systemName);
    }
}