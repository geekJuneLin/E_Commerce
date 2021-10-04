using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Helpers
{
    public class PaginationParameters
    {
        private int pageSize = 5;
        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                // If value less than 1, then set to be 1
                if (value < 1)
                {
                    PageSize = 1;
                }
                // If value greater than the maxPageSize, then set to be 50
                if (value > 50)
                {
                    pageSize = maxPageSize;
                }
                pageSize = value;
            }
        }
        private int pageNumber = 1;
        public int PageNumber {
            get {
                return pageNumber;
            } 
            set {
                // If value less than 1, then set to be 1
                if (value < 1)
                {
                    pageNumber = 1;
                }
                pageNumber = value;
            } 
        }

        private const int maxPageSize = 50;
    }
}
