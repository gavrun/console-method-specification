namespace console_method_specification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");

            /* subject terms
             * 
             * mortgage is a money loan by a bank;
             * principal is an amount of owed by borrower to a bank;
             * interest rate is a percentage of the principal paid as a fee to the bank;
             * monthly payment is paid by the borrower to the bank, it covers one month worth of interest and extra reduced interest;
             */

            Console.WriteLine("\n");

            /* specification for program
             * 
             * this program tells me how much i'm going to save, and how much faster i'm going to pay it off, 
             * if i pay extra each month on the mortgage
             * 
             * program requests
             * input current principal
             * input current interest rate
             * input monthly payment
             * 
             * this program shows a variety of possible extra payment schemes
             * 
             * program displays
             * shows amount of interest saved
             * shows payoff date
             * 
             * unexpected issues?
             * if an invalid value is entered then an error message is displayed and the user is prompted to try again
             */

            Console.WriteLine("\n");


            /* method specification
             * 
             * purpose
             * repeatedly prompt the user until a valid positive (or zero) decimal is entered
             * name
             * ReadPositiveDecimal
             * has reciever?
             * no, static method
             * input
             * prompt string
             * output
             * positive decimal value
             * side effects
             * prints to console
             * error case 1
             * prompt must not be null
             */

            decimal principal = ReadPositiveDecimal("Enter current principal:");
            decimal interestRate = ReadPositiveDecimal("Enter interest rate:");
            decimal monthlyPayment = ReadPositiveDecimal("Enter desired monthly payment:");


        }

        static decimal ReadPositiveDecimal(string prompt)
        {
            decimal result;
            while (true)
            {
                Console.WriteLine(prompt); //"Enter current principal:"
                string principalText = Console.ReadLine();

                bool success = decimal.TryParse(principalText, out result);
                if (!success)
                {
                        Console.WriteLine("Enter a decimal value instead please");
                    else if (result < 0.0m)
                        Console.WriteLine("Enter a positive value please");
                    else
                        break;
                }
            }
            return result;
        }


    }
}