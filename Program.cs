using System.Text.RegularExpressions;

class TemperatureConverter {
    public static void Main () {
        string? input;
        string pattern = @"^(\d|-|\.)[.\d]* [CFK]$";
        do {
            Console.WriteLine("Please enter a temperature value and its unit of measurement (F, C, or K) separated by a space, or 'exit' to quit the program.");
            input = Console.ReadLine();
            if (input is not null && input.Equals("exit"))
            {
                Console.WriteLine("Thank you for using this converter! Goodbye!");
                break;
            }
            else if (input is not null && Regex.IsMatch(input, pattern))
            {
                ConvertTemperature(input);
            } 
            else
            {
                Console.WriteLine("Incorrect input format.");
            }  
        } while (true); 
        static void ConvertTemperature(string input) {
            string[] result = input.Split(' ');
            float temperature = float.Parse(result[0]);
            string unit = result[1];
            if (unit.Equals("C"))
            {
                Console.WriteLine($"{input} is {(temperature * 9/5) + 32} F or {temperature + 273.15} K.");
            }
            else if (unit.Equals("F")) {
                Console.WriteLine($"{input} is {(temperature - 32) * 5/9} C or {(temperature - 32) * 5/9 + 273.15} K.");
            }
            else if (unit.Equals("K")) {
                Console.WriteLine($"{input} is {temperature  - 273.15} C or {(temperature - 273.15)  * 9/5 + 32} F.");
            }
        }
    }
}