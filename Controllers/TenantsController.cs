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
        public ActionResult Create()
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
        public ActionResult Edit(string id, Tenant tenant)
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
                    _tenantServices.Update(id.ToString(),tenant);
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
        public ActionResult Delete(string id)
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

        // POST: Tenants/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, Tenant tenant)
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