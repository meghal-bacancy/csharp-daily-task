//Write a program to check the following conditions for the three numbers a, b, and c:
//Check if all numbers are even, and if not, check if they are divisible by 3.
//Check if the sum of all three numbers is divisible by 5, while ensuring no number is zero.
//If any of the conditions fail, the program should return a message indicating which condition failed.

using System.Threading;

int a, b, c;
a = 5;
b = 7;
c = 11;

if ((a % 2 == 1) || (b % 2 == 1) || (c % 2 == 1))
{
    Console.WriteLine("Not all numbers are even");
    if ((a % 3 != 0) && (b % 3 != 0) && (c % 3 != 0))
    {
        Console.WriteLine("Not all numbers are divisible by 3");
    }
}


if ((a != 0) && (b != 0) && (c != 0))
{
    if ((a + b + c) % 5 != 0)
    {
        Console.WriteLine("Sum of all three numbers is not divisible by 5");
    }
}
else
{
    Console.WriteLine("One of the numbers is zero");
}