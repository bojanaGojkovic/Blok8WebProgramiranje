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
    public class UserFeedbacksController : ApiController
    {
        private IUnitOfWork db;

        public UserFeedbacksController(IUnitOfWork context)
        {
            db = context;
        }

        // GET: api/UserFeedbacks
        public IEnumerable<UserFeedback> GetUserFeedbacks()
        {
            return db.UserFeedbacks.GetAll();
        }

        // GET: api/UserFeedbacks/5
        [ResponseType(typeof(UserFeedback))]
        public IHttpActionResult GetUserFeedback(int id)
        {
            UserFeedback userFeedback = db.UserFeedbacks.Get(id);
            if (userFeedback == null)
            {
                return NotFound();
            }

            return Ok(userFeedback);
        }

        // PUT: api/UserFeedbacks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserFeedback(int id, UserFeedback userFeedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userFeedback.Id)
            {
                return BadRequest();
            }

            db.UserFeedbacks.Update(userFeedback);
            db.Complete();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/UserFeedbacks
        [ResponseType(typeof(UserFeedback))]
        public IHttpActionResult PostUserFeedback(UserFeedback userFeedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserFeedbacks.Add(userFeedback);
            db.Complete();

            return CreatedAtRoute("DefaultApi", new { id = userFeedback.Id }, userFeedback);
        }

        // DELETE: api/UserFeedbacks/5
        [ResponseType(typeof(UserFeedback))]
        public IHttpActionResult DeleteUserFeedback(int id)
        {
            UserFeedback userFeedback = db.UserFeedbacks.Get(id);
            if (userFeedback == null)
            {
                return NotFound();
            }

            db.UserFeedbacks.Remove(userFeedback);
            db.Complete();

            return Ok(userFeedback);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool UserFeedbackExists(int id)
        //{
        //    return db.UserFeedbacks.Count(e => e.Id == id) > 0;
        //}
    }
}