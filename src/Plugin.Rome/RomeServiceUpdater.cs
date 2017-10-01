using System;

namespace Plugin.Rome
{
    public class RomeServiceUpdater : IRomeServiceUpdater
    {
        private readonly Action<RomeRemoteSystem> _add;
        private readonly Action<RomeRemoteSystem> _update;
        private readonly Action<RomeRemoteSystem> _remove;
        
        public RomeServiceUpdater(Action<RomeRemoteSystem> add = null, Action<RomeRemoteSystem> update = null, Action<RomeRemoteSystem> remove = null)
        {
            _add = add;
            _update = update;
            _remove = remove;
        }

        public void Add(RomeRemoteSystem system)
        {
            _add?.Invoke(system);
        }

        public void Update(RomeRemoteSystem system)
        {
            _add?.Invoke(system);
        }

        public void Remove(RomeRemoteSystem system)
        {
            _remove?.Invoke(system);
        }
    }
}