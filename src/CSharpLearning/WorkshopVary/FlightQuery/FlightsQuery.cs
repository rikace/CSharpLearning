using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkshopVary.FlightQuery
{
    public class FlightsQuery
    {
        public FlightsQuery(Flight[] flights)
        {
            this.flights = flights;
        }

        private List<QueryCriteria> filters = new List<QueryCriteria>();
        private readonly Flight[] flights;

        public void AddFilter(QueryCriteriaType queryCriteriaType, string input)
        {
            filters.Add(new QueryCriteria(queryCriteriaType, input));
        }

        public List<Flight> Execute()
        {
            IEnumerable<Flight> query = flights.Select(f => f);

            var comparer = StringComparer.OrdinalIgnoreCase;

            var filterDestination = CreateFilter(QueryCriteriaType.Destination);
            if (filterDestination.Any())
            {
                query = query.Where(flight => filterDestination.Contains(flight.Destination, comparer));
            }

            var filterOrigin = CreateFilter(QueryCriteriaType.Origin);
            if (filterOrigin.Any())
            {
                query = query.Where(flight => filterOrigin.Contains(flight.Origin, comparer));
            }

            return query.ToList();
        }

        private List<string> CreateFilter(QueryCriteriaType queryCriteriaType)
        {
            return filters.Where(filter => filter.queryCriteriaType == queryCriteriaType)
                        .Select(filter => filter.input)
                        .ToList();
        }
    }
}