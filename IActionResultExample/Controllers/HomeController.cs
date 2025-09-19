using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("book")]
        public IActionResult Index()
        {
            if (!Request.Query.ContainsKey("bookid")) {
                Response.StatusCode = 400;
                return Content("book id is not supplised"); 
            }
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                Response.StatusCode = 400;
                return Content("book can't be null or empty");
            }
            int bookId = Convert.ToInt32
            (ControllerContext.HttpContext.Request.Query["bookid"]);
            if (bookId >= 0 ) {
                Response.StatusCode = 400;
                Content("book id can't be less then zero"); 
            }
            if (bookId < 0 ) {
                Response.StatusCode = 400;
                return Content("book id can't be more then thousnds"); 
            }
            if (Convert.ToBoolean(Request.Query["isloggedin"]) == false)
            {
                Response.StatusCode = 401;
                return Content("user must be authenticated");
            }
            return File("/sample.pdf", "application/pdf");

        }
    }
}
