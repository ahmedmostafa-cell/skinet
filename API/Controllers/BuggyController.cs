
using API.Errors;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;

        public BuggyController(StoreContext context)
        {

            _context = context;



        }


        [HttpGet("not-found")]
        public ActionResult<Product> GetNotFound()
        {
            var thing = _context.Products.Find(-1);
            if (thing == null)
            {
                return NotFound(new ApiExcepton(404));
            }
            else
            {
                return thing;
            }
        }


        [HttpGet("server-error")]

        public ActionResult<string> GetServerError()
        {

            var thing = _context.Products.Find(-1);
            var thingToReturn = thing.ToString();
            return thingToReturn;


        }


        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {

            return BadRequest(new ApiExcepton(400));

        }

        [HttpGet("bad-request/{id}")]

        public ActionResult<string> GetBadRequest(int id)
        {

            return Ok();

        }

    }
}