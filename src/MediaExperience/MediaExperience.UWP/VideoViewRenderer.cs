﻿using MediaExperience.UWP;
using Plugin.MediaManager;
using Xamarin.Forms.Platform.UWP;
using Size = Windows.Foundation.Size;
using VideoView = MediaExperience.Controls.VideoView;

[assembly: ExportRenderer(typeof(VideoView), typeof(VideoViewRenderer))]
namespace MediaExperience.UWP
{
    public class VideoViewRenderer : ViewRenderer<VideoView, VideoSurface>
    {
        private VideoSurface _videoSurface;

        protected override void OnElementChanged(ElementChangedEventArgs<VideoView> e)
        {
            base.OnElementChanged(e);
            if (Control == null && Element != null)
            {
                _videoSurface = new VideoSurface();
                CrossMediaManager.Current.VideoPlayer.AspectMode = Element.AspectMode;
                SetNativeControl(_videoSurface);
                CrossMediaManager.Current.VideoPlayer.RenderSurface = _videoSurface;
            }
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            availableSize = base.MeasureOverride(availableSize);
            _videoSurface.Height = availableSize.Height;
            _videoSurface.Width = availableSize.Width;
            return availableSize;
        }
    }
}

