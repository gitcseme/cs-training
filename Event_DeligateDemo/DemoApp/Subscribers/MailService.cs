using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.Subscribers
{
    public class MailService
    {
        public void OnVideoEncoded(object source, VideoEventArgs args)
        {
            Console.WriteLine($"MailService: Sending an email for {args.Video.Title} ...");
        }
    }
}
