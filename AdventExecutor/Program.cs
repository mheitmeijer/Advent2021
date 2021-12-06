// See https://aka.ms/new-console-template for more information
using Framework.Interfaces;
using System.Reflection;

Console.WriteLine("Advent Executor");

var assemblies = Directory.GetFiles(".", "Day*.dll");

var lastDayAssembly = assemblies.OrderByDescending(a => a).FirstOrDefault();

var assembly = Assembly.LoadFrom(lastDayAssembly);

var dayClass = assembly.GetTypes().Where(x => x.GetInterfaces().Contains(typeof(IDay))).FirstOrDefault();
Console.WriteLine($"Using assembly: {assembly.FullName}");

var instance = (IDay)Activator.CreateInstance(dayClass);
Console.WriteLine("Enter 1 or 2 for executing the step.");
Console.Write("Which option: ");

var option = Console.ReadLine();

if (option == "1" || string.IsNullOrEmpty(option))
{
    var firstAnswer = instance.CalculatePart1();
    Console.WriteLine($"Answer: {firstAnswer}");
}
else
{
    var secondAnswer = instance.CalculatePart2();
    Console.WriteLine($"Answer: {secondAnswer}");
}

Console.Write("Finished... Press any key to close...");
Console.ReadKey();