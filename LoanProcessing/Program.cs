namespace CSharp.Activity.Delegates
{
    internal class Program
    {

        public static void Show(LoanApplicant loanApplicant)
        {
            Console.WriteLine("The Credit score of the applicant is " + loanApplicant.CreditScore);
        }

        static void Main(string[] args)
        {
            LoanSystem loanSystem = new LoanSystem();
            loanSystem.ProcessLoanApplication(Show);
        }
    }
}
