using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PG_Management_MongoDB.Services;

namespace PG_Management_MongoDB.Controllers
{
    public class TenantsController : Controller
    {
        private readonly TenantServices _tenantServices;

        public TenantsController(TenantServices _tenantServices)
        {
            this._tenantServices = _tenantServices;
        }
        // GET: Tenants
        public ActionResult Index()
        {
            return View(_tenantServices.Get());
        }

        // GET: Tenants/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tenants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tenants/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Tenants/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tenants/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Tenants/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tenants/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}