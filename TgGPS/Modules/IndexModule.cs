using Nancy;

namespace TgGPS.Modules
{
    public class IndexModule : BaseModule
    {
        public IndexModule()
        {
            Get["/"] = parameters =>
            {
                return View["index"];
            };
        }
    }
}