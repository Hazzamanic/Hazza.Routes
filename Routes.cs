using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Orchard.Mvc.Routes;

namespace Hazza.Routes {
    public class Routes : IRouteProvider {
        public void GetRoutes(ICollection<RouteDescriptor> routes) {
            foreach (var routeDescriptor in GetRoutes())
                routes.Add(routeDescriptor);
        }

        public IEnumerable<RouteDescriptor> GetRoutes() {
            return new[] {
                new RouteDescriptor {
                    Route = new Route(
                        "Hazza/Redirector/{id}/{index}",
                        new RouteValueDictionary {
                            {"area", "Hazza.Routes"},
                            {"controller", "Redirect"},
                            {"action", "Index"}
                        },
                        new RouteValueDictionary(),
                        new RouteValueDictionary {
                            {"area", "Hazza.Routes"}
                        },
                        new MvcRouteHandler()
                    )
                }
            };
        }
    }
}