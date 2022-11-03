using System;
namespace EventDelegate.Events
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
    }
    public class Events
    {
        public static void Run()
        {
            Events prg = new Events();
            CalculatorButton calcBtn = new CalculatorButton();

            calcBtn.Clicked += new ClickHandler(prg.CalculatorBtnClicked);
         
            calcBtn.Clicked += CalcBtn_Clicked;

            calcBtn.SimulateClick();

            Console.ReadKey();
        }

      
        private static void CalcBtn_Clicked(object sender, ClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void CalculatorBtnClicked(object sender, ClickEventArgs e)
        {
            Console.WriteLine(
                $"Caller is a CalculatorButton: {sender is CalculatorButton} and is named {e.Name}");
        }
    }
}