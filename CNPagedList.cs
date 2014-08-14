using System.Linq;

namespace CN.Core
{
    /// <summary>
    /// A class that handles pagination of an IQueryable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CNPagedList<T>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="list">The full list of items you would like to paginate</param>
        /// <param name="page">(optional) The current page number</param>
        /// <param name="pageSize">(optional) The size of the page</param>
        public CNPagedList(IQueryable<T> list, int?page=null, int?pageSize=null)
        {
            _list = list;
            _page = page;
            _pageSize = pageSize;
        }

        private IQueryable<T> _list;
        
        /// <summary>
        /// The paginated result
        /// </summary>
        public IQueryable<T> items
        {
            get
            {
                if (_list == null) return null;
                return _list.Skip((page - 1) * pageSize).Take(pageSize);
            }
        }

        private int? _page;
        /// <summary>
        ///  The current page.
        /// </summary>
        public int page
        {
            get
            {
                if (!_page.HasValue)
                {
                    return 1;
                }
                else
                {
                    return _page.Value;
                }
            }
        }

        private int? _pageSize;
        /// <summary>
        /// The size of the page.
        /// </summary>
        public int pageSize
        {
            get
            {
                if (!_pageSize.HasValue)
                {
                    return _list == null ? 0 : _list.Count();
                }
                else
                {
                    return _pageSize.Value;
                }
            }
        }

        /// <summary>
        /// The total number of items in the original list of items.
        /// </summary>
        public int totalItemCount
        {
            get
            {
                return _list == null ? 0 : _list.Count();
            }
        }
    }
}
