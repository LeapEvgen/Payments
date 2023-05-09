using System;



class Program

{

    static void Main(string[] args)

    {

        Console.Write("Введіть суму k: ");

        int k = int.Parse(Console.ReadLine());



        int[] denominations = { 1, 2, 5, 10 };



        int[] counts = new int[denominations.Length];



        int solutionsCount = CountSolutions(k, denominations, counts, 0);



        Console.WriteLine($"Кількість способів виплатити суму {k} грн.: {solutionsCount}");

        Console.WriteLine("Усі комбінації виплат:");



        PrintSolutions(k, denominations, counts, 0);



        Console.ReadLine(); // Додаємо цей рядок, щоб консольне вікно не закрилося після виконання програми 

    }



    static int CountSolutions(int amount, int[] denominations, int[] counts, int index)

    {

        if (amount == 0)

        {

            return 1;

        }



        if (index == denominations.Length)

        {

            return 0;

        }



        int count = 0;



        for (int i = 0; i <= amount / denominations[index]; i++)

        {

            counts[index] = i;

            int remainder = amount - i * denominations[index];

            count += CountSolutions(remainder, denominations, counts, index + 1);

        }



        return count;

    }



    static void PrintSolutions(int amount, int[] denominations, int[] counts, int index)

    {

        if (amount == 0)

        {

            PrintCounts(denominations, counts);

            return;

        }



        if (index == denominations.Length)

        {

            return;

        }



        for (int i = 0; i <= amount / denominations[index]; i++)

        {

            counts[index] = i;

            int remainder = amount - i * denominations[index];

            PrintSolutions(remainder, denominations, counts, index + 1);

        }

    }



    static void PrintCounts(int[] denominations, int[] counts)

    {

        for (int i = 0; i < denominations.Length; i++)

        {

            Console.Write($"{counts[i]} x {denominations[i]} грн. + ");

        }



        Console.WriteLine("0");

    }

}