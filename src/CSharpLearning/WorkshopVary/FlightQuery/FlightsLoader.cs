using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WorkshopVary.FlightQuery
{
    public class FlightsLoader : IFlightsLoader
    {
        private readonly string filePath;
        public FlightsLoader(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException($"'{nameof(filePath)}' cannot be null or empty.", nameof(filePath));
            }
            this.filePath = filePath;
        }

        public Flight[] Load()
        {
            bool isFileExists = File.Exists(filePath);
            if (isFileExists)
            {
                // string[] lines = File.ReadAllLines(filePath);
                IEnumerable<string> rows = File.ReadLines(filePath);

                List<Flight> flights = new List<Flight>();

                foreach (var row in rows.Skip(1).Where(ln => !string.IsNullOrWhiteSpace(ln)))
                {
                    string[] cells = row.Split(",");

                    bool parseSuccesfull = double.TryParse(cells[FlightIndex.PaidFare], out double paidFare);
                    if (parseSuccesfull)
                    {
                        var flight = new Flight
                        {
                            Agency = cells[FlightIndex.Agency],
                            Carrier = cells[FlightIndex.Carrier],
                            DepartureDate = cells[FlightIndex.DepartureDate],
                            Destination = cells[FlightIndex.Destination],
                            DestinationCountry = cells[FlightIndex.DestinationCountry],
                            Origin = cells[FlightIndex.Origin],
                            PaidFare = paidFare,
                            RoutingType = cells[FlightIndex.RoutingType],
                            TripType = cells[FlightIndex.TripType]
                        };
                        flights.Add(flight);
                    }
                }


                return flights.ToArray();

            }
            else
            {
                throw new FileLoadException($"File {filePath} does not exist");
            }
        }
    }
}
