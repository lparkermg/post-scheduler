using System;
using System.Collections.Generic;
using ps_adaptors.Interfaces;
using ps_core;
using ps_entities;

namespace ps_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private static void SetupApp()
        {
            //TODO: Initialize Adaptors.
            
            
            //TODO: Check and load existing items. (Later)
            
            
            //TODO: Initialize Core.
            PsCore.Initialise(new List<ScheduleItem>(),new List<IAdaptor>());
            
            //TODO: Start.
            PsCore.Start();
        }
    }
}