namespace FTask.Shared.Helpers
{
    public abstract class QueryStringParameters
    {
        const int maxPageSize = 250;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 200;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
