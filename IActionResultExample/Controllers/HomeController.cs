using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("book")]
        public IActionResult Index()
        {
            if (!Request.Query.ContainsKey("bookid")) {
                return BadRequest("book id is not supplised"); 
            }
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                return BadRequest("book can't be null or empty");            
            }
            int bookId = Convert.ToInt32
            (ControllerContext.HttpContext.Request.Query["bookid"]);
            if (bookId <= 0 ) {
                return BadRequest("book id can't be less then zero");
            }
            if (bookId > 1000 ) {
                return NotFound("book id can't be more then thousnds");
            }
            if (Convert.ToBoolean(Request.Query["isloggedin"]) == false)
            {
                return Unauthorized("user must be authenticated");
            }
            /*return new RedirectToActionResult("books","store", new {});*/
            //302 - found

            //301 - move permanetly
           /* return new RedirectToActionResult("books", "store", new { id = bookId });*/

            return LocalRedirectPermanent($"store/books/{bookId}");

        }
    }
}
