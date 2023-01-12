// See https://aka.ms/new-console-template for more information

using System.ComponentModel;
using System.Globalization;

//1.Write a C# program to print Hello and your name in the same line.
string hello = "Hello";
string name = "Alexandre";
Console.WriteLine(hello + " " + name);

//2.Write a C# program to print the sum of two numbers and the division of those two numbers.
int a = 10;
int b = 5;
int sum = a + b;
int div = a / b;
Console.WriteLine(a + " + " + b + " = " + sum);
Console.WriteLine(a + " / " + b + " = " + div);

//3.Write a C# program to print the result of the specified operations: 
int result = (-1 + 5) * 6;
Console.WriteLine("1: " + result);
int result2 = (38 + 5) % 7;
Console.WriteLine("2: " + result2);
double result3 = 14 + (-3 * 6 / 7);
Console.WriteLine("3: " + result3);
double result4 = 2 + (13 / 6 * 6) + Math.Sqrt(7);
Console.WriteLine("4: " + result4);
double result5 = (Math.Pow(6,4)+Math.Pow(5,7))/(9%4);
Console.WriteLine("5: " + result5);

/*4.Write a C# program that assigns an age (number) (for example 20) and a gender (string) (for example female) and displays something like:
"You are female and look younger than 20." */
int age = 20;
string gender = "female";
Console.WriteLine("You are " + gender + " and look younger than " + age);

//5.Write a C# program that takes an integer representing seconds (for example 45678) and converts it to : Minutes, Hours, Days, Years.
int seconds = 45678;
Console.WriteLine("Seconds: " + seconds);
int minutes = seconds/60;
Console.WriteLine("Minutes: " + minutes);
int hours = minutes/60;
Console.WriteLine("Hours: " + hours);
int days = hours / 24;
Console.WriteLine("Days: " + days);
int years = days / 365;
Console.WriteLine("Years: " + years);

//6. Rewrite Program #5 using .Net Libraries.
TimeSpan t = TimeSpan.FromSeconds(45678);
string answer = string.Format(
      CultureInfo.CurrentCulture,
      "{0} years, {1} days, {2} hours, {3} minutes, {4} seconds",
      t.Days / 365,
      (t.Days - (t.Days / 365) * 365) - ((t.Days - (t.Days / 365) * 365) / 30) * 30,
      t.Hours,
      t.Minutes,
      t.Seconds);
Console.WriteLine("Answer 6: " + answer);

//7.Write a C# program to convert from celsius degrees to Kelvin and Fahrenheit.
double celsius = 30;
Console.WriteLine("Celsius: " + celsius);
double fahrenheit = (celsius * 9) / 5 + 32;
Console.WriteLine("Fahrenheit: " + fahrenheit);
double kelvin = celsius + 273;
Console.WriteLine("Kelvin: " + kelvin);




Console.ReadLine();


