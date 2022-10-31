namespace EventDelegate
{
    public delegate void ClickHandler(object sender, ClickEventArgs e);
    
    public class ClickEventArgs : EventArgs
    {
        public string Name { get; set; }
    }
    
    public class CalculatorButton
    {
        public event ClickHandler Clicked;
        public void SimulateClick()
        {
            if (Clicked != null)
            {
                ClickEventArgs args = new ClickEventArgs();
                args.Name = "Add";

                Clicked(this, args);
            }
        }
        
        public static void Run()
        {
            CalculatorButton calcBtn = new CalculatorButton();

            calcBtn.Clicked += (object sender, ClickEventArgs e) =>
            {
                Console.WriteLine(
                    $"Caller is a CalculatorButton: {sender is CalculatorButton} and is named {e.Name}");
            };

            calcBtn.SimulateClick();

            Console.ReadKey();
        }
    }
}