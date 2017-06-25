using System;
using Microsoft.AspNetCore.Hosting;
using upgradetoweb;

namespace Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
		//string name;
            	//Console.WriteLine("Hello World!");
		//name = Console.ReadLine();
		//Console.WriteLine($"Hello {name}");	

		var host = new WebHostBuilder()
				.UseKestrel()
				.UseStartup<Startup>()
				.Build();
		host.Run();
 		
        }
    }
}
