
using Projeto.Commons.Logger;
using Projeto.Models;
using Projeto.Models.Enums;
using Projeto.Repository;
using Projeto.Services;
using Serilog;
using Serilog.Sinks.SystemConsole;

public class Program
{
    static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

        var Transactions = new List<TransactionData>
            {
                new TransactionData(1, "09/09/2023 14:15:00", 938485762, 2147483649, 150),
                new TransactionData(2, "09/09/2023 14:15:05", 2147483649, 210385733, 149),
                new TransactionData(3, "09/09/2023 14:15:29", 347586970, 238596054, 1100),
                new TransactionData(4, "09/09/2023 14:17:00", 675869708, 210385733, 5300),
                new TransactionData(5, "09/09/2023 14:18:00", 238596054, 674038564, 1489),
                new TransactionData(6, "09/09/2023 14:18:20", 573659065, 563856300, 49),
                new TransactionData(7, "09/09/2023 14:19:00", 938485762, 2147483649, 44),
                new TransactionData(8, "09/09/2023 14:19:01", 573659065, 675869708, 150),
            };

        var dataAccess = new DataAccess();
        var transactionLogger = new SerilogTransactionLogger();
        var transactionExecutor = new TransactionExecutor(dataAccess, transactionLogger);

        Parallel.ForEach(Transactions, item =>
        {
            transactionExecutor.ProcessTransaction(item);
        });
    }
}