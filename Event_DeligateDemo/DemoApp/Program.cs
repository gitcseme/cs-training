using DemoApp.Subscribers;
using System;

namespace DemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var video = new Video { Title = "Video 1" };
            var encoder = new VideoEncoder();           // Publisher
            var mailService = new MailService();        // Subscriber
            var messageService = new MessageService();  // Subscriber

            encoder.VideoEncoded += mailService.OnVideoEncoded;
            encoder.VideoEncoded += messageService.OnVideoEncoded;

            encoder.Encode(video);

            
            Console.WriteLine("-------------------------\n\nDeligate");
            SomeDelegate someDelegate = new SomeDelegate(SomeFunction);
            someDelegate.Invoke();
        }

        public static void SomeFunction()
        {
            Console.WriteLine("Delegate calls this function");
        }

        // Define delegate that match this function return type and parameters.
        public delegate void SomeDelegate();
    }
}
