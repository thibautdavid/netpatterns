using System;

namespace Pediatre.Training.NetPatterns.TemplateMethod
{
    public class Tv : Receiver
    {
        protected override void Play()
        {
            if (IsOn)
            {
                Console.Out.WriteLine($"TV is playing on channel {Channel} with volume {Volume}");
            }
        }
    }
}