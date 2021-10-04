using System;

namespace E_Commerce.Helpers
{
    public interface IHeaderLinkGenerator
    {
        enum PageType
        {
            Next,
            Previous
        }

        public string GenerateLink(PageType pageType, string routeName, PaginationParameters paginationParameters, Object objectToCreate);
    }
}