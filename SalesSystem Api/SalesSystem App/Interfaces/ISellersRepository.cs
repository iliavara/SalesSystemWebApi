using SalesSystem_App.Models;
using SalesSystem_App.Requests;
using SalesSystem_App.Responses;
using System.Collections.Generic;

namespace SalesSystem_App.Interfaces
{
    public interface ISellersRepository
    {
        public void AddSeller(SellerRequest sellerRequest);
        public List<SellerResponse> Seller_get();
    }
}
