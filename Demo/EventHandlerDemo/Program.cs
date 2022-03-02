using System;
using EventHandlerDemo.Delegate;


namespace EventHandlerDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var buffer = new CircularBuffer<double>(capacity: 3);
            buffer.ItemDiscard += BufferDiscard;
            buffer.CustomItemDiscard += BufferCustomItemDiscard;
            ProcessInput(buffer);

            buffer.Dump(d => Console.WriteLine(d));

            ProcessBuffer(buffer);
        }

        private static void BufferDiscard(object sender, EventArgs e)
        {
            //EventArgs has not information.
            ;
        }

        private static void BufferCustomItemDiscard(object sender, ItemDiscardedEventArgs<double> e)
        {
            Console.WriteLine($"Discard element: {e.ItemDiscarded}");
            Console.WriteLine($"New element: {e.NewItem}");
        }

        private static void ProcessBuffer(IBuffer<double> buffer)
        {
            var sum = 0.0;
            Console.WriteLine("Buffer: ");
            while (!buffer.IsEmpty)
            {
                sum += buffer.Read();
            }

            Console.WriteLine(sum);
        }

        private static void ProcessInput(IBuffer<double> buffer)
        {
            while (true)
            {
                var value = 0.0;
                var input = Console.ReadLine();

                if (double.TryParse(input, out value))
                {
                    buffer.Write(value);
                    continue;
                }
                break;
            }
        }
    }
}
