using course.Entities;
using course.Services;
using System.Globalization;

Console.WriteLine("Enter contract data");
Console.Write("Number:");
int number = int.Parse(Console.ReadLine());
Console.Write("Date (dd/MM/yyyy): ");
DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
Console.Write("Contract value: ");
double totalValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

Console.Write("Enter number of installments: ");
int quantityInstallments = int.Parse(Console.ReadLine());


Contract myContract = new Contract(number, date, totalValue);

ContractService contractService = new ContractService(new PayPalService());
contractService.ProcessContract(myContract, quantityInstallments);

Console.WriteLine("Installments");
foreach (var item in myContract.Installments)
{
    Console.WriteLine(item);
}

