using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Plugin.MediaManager.Abstractions;

namespace MediaExperience.UWP
{
    public class VideoSurface : Canvas, IVideoSurface, IDisposable
    {
        #region IDisposable
        public bool IsDisposed => disposed;

        // Flag: Has Dispose already been called?
        bool disposed = false;


        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.                
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        ~VideoSurface()
        {
            Dispose(false);
        }
        #endregion        
    }
}
