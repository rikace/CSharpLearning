using System;
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
        
        public static void Run(int id)
        {
            CalculatorButton calcBtn = new CalculatorButton();

            string someName = "some name";

            calcBtn.Clicked += (object sender, ClickEventArgs e) =>
            {
                Console.WriteLine(
                    $"Caller is a CalculatorButton: {sender is CalculatorButton} and is named {e.Name} and " + someName);
            };

            calcBtn.SimulateClick();

            Console.ReadKey();
        }
    }
}