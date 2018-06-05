using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RentApp.Models.Entities;
using RentApp.Persistance;
using RentApp.Persistance.UnitOfWork;

namespace RentApp.Controllers
{
    public class PricelistItemsController : ApiController
    {
        private IUnitOfWork db;

        public PricelistItemsController(IUnitOfWork context)
        {
            db = context;
        }

        // GET: api/PricelistItems
        public IEnumerable<PricelistItem> GetPricelistItems()
        {
            return db.PricelistItems.GetAll();
        }

        // GET: api/PricelistItems/5
        [ResponseType(typeof(PricelistItem))]
        public IHttpActionResult GetPricelistItem(int id)
        {
            PricelistItem pricelistItem = db.PricelistItems.Get(id);
            if (pricelistItem == null)
            {
                return NotFound();
            }

            return Ok(pricelistItem);
        }

        // PUT: api/PricelistItems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPricelistItem(int id, PricelistItem pricelistItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pricelistItem.Id)
            {
                return BadRequest();
            }

            db.PricelistItems.Update(pricelistItem);
            db.Complete();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PricelistItems
        [ResponseType(typeof(PricelistItem))]
        public IHttpActionResult PostPricelistItem(PricelistItem pricelistItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PricelistItems.Add(pricelistItem);
            db.Complete();

            return CreatedAtRoute("DefaultApi", new { id = pricelistItem.Id }, pricelistItem);
        }

        // DELETE: api/PricelistItems/5
        [ResponseType(typeof(PricelistItem))]
        public IHttpActionResult DeletePricelistItem(int id)
        {
            PricelistItem pricelistItem = db.PricelistItems.Get(id);
            if (pricelistItem == null)
            {
                return NotFound();
            }

            db.PricelistItems.Remove(pricelistItem);
            db.Complete();

            return Ok(pricelistItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool PricelistItemExists(int id)
        //{
        //    return db.PricelistItems.Count(e => e.Id == id) > 0;
        //}
    }
}