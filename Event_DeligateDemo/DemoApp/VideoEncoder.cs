using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DemoApp
{
    /*
        1. Define a delegate
        2. Define an event based on that deligate
        3. Raise the event
     */

    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }
    }

    public class VideoEncoder
    {
        public delegate void VideoEncodingEventHandlerDelegate(object source, VideoEventArgs args);
        public event VideoEncodingEventHandlerDelegate VideoEncoded;


        //public event EventHandler<VideoEventArgs> VideoEncoded;
        //public delegate void GenericEventHandlerDelegate<TEventArgs>(object? sender, TEventArgs args);
        //public event GenericEventHandlerDelegate<VideoEventArgs> VideoEncoded;

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding video...");
            Thread.Sleep(3000);

            OnVideoEncoded(video);
        }

        protected virtual void OnVideoEncoded(Video video)
        {
            if (VideoEncoded != null)
                VideoEncoded(this, new VideoEventArgs { Video = video });

            // VideoEncoded?.Invoke(this, EventArgs.Empty);
        }
    }
}
