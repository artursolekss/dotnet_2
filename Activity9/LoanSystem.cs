namespace CSharp.Activity.Delegates
{
    public class LoanSystem
    {
        public delegate void showApplicant(LoanApplicant loanApplicant); //declaring a delegate

        public void ProcessLoanApplication(Action<LoanApplicant> showApplicant)
        {

            Random random = new Random();
            int creditScore = random.Next(1, 100);

            LoanApplicant loanApplicant = new LoanApplicant();
            loanApplicant.CreditScore = creditScore;

            showApplicant(loanApplicant);

        }

    }
}
