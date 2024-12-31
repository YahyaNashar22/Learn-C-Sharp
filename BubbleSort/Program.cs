namespace BubbleSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strings = { "yahya", "abed", "mahmoud" };
            int[] ints = { 4, 3, 10, 1, 2, 20 };


            SortArray(ints);

            SortArrayStrings(strings);

        }

        public static void SortArray(int[] array)
        {
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < array.Length - 1; i++)
                {


                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        swapped = true;
                    }
                }

            } while (swapped);

            foreach (int i in array)
            {
                Console.WriteLine(i);
            }
        }

        public static void SortArrayStrings(string[] array)
        {
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < array.Length - 1; i++)
                {


                    if (string.Compare(array[i], array[i + 1]) > 0)
                    {
                        string temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        swapped = true;
                    }
                }

            } while (swapped);

            foreach (string i in array)
            {
                Console.WriteLine(i);
            }
        }
    }
}
