namespace HashSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("--------- Welcome To HashSets And Queues And Stacks ---------");
            Console.WriteLine("-------------------------------------------------------------");


            HashSet<int> set = new();

            set.Add(1);
            set.Add(2);
            set.Add(1);

            Console.WriteLine($"set.Add(1) evaluates to false because the HashSet already contains the value 1: {set.Add(1)}");

            foreach (int item in set)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("For Queues you can have Enque() amd Dequeue() operations FIFO");

            Queue<int> queue = new Queue<int>();

            queue.Enqueue(1); queue.Enqueue(2); queue.Enqueue(3);

            while (queue.Count > 0)
            {
                int removed = queue.Dequeue();


                Console.WriteLine($"removed {removed}");
            }

            Console.WriteLine("For Stacks it's the same with queues with Push() amd POP() operators but in reverse LIFO");

            Stack<int> stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            while (stack.Count > 0)
            {
                int popped = stack.Pop();
                Console.WriteLine($"removed item {popped}");
            }

        }
    }
}
