namespace SOLIDprinciples
{
    class Program
    {
        static void Main(string[] args)
        {

            // DIP
            DIP.Customer customer = new DIP.Customer(new DIP.FileLogger());
            customer.Add();
            
            
            // LSP
            LSP.COD cod = new LSP.COD();
            cod.ProcessTransaction();
            
            
            // OCP
            OCP.Checkout checkoutS = new OCP.Amazon();
            Console.WriteLine($"Shipping cost : {checkoutS.CalculateShippingCost(10)} ");

            Console.ReadKey();
        }
    }
}