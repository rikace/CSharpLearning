using System;
using System.Collections.Generic;
using System.Text;

namespace WorkshopVary.FlightQuery
{
    public interface IFlightsLoader
    {
        Flight[] Load();
    }
}
