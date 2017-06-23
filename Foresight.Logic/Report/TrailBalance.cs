namespace Foresight.Logic.Report
{
   public class TrialBalance
    {
       public string AccountId { get; set; }
       public string ChartOfAccountName { get; set; }
       public string AccountName { get; set; }
       public decimal Opening { get; set; }
       public decimal TransactionCredit { get; set; }
       public decimal TransactionDebit{ get; set; }
       public decimal Closing { get; set; }
    }
}
