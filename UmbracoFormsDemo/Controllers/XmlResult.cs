using System.Web.Mvc;

namespace UmbracoFormsDemo.Controllers
{
    // https://stackoverflow.com/questions/134905/return-xml-from-a-controllers-action-in-as-an-actionresult
    public class XmlResult : ActionResult
    {
        private object objectToSerialize;
        public XmlResult(object objectToSerialize)
        {
            this.objectToSerialize = objectToSerialize;
        }
        public object ObjectToSerialize
        {
            get { return this.objectToSerialize; }
        }
        public override void ExecuteResult(ControllerContext context)
        {
            if (this.objectToSerialize != null)
            {
                context.HttpContext.Response.Clear();
                var xs = new System.Xml.Serialization.XmlSerializer(this.objectToSerialize.GetType());
                context.HttpContext.Response.ContentType = "text/xml";
                xs.Serialize(context.HttpContext.Response.Output, this.objectToSerialize);
            }
        }
    }
}