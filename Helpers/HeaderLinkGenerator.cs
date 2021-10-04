using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static E_Commerce.Helpers.IHeaderLinkGenerator;

namespace E_Commerce.Helpers
{
    public class HeaderLinkGenerator : IHeaderLinkGenerator
    {
        private readonly IUrlHelper _helper;
        public HeaderLinkGenerator
            (
                IUrlHelperFactory urlHelperFactory,
                IActionContextAccessor context
            )
        {
            _helper = urlHelperFactory.GetUrlHelper(context.ActionContext);
        }

        public string GenerateLink(PageType pageType, string routeName, PaginationParameters paginationParameters, Object objectToCreate)
        {
            return pageType switch
            {
                PageType.Next => _helper.Link(routeName, objectToCreate),
                PageType.Previous => _helper.Link(routeName, objectToCreate),
                _ => _helper.Link(routeName, objectToCreate)
            };
        }
    }
}
