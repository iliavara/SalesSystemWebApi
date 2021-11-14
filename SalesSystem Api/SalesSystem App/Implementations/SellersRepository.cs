using SalesSystem_App.Interfaces;
using SalesSystem_App.Models;
using SalesSystem_App.Requests;
using SalesSystem_App.Responses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesSystem_App.Implementations
{
    public class SellersRepository : ISellersRepository
    {
        private readonly DataContext _context;

        public SellersRepository(DataContext context)
        {
            _context = context;
        }
        public void AddSeller(SellerRequest sellerRequest)
        {
            var sellerModel = new SellerModel()
            {
                Seller_boss_id = sellerRequest.Seller_boss_id,
                Seller_fname = sellerRequest.Seller_fname,
                Seller_lname = sellerRequest.Seller_lname
            };

            _context.Add(sellerModel);
            _context.SaveChanges();
        }


        public List<SellerResponse> Seller_get()
        {
            var parent_sellers = _context.SellerModels.Where(x => x.Seller_boss_id == x.Seller_id).ToList();
            List<SellerResponse> sellerResponse_list = new List<SellerResponse>();

            foreach (var p in parent_sellers)
            {
                string parent_name = p.Seller_fname;
                var parent = p;
                List<string> children_names = new List<string>();
                var child = _context.SellerModels.Where(x => x.Seller_boss_id == parent.Seller_id).FirstOrDefault();
                children_names.Add(child.Seller_fname);
                while (child != null)
                {
                    parent = child;
                    child = _context.SellerModels.Where(x => x.Seller_boss_id == parent.Seller_id).FirstOrDefault();
                    children_names.Add(child.Seller_fname);
                }
                SellerResponse sellerResponse = new SellerResponse();
                sellerResponse.ParentName = parent_name;
                sellerResponse.ChildNames = children_names;
                sellerResponse_list.Add(sellerResponse);
            }

            return sellerResponse_list;
        }
    }
}
