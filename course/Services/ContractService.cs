using course.Entities;

namespace course.Services
{
    public class ContractService
    {

        IPaymentService _payment;

        public ContractService(IPaymentService payment)
        {
            _payment = payment;
        }

        public void ProcessContract(Contract contract, int months)
        {
            double basicQuota = contract.TotalValue / months; 
            for (int i = 1; i <= months; i++)
            {
                DateTime date = contract.Date.AddMonths(i);
                double updateQuota = basicQuota + _payment.Interest(basicQuota, i);
                double fullQuota = updateQuota + _payment.PaymentFee(updateQuota);
                contract.AddInstallment(new Installment(date, fullQuota));
            }
        }

    }
}
