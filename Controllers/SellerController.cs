using MeenaBazar.Models;
using MeenaBazar.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeenaBazar.Controllers
{
    public class SellerController : Controller
    {
        // GET: Seller
        public ActionResult AllSeller()
        {
            SellerRepository sellerRepository = new SellerRepository();
            ModelState.Clear();
            return View(sellerRepository.AllSeller());
        }

        // GET: Seller/Create
        public ActionResult AddSeller()
        {
            return View();
        }

        // POST: Seller/Create
        [HttpPost]
        public ActionResult AddSeller(Seller seller)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SellerRepository sellerRepository = new SellerRepository();

                    if (sellerRepository.AddSeller(seller))
                    {
                        ViewBag.Message = "Seller added sucessfully";
                    }
                }

                return RedirectToAction("AllSeller");
            }
            catch
            {
                return View();
            }
        }

        // GET: Seller/Edit/5
        public ActionResult UpdateSeller(int id)
        {
            SellerRepository sellerRepository = new SellerRepository();

            return View(sellerRepository.AllSeller().Find(Seller=>Seller.SellerId==id));
        }

        // POST: Seller/Edit/5
        [HttpPost]
        public ActionResult UpdateSeller(int id, Seller obj)
        {
            try
            {
                SellerRepository sellerRepository = new SellerRepository();

                sellerRepository.UpdateSeller(obj);

                return RedirectToAction("AllSeller");
            }
            catch
            {
                return View();
            }
        }
        
        // POST: Seller/Delete/5
        public ActionResult DeleteSeller(int id)
        {
            try
            {
                SellerRepository sellerRepository = new SellerRepository();
                if (sellerRepository.DeleteSeller(id))
                {
                    ViewBag.Alertmsg = "Seller Deleted Sucessfully";
                }

                return RedirectToAction("AllSeller");
            }
            catch
            {
                return View();
            }
        }
    }
}
