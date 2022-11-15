using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WorkshopVryDeepTest
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
            public const int Triptype = 2;
            public const int Routing_type = 3;
            public const int Ticketclass = 4;
            public const int DepartureDate = 5;
            public const int Origin = 6;
            public const int Destination = 7;
            public const int DestinationCountry = 8;
            public const int Carrier = 9;
            //Agency,Paid_fare,Triptype,Routing_type,Ticketclass,DepartureDate,Origin,Destination,DestinationCountry,Carrier

        }
        public interface IFetchFlightData
        {
            Flight[] FetchFlightData();
        }

        public class FileDataLoader : IFetchFlightData
        {
            private string filepath;
            public FileDataLoader(string filepath)
            {
                this.filepath = filepath;
            }
            public Flight[] FetchFlightData()
            {
                bool isFileExist = System.IO.File.Exists(this.filepath);
                if(isFileExist)
                {
                    List<Flight> flights = new List<Flight>();

                    //add loading code here
                    IEnumerable<string> lines = File.ReadLines(this.filepath);

                    foreach(var line in lines.Skip(1).Where(ln => !string.IsNullOrWhiteSpace(ln)))
                    {
                        string[] cells = line.Split(",");
                        if (double.TryParse(cells[FlightImportIndex.Paid_fare], out double paidfair))
                        {

                            var flight = new Flight()
                            {
                                Agency = cells[FlightImportIndex.Agency],
                                PaidFare = paidfair,
                                TripType = cells[FlightImportIndex.Triptype],
                                RoutingType = cells[FlightImportIndex.Routing_type],
                                DepartureDate = cells[FlightImportIndex.DepartureDate],
                                Carrier = cells[FlightImportIndex.Carrier],
                                Destination = cells[FlightImportIndex.Destination],
                                DestinationCountry = cells[FlightImportIndex.DestinationCountry],
                                Origin = cells[FlightImportIndex.Origin],

                            };
                            flights.Add(flight);
                        }
                    }

                    return flights.ToArray();
                }
                else
                {
                    throw new ArgumentException($"File path {this.filepath} Does not Exist");
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
            public string operand { get; private set; }
        public QueryCriteria(QueryCriteriaType querycriteriatype, string operand)
            {
            this.QueryCriteriaType = querycriteriatype;
            this.operand = operand;
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

        public void AddFilter(QueryCriteriaType querycriteriatype, string operand)
        {
            filters.Add(new QueryCriteria(querycriteriatype, operand));
            Console.WriteLine($"Added filter : {querycriteriatype} - {operand}");

        }

        public List<Flight> ExecuteQuery()
        {
            var query = flights.Select(f => f);
            var comparer = StringComparer.OrdinalIgnoreCase; 

            var filterdestination = CteateFilter(QueryCriteriaType.Destination);
            if(filterdestination.Any())
            {
                query = query.Where(flight => filterdestination.Contains(flight.Destination , comparer));
               // Console.WriteLine($"Destination {filterdestination}");
            }

            var filterorigin = CteateFilter(QueryCriteriaType.Origin);
            if (filterorigin.Any())
            {
                query = query.Where(flight => filterorigin.Contains(flight.Origin, comparer));
                //Console.WriteLine($"Origin {filterorigin}");
            }
            return query.ToList();

        }
        private List<string> CteateFilter(QueryCriteriaType querycriteriatype)
        {
            return
                filters.Where(filter => filter.QueryCriteriaType == querycriteriatype)
                .Select(filter => filter.operand)
                .ToList();
        }
    }
    class Program
    {

        static void RunFlightQuery(IFetchFlightData fetchdata)
        {
            var flights = fetchdata.FetchFlightData();

            //add query filter obj,
            //add filters
            //run query
            //get data

            FlightQuery flightquery = new FlightQuery(flights);
            flightquery.AddFilter(QueryCriteriaType.Destination, "London");
            flightquery.AddFilter(QueryCriteriaType.Origin, "Basel");


            var myFlights = flightquery.ExecuteQuery();

            foreach(var myFlight in myFlights)
            {
                Console.WriteLine($"Flight with Origin {myFlight.Origin} to {myFlight.Destination}");
                Console.WriteLine($"Flight with destination to {myFlight.Destination}");
            }


        }

        static void Main(string[] args)
        {
            string filepath = "./HMT_-_2011_Air_Data.csv";
            var loader = new FileDataLoader(filepath);


            RunFlightQuery(loader);

            Console.ReadLine();
        }
    }
}
