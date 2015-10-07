using System;

namespace Pediatre.Training.NetPatterns.TemplateMethod
{
    public class CdPlayer : Receiver
    {
        protected override void Play()
        {
            if (IsOn)
            {
                Console.Out.WriteLine($"CD is playing track {Channel} with volume {Volume}.");
            }
        }
    }
}