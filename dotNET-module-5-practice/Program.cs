using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Module5Homework
{
    internal class ModuleHomework
    {
        static void Main(string[] args)
        {
            // Example 1:
            // Web Request Exception Handling

            try
            {
                string url = "https://example.com/nonexistent_resource";

                using (WebClient client = new WebClient())
                {
                    client.DownloadString(url);
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("An error occurred while requesting a web resource: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Program completion (Example 1).");
            }

            // Example 2:
            // Handling IndexOutOfRangeException with an Array

            int[] numbers = { 1, 2, 3, 4, 5 };

            try
            {
                for (int i = 0; i <= numbers.Length; i++)
                {
                    Console.WriteLine(numbers[i]);
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("An exception occurred: Index out of array bounds.");
            }
            finally
            {
                Console.WriteLine("Array processing completed (Example 2).");
            }

            // Example 3:
            // Custom Exception Handling

            try
            {
                CallingMethod();
            }
            catch (CustomException ex)
            {
                Console.WriteLine($"An exception occurred: {ex.Message}");
            }

            // Example 4:
            // Custom Exception Propagation

            try
            {
                CallingMethod();
            }
            catch (CustomException ex)
            {
                Console.WriteLine($"An exception occurred: {ex.Message}");
            }

            Console.ReadLine();
        }

        static void CallingMethod()
        {
            try
            {
                SecondMethod();
            }
            catch (CustomException ex)
            {
                Console.WriteLine("Exception handled in the calling method.");
                throw;
            }
        }

        static void SecondMethod()
        {
            throw new CustomException("This is a custom exception from the second method.");
        }
    }

    class CustomException : Exception
    {
        public CustomException(string message) : base(message) { }
    }
}
