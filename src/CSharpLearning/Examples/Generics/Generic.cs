namespace Generic
{
    using System;
    
    public interface IReport
    {
        DateTime Date { get; set; }
    }

    public abstract class Report { }

    
    public class CustomerReport : Report, IReport
    {
        public DateTime Date { get; set; }
    }

    public class OrdersReport : Report, IReport
    {
        public DateTime Date { get; set; }
    }

    public class GenericDemo
    {
        public static void RUn()
        {
            var rpt = (CustomerReport)ReportFactory.Create(typeof(CustomerReport));
            var rpt2 = ReportFactory.Create<CustomerReport>();

            Console.ReadKey();
        }
    }
}