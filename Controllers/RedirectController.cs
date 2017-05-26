using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hazza.Routes.Models;
using Orchard.Autoroute.Models;
using Orchard.ContentManagement;

namespace Hazza.Routes.Controllers {
    public class RedirectController : Controller {
        private readonly IContentManager _contentManager;

        public RedirectController(IContentManager contentManager) {
            _contentManager = contentManager;
        }

        public ActionResult Index(int id, int? index) {
            var item = _contentManager.Get(id, VersionOptions.Published);
            if (item == null)
                return HttpNotFound();

            var redirectPart = item.As<RedirectRoutesPart>();
            var redirectType = redirectPart == null ? Models.Redirect.MovedPermanently :
                redirectPart.Routes.Any() ? redirectPart.Routes.ToArray()[index ?? 0].RedirectType : Models.Redirect.MovedPermanently;

            var autoroutePart = item.As<AutoroutePart>();
            if(autoroutePart != null) {
                var path = "~/" + autoroutePart.Path;
                if (redirectType == Models.Redirect.MovedPermanently)
                    return RedirectPermanent(path);

                return Redirect(path);
            }

            var routeValues = _contentManager.GetItemMetadata(item).DisplayRouteValues;
            if (redirectType == Models.Redirect.MovedPermanently)
                return RedirectToRoutePermanent(routeValues);

            return RedirectToRoute(routeValues);
        }
    }
}