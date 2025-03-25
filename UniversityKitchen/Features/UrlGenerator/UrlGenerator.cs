using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;

namespace UniversityKitchen.Features.UrlGenerator;

public class UrlGenerator : IUrlGenerator
{
    private readonly IUrlHelper _url;
    
    public UrlGenerator(IUrlHelperFactory urlHelperFactory, IActionContextAccessor actionContextAccessor)
    {
        _url = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
    }
    
    public string GenerateUrl(string action, string controller)
    {
        return _url.Action(action, controller) ?? "#";
    }
}