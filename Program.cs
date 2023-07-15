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
             * has receiver?
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

            decimal principal;
            decimal interestRate;
            decimal monthlyPayment;

            while (true)
            {
                principal = ReadPositiveDecimal("Enter current principal:");
                interestRate = ReadPositiveDecimal("Enter interest rate:");
                monthlyPayment = ReadPositiveDecimal("Enter desired monthly payment:");

                if (principal * interestRate / 1200 < monthlyPayment)
                {
                    break;
                }
                Console.WriteLine("Sorry, the monthly payment does not cover the interest");
            }

            /* method specification
             * 
             * purpose
             * compute toatl interest paid on the load given principle, interest rate, and monthly payment as decimal values
             * name
             * TotalInterest
             * has receiver?
             * no, static method
             * input
             * three decimal values
             * output
             * one decimal value
             * side effects
             * none
             * error case 1
             * input values must be positive
             */

            decimal totalInterest = TotalInterest(principal, interestRate, monthlyPayment);

            /* method specification
             * 
             * purpose
             * compute number of months to pay off the loan given principal, interest rate, and monthly payment as decimal values
             * name
             * PayoffMonths
             * has receiver?
             * no, static method
             * input
             * three decimal values
             * output
             * integer value
             * side effects
             * none
             * error case 1
             * input values must be positive
             */

            int totalMonths = PayoffMonths(principal, interestRate, monthlyPayment);
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

        static decimal TotalInterest(decimal principal, decimal interestRate, decimal monthlyPayment)
        {
            if (principal < 0.0m)
                throw new ArgumentException("principal must be positive", "principal");
            if (interestRate < 0.0m)
                throw new ArgumentException("interest rate must be positive", "interestRate");
            if (monthlyPayment < 0.0m)
                throw new ArgumentException("monthly payment must be positive", "monthlyPayment");
            if (principal * interestRate / 1200 >= monthlyPayment)
                throw new ArgumentException("monthly payment does not cover interest", "monthlyPayment");

            decimal totalInterest = 0.0m;
            decimal currentPrincipal = principal;
            while (0.0m < currentPrincipal)
            {
                decimal currntInterest = currentPrincipal * interestRate / 1200;
                decimal reduction = monthlyPayment - currntInterest;
                currentPrincipal = currntInterest - reduction;
                totalInterest = totalInterest + currntInterest;
            }
            return totalInterest;
        }

        static int PayoffMonths(decimal principal, decimal interestRate, decimal monthlyPayment)
        {
            if (principal < 0.0m)
                throw new ArgumentException("principal must be positive", "principal");
            if (interestRate < 0.0m)
                throw new ArgumentException("interest rate must be positive", "interestRate");
            if (monthlyPayment < 0.0m)
                throw new ArgumentException("monthly payment must be positive", "monthlyPayment");
            if (principal * interestRate / 1200 >= monthlyPayment)
                throw new ArgumentException("monthly payment does not cover interest", "monthlyPayment");

            int totalMonths = 0;
            decimal currentPrincipal = principal;
            while (0 < currentPrincipal)
            {
                decimal currentInterest = currentPrincipal * interestRate / 1200;
                decimal reduction = monthlyPayment - currentInterest;
                currentPrincipal = currentPrincipal - monthlyPayment;
                totalMonths += 1;
            }
            return totalMonths;
        }

    }
}