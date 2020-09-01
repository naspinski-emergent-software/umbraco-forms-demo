using ImageProcessor.Imaging.Colors;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace UmbracoFormsDemo.Controllers
{
    public class ServicesController : SurfaceController
    {
        [HttpGet]
        [ActionName("pre")]
        public XmlResult PreValues()
        {
            var strings = new List<string>()
            {
                "values",
                "returned",
                "from",
                "ServicesController.PreValues()"
            };
            return new XmlResult(strings);
        }

        [HttpPost]
        [ActionName("handle-post")]
        public ActionResult HandlePost()
        {
            var form = Request.Form.AllKeys.ToDictionary(x => x, y => Request.Form[y]);
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }
    }
}