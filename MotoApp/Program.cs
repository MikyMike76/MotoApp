using MotoApp;

var stack = new BasicStack<double>();
stack.Push(3.5);
stack.Push(445);
stack.Push(9);
double sum = 0.0;
while(stack.Count > 0)
{
    double item = stack.Pop();
    Console.WriteLine($"Item: {item}");
    sum += item;
}
Console.WriteLine($"Sum: {sum}");