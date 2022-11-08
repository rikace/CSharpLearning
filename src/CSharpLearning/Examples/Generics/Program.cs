using System;
using Generic;

public class Program
{
    public static void Main()
    {
        var rpt = (CustomerReport)ReportFactory.Create(typeof(CustomerReport));
        var rpt2 = ReportFactory.Create<CustomerReport>();

        Console.ReadKey();
    }
}