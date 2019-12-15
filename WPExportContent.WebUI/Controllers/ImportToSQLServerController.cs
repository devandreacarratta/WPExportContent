using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WPExportContent.Core.DataAccess;
using WPExportContent.Core.Export;
using WPExportContent.Core.WordPress;
using WPExportContent.WebUI.Models;

namespace WPExportContent.WebUI.Controllers
{
    public class ImportToSQLServerController : Controller
    {

        public async Task<IActionResult> ConvertJSONToSQL(ImportToSQLServerDTO values)
        {
            if (values.contents.Length == 0)
            {
                return null;
            }

            WPExportResult wp = new WPExportResult();

            using (var ms = new MemoryStream())
            {
                values.contents.CopyTo(ms);
                var fileBytes = ms.ToArray();
                string json = Encoding.ASCII.GetString(fileBytes);

                wp = Newtonsoft.Json.JsonConvert.DeserializeObject<WPExportResult>(json);

            }

            if (wp == null)
            {
                return null;
            }


            ISQLEngine engine = new SQLServerEngine(values.ConnectionString);
                        ExportToDatabase export = new ExportToDatabase(engine);
            var result = await export.Run(wp);

            StringBuilder sb = new StringBuilder();
            foreach (var item in result)
            {
                sb.AppendFormat("{0}: {1} {2} ", item.Key, item.Value, Environment.NewLine);
            }

            string log = sb.ToString();

            return View("Index");
        }    

        // GET: ImportToSQLServer
        public ActionResult Index()
        {
            return View();
        }

        // GET: ImportToSQLServer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ImportToSQLServer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImportToSQLServer/Create
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

        // GET: ImportToSQLServer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ImportToSQLServer/Edit/5
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

        // GET: ImportToSQLServer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ImportToSQLServer/Delete/5
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