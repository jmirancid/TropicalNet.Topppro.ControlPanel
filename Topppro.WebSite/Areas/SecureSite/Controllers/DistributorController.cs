﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Topppro.Business.Definitions;

namespace Topppro.WebSite.Areas.SecureSite.Controllers
{
    public class DistributorController :
        LayoutController<Topppro.Entities.Distributor, DistributorBusiness>
    {
        private readonly Lazy<CountryBusiness> _bizCountry =
            new Lazy<CountryBusiness>();

        private readonly Lazy<CultureBusiness> _bizCulture =
            new Lazy<CultureBusiness>();

        public override ActionResult Index()
        {
            return View();
        }

        public override System.Web.Mvc.JsonResult Index(string sEcho, string sSearch, int iSortCol_0, string sSortDir_0, int iDisplayStart, int iDisplayLength)
        {
            int count;
            IEnumerable<Topppro.Entities.Distributor> filtered;
            System.Linq.Expressions.Expression<Func<Topppro.Entities.Distributor, bool>> predicate;

            if (!string.IsNullOrEmpty(sSearch))
            {
                predicate =
                    x => x.Country.Name.ToLower().Contains(sSearch.ToLower())
                         || x.Culture.Name.ToLower().Contains(sSearch.ToLower())
                         || x.Name.ToLower().Contains(sSearch.ToLower());

                count =
                    base.Business.Value
                        .CountBy(predicate);

                filtered =
                    base.Business.Value
                        .FilterBy(iDisplayStart, iDisplayLength, predicate);
            }
            else
            {
                count =
                    base.Business.Value.Count();

                filtered =
                    base.Business.Value.Filter(iDisplayStart, iDisplayLength);
            }

            if (sSortDir_0 == "asc")
            {
                filtered = filtered.OrderBy(x =>
                                  (iSortCol_0 == 0) ? x.Country.Name
                                : (iSortCol_0 == 1) ? x.Culture.Name : x.Name);
            }
            else
            {
                filtered = filtered.OrderByDescending(x =>
                                  (iSortCol_0 == 0) ? x.Country.Name
                                : (iSortCol_0 == 1) ? x.Culture.Name : x.Name);
            }

            var data = filtered
                .Select(x => new { Id = x.Id, Country = x.Country.Name, Culture = x.Culture.Name, Name = x.Name, Priority = x.Priority, Enabled = x.Enabled });

            return
                Json(new
                {
                    sEcho = sEcho,
                    iTotalRecords = base.Business.Value.Count(),
                    iTotalDisplayRecords = count,
                    aaData = data
                }, JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        public override ActionResult Create(Entities.Distributor entity)
        {
            return base.Create(entity);
        }

        [ValidateInput(false)]
        public override ActionResult Edit(Entities.Distributor entity)
        {
            return base.Edit(entity);
        }

        [HttpPost]
        public ActionResult Toggle(int id)
        {
            try
            {
                var entity =
                    this.Business.Value.Get(id);

                entity.Enabled =
                    !entity.Enabled;

                this.Business.Value.Update(entity);

                return new HttpStatusCodeResult((int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                //throw ex;
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Content(ex.Message);
            }
        }

        public override void CreateGetPrerender(Topppro.Entities.Distributor entity = null)
        {
            ViewBag.Countries = new SelectList(this._bizCountry.Value.All(), "CountryId", "Name");
            ViewBag.Cultures = new SelectList(this._bizCulture.Value.All(), "CultureId", "Name");
        }

        public override void EditGetPrerender(Topppro.Entities.Distributor entity)
        {
            ViewBag.Countries = new SelectList(this._bizCountry.Value.All(), "CountryId", "Name", entity.CountryId);
            ViewBag.Cultures = new SelectList(this._bizCulture.Value.All(), "CultureId", "Name", entity.CultureId);
        }
    }
}
