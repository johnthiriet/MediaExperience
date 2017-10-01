using System;
using MediaExperience.Droid;
using Plugin.MediaManager;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using VideoView = MediaExperience.Controls.VideoView;

[assembly: ExportRenderer(typeof(VideoView), typeof(VideoViewRenderer))]
namespace MediaExperience.Droid
{
    public class VideoViewRenderer : ViewRenderer<VideoView, VideoSurface>
    {
        private VideoSurface _videoSurface;

        public static void Init()
        {
            var temp = DateTime.Now;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<VideoView> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                _videoSurface = new VideoSurface(Context);
                SetNativeControl(_videoSurface);
                CrossMediaManager.Current.VideoPlayer.RenderSurface = _videoSurface;
                CrossMediaManager.Current.VideoPlayer.AspectMode = Element.AspectMode;
            }
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            var p = _videoSurface.LayoutParameters;
            p.Height = heightMeasureSpec;
            p.Width = widthMeasureSpec;
            _videoSurface.LayoutParameters = p;
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
        }
    }
}

