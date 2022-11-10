using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace WorkshopVary
{
    public class Flight
    {
        public string Agency { get; set; }
        public double PaidFare { get; set; }
        public string TripType { get; set; }
        public string RoutingType { get; set; }
        public string DepartureDate { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string DestinationCountry { get; set; }
        public string Carrier { get; set; }
    }

    public class FlightImportIndex
    {
        public const int Agency = 0;
        public const int Paid_fare = 1;
        public const int TripType = 2;
        public const int Routing_type = 3;
        public const int TicketClass = 4;
        public const int DepartureDate = 5;
        public const int Origin = 6;
        public const int Destination = 7;
        public const int DestinationCountry = 8;
        public const int Carrier = 9;
    }

    public enum FlightImportIndexEnum
    {
        Agency = 0,
        Paid_fare = 1,
        TripType = 2,
        Routing_type = 3,
        TicketClass = 4,
        DepartureDate = 5,
        Origin = 6,
        Destination = 7,
        DestinationCountry = 8,
        Carrier = 9
    }

    public interface IFetchFlightsData
    {
        Flight[] FetchFlightsData();
    }

    public class FileDataLoader : IFetchFlightsData
    {
        private string filePath;
        public FileDataLoader(string filePath)
        {
            this.filePath = filePath;
        }

        public Flight[] FetchFlightsData()
        {
            bool isFileExist = File.Exists(this.filePath);
            if (isFileExist)
            {
                List<Flight> flights = new List<Flight>();

                // add loading code here
                IEnumerable<string> lines = File.ReadLines(this.filePath);

                foreach (var line in lines.Skip(1).Where(ln => !string.IsNullOrWhiteSpace(ln)))
                {
                    // Header Agency,Paid_fare,Trip type,Routing_type,Ticket class,Departure Date,Origin,Destination,Destination Country,Carrier

                    // Data [HR, 10/10/2019...
                    string[] cells = line.Split(",");

                    if (double.TryParse(cells[FlightImportIndex.Paid_fare], out double paidFare))
                    {
                        var flight = new Flight()
                        {
                            Agency = cells[FlightImportIndex.Agency],
                            PaidFare = paidFare,
                            TripType = cells[FlightImportIndex.TripType],
                            RoutingType = cells[FlightImportIndex.Routing_type],
                            DepartureDate = cells[FlightImportIndex.DepartureDate],
                            Carrier = cells[FlightImportIndex.Carrier],
                            Destination = cells[FlightImportIndex.Destination],
                            DestinationCountry = cells[FlightImportIndex.DestinationCountry],
                            Origin = cells[FlightImportIndex.Origin]
                        };
                        flights.Add(flight);
                    }
                }
                return flights.ToArray();
            }
            else
            {
                throw new ArgumentException($"File Path {this.filePath} does not exist");
            }
        }
    }

    public enum QueryCriteriaType
    {
        Origin,
        Destination
    }

    public class QueryCriteria
    {
        public QueryCriteriaType QueryCriteriaType { get; private set; }
        public string Operand { get; private set; }
        public QueryCriteria(QueryCriteriaType queryCriteriaType, string operand)
        {
            this.QueryCriteriaType = queryCriteriaType;
            this.Operand = operand;
        }
    }

    public class FlightQuery
    {
        private Flight[] flights;
        private List<QueryCriteria> filters = new List<QueryCriteria>();

        public FlightQuery(Flight[] flights)
        {
            this.flights = flights;
        }

        public void AddFilter(QueryCriteriaType queryCriteriaType, string operand)
        {
            filters.Add(new QueryCriteria(queryCriteriaType, operand));
            Console.WriteLine($"Added filter : {queryCriteriaType} - {operand}");
        }

        public List<Flight> ExecuteQuery()
        {
            var query = flights.Select(f => f);

            var comparer = StringComparer.OrdinalIgnoreCase;

            var filtersDestination = CreateFilter(QueryCriteriaType.Destination);
            if (filtersDestination.Any())
            {
                query = query.Where(flight => filtersDestination.Contains(flight.Destination, comparer));
                Console.WriteLine($"Destination {filtersDestination}");
            }

            var filtersOrigin = CreateFilter(QueryCriteriaType.Origin);
            if (filtersOrigin.Any())
            {
                query = query.Where(flight => filtersOrigin.Contains(flight.Origin, comparer));
                Console.WriteLine($"Origin {filtersOrigin}");
            }

            return query.ToList();
        }

        private List<string> CreateFilter(QueryCriteriaType queryCriteriaType)
        {
            return
                    filters.Where(filter => filter.QueryCriteriaType == queryCriteriaType)
                    .Select(filter => filter.Operand)
                    .ToList();
        }
    }

    class Program
    {
        static void RunFlightQuery(IFetchFlightsData fetchData)
        {
            // download data
            // parse the data 

            var flights = fetchData.FetchFlightsData();

            // create instance query/filter object 
            // add filters
            // run query
            // get data
            FlightQuery flightQuery = new FlightQuery(flights);

            flightQuery.AddFilter(QueryCriteriaType.Destination, "Basel");
            flightQuery.AddFilter(QueryCriteriaType.Origin, "London");

            var myFlights = flightQuery.ExecuteQuery();

            foreach (var myFlight in myFlights)
            {
                Console.WriteLine($"Flight with destination to {myFlight.Destination}");
            }
        }


        static void Main(string[] args)
        {
            string filePath = "./HMT_-_2011_Air_Data.csv";
            var loader = new FileDataLoader(filePath);


            RunFlightQuery(loader);
            // TODO 
            // Expand support filter for TripType....
            // Ovveride ToString of teh flight class for better pretty print 
            // Add some Cool logs 



            // - Flight CSV query            
            // - Tic Tac Toe 
            /*
                __|__|__
                __|__|__
                  |  |        
             */

            // Fizz Buzz review


            Console.ReadLine();
        }
    }
}
