using System.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PG_Management_MongoDB.Models;
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
        [HttpGet]
        public IActionResult Details(string id)
        {
            if(id!=null)
            {
                Tenant tenant= _tenantServices.Get(id);
                return View(tenant);
            }
            return NotFound();
        }
        //GET: Tenants/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        // POST: Tenants/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tenant tenant)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        if(String.Compare(tenant.PaidStatusValue.ToString(),"Yes")==0)
                        {
                            tenant.PaidStatus = true;
                        }
                        else
                        {
                            tenant.PaidStatus = false;
                        }
                    }
                    catch
                    {
                        tenant.PaidStatus = false;
                    }
                    _tenantServices.Create(tenant);
                    return RedirectToAction(nameof(Index));
                }

                return View(tenant);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: Tenants/Edit/5
        public IActionResult Edit(string id)
        {
            
            if(id==null)
            {
                return NotFound();
            }
            var tenant = _tenantServices.Get(id.ToString());
            if(tenant==null)
            {
                return NotFound();
            }
            return View(tenant);
        }

        // POST: Tenants/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, Tenant tenant)
        {
            try
            {
                if(id!=tenant.Id)
                {
                    return NotFound();
                }
                if(ModelState.IsValid)
                {
                    try
                    {
                        if(String.Compare(tenant.PaidStatusValue.ToString(),"Yes")==0)
                        {
                            tenant.PaidStatus = true;
                        }
                        else
                        {
                            tenant.PaidStatus = false;
                        }
                    }
                    catch
                    {
                        tenant.PaidStatus = false;
                    }
                    _tenantServices.Update(id,tenant);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(tenant);
                }

                
            }
            catch
            {
                return View();
            }
        }

        // GET: Tenants/Delete/5
        public IActionResult Delete(string id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var tenant = _tenantServices.Get(id.ToString());
            if(tenant==null)
            {
                return NotFound();
            }
            return View(tenant);
        }
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public IActionResult Cancel()
        // {
        //     return RedirectToAction(nameof(Index));
        // }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cancel(string id,Tenant tenant)
        {
            return RedirectToAction(nameof(Index));
        }

        // POST: Tenants/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string id, Tenant tenant)
        {
            try
            {
                if (id!=null)
                {
                    _tenantServices.Remove(tenant);
                }
                else
                {
                    return BadRequest();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}