namespace course.Services
{
    public class PayPalService : IPaymentService
    {

        private const double FeePercentage = 0.02; 
        private const double MonthlyInterest = 0.01; 

        public double Interest(double amount, int months)
        {
            return amount * months * MonthlyInterest;
        }

        public double PaymentFee(double amount)
        {
            return amount * FeePercentage;
        }
    }
}
