using Framework;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var processor = new GenericFunctionFileProcessor<(string, int)>();

var input = processor.GetContent(@".\input.txt", (input) => {
    var splitted = input.Split(" ");
    return new(splitted[0], Convert.ToInt32(splitted[1])); 
});

