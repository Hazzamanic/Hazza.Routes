using System;
using System.Web.Routing;
using Hazza.Routes.Models;
using Orchard;
using Orchard.Alias;

namespace Hazza.Routes.Services {
    public interface IRouteService : IDependency {
        void Publish(RedirectRoutesPart part);
        void Remove(RedirectRoutesPart part);
    }

    public class RouteService : IRouteService {
        private readonly IAliasService _aliasService;

        public RouteService(IAliasService aliasService) {
            _aliasService = aliasService;
        }

        private const string Source = "Route:Redirect";

        public void Publish(RedirectRoutesPart part) {
            foreach(var alias in part.OldRoutes) {
                _aliasService.Delete(alias.Alias);
            }

            int i = 0;
            foreach(var alias in part.Routes) {
                var routeValues = new RouteValueDictionary();
                routeValues.Add("id", part.ContentItem.Id);
                routeValues.Add("index", i);
                routeValues.Add("action", "Index");
                routeValues.Add("controller", "Redirect");
                routeValues.Add("area", "Hazza.Routes");
                _aliasService.Set(alias.Alias, routeValues, Source, true);
                i++;
            }
        }

        public void Remove(RedirectRoutesPart part) {
            foreach (var alias in part.OldRoutes) {
                _aliasService.Delete(alias.Alias, Source);
            }
        }
    }
}
