using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.Subscribers
{
    public class MessageService
    {
        public void OnVideoEncoded(object source, VideoEventArgs args)
        {
            Console.WriteLine($"MessageService: Sending message for {args.Video.Title} ...");
        }
    }
}
