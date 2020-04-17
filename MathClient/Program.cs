﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MathClient.ServiceReference1;

namespace MathClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** The Async Math Client *****\n");
            using (BasicMathClient proxy = new BasicMathClient())
            {
                proxy.Open();
                //Суммировать числа в асинхронной манере с применением лямбда-выражения
                IAsyncResult result = proxy.BeginAdd(2, 3, ar
                     =>
                    {
                        Console.WriteLine("2 + 3 = {0}", arg0: proxy.EndAdd(ar));
                    },
                    null);
                while (!result.IsCompleted)
                {
                    Thread.Sleep(200);
                    Console.WriteLine("Client working...");
                }
            }
            Console.ReadLine();
        }
    }
}
