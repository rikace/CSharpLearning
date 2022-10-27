using System;
using System.IO;

namespace SOLIDprinciples.SRP
{
    public class Customer
    {
        void Add()
        {
            try
            {
                // Adding logic
            }
            catch (Exception ex)
            {
                FileLogger logger = new FileLogger();
                logger.Handle(ex.Message);
            }
        }
    }

    public class FileLogger
    {
        public void Handle(string error)
        {
            File.WriteAllText(@"C:\Error.txt", error);
        }
    }
}