﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC.Models;

namespace TCC.Controllers
{
    public class NotafiscalController : Controller
    {
        // GET: Notafiscal
        public ActionResult Index()
        {
            return View();
        }

        // GET: Notafiscal/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult List(Notafiscal notafiscal)
        {
            var notafiscalList = notafiscal.SelecionaNotafiscal();

            var objNotafiscal = new Notafiscal();
            objNotafiscal.SelecionaNotafiscal();
            return View(notafiscalList);
        }

        // GET: Notafiscal/Create
        public ActionResult Create()
        {
            return View();
        }



        // POST: Notafiscal/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Notafiscal/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Notafiscal/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Notafiscal/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Notafiscal/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
