namespace WorkshopVary.FlightQuery
{
    public enum QueryCriteriaType
    {
        Destination,
        Origin,
        Carrier
    }

    class QueryCriteria
    {
        public readonly QueryCriteriaType queryCriteriaType;
        public readonly string input;

        public QueryCriteria(QueryCriteriaType queryCriteriaType, string input)
        {
            this.queryCriteriaType = queryCriteriaType;
            this.input = input;
        }
    }
}
