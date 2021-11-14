using System.Collections.Generic;

namespace SalesSystem_App.Responses
{
    public class SellerResponse
    {
       public string ParentName { get; set; }
       public List<string> ChildNames { get; set; }
    }
}
