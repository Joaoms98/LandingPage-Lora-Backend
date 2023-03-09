namespace LandingPage.Lora.Core.Utils
{
    public class PagedList<T>
    {
        private IQueryable<T> _Query;
        public int Page
        {
            get
            {
                return _Page;
            }
        }

        public int PageSize
        {
            get
            {
                return _PageSize;
            }
        }

        public int Total
        {
            get
            {
                return _Total;
            }
        }

        public List<T> Items
        {
            get
            {
                return _Items;
            }
        }

        public int LastPage
        {
            get
            {
                if (Total < PageSize)
                    return 1;
                else if (Total % PageSize == 0)
                    return Convert.ToInt32(Total / PageSize);
                else 
                    return Convert.ToInt32(Math.Truncate(Convert.ToDouble(Total / PageSize))) + 1;
            }
        }

        private List<T> _Items;
        private int _Total;
        private int _Page;
        private int _PageSize;
        public PagedList(IQueryable<T> query, int page, int pageSize)
        {
            _Query = query;
            _Page = page < 1 ? 1 : page;
            _PageSize = pageSize;
            _Total = _Query.Count();
            _Items = _Query
                .Skip((_Page - 1) * _PageSize)
                .Take(_PageSize)
                .ToList();
        }

        public PagedList(IEnumerable<T> items, int page, int pageSize, int Total)
        {
            _Page = page < 1 ? 1 : page;
            _PageSize = pageSize;
            _Total = Total;
            _Items = items
                .ToList();
        }
    }
}