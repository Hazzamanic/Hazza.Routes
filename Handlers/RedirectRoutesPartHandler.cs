﻿using Orchard.ContentManagement.Handlers;
using Orchard.Localization;
using Hazza.Routes.Models;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Hazza.Routes.Services;

namespace Hazza.Routes.Handlers {
    public class RedirectRoutesPartHandler : ContentHandler {
        private readonly IRouteService _routeService;

        public RedirectRoutesPartHandler(IRouteService routeService) {
            _routeService = routeService;
            T = NullLocalizer.Instance;

            OnActivated(new Action<ActivatedContentContext, RedirectRoutesPart>(LazyFields));
            OnPublished((PublishContentContext context, RedirectRoutesPart part) => {
                _routeService.Publish(part);
            });
            OnRemoved((RemoveContentContext ctx, RedirectRoutesPart part) => {
                _routeService.Remove(part);
            });
            OnUnpublished((PublishContentContext ctx, RedirectRoutesPart part) => {
                _routeService.Remove(part);
            });
        }

        public Localizer T { get; set; }

        private void LazyFields(ActivatedContentContext context, RedirectRoutesPart part) {
            part._redirectRoutes.Loader(() => JsonConvert.DeserializeObject<List<RedirectRoute>>(part.RoutesString ?? "") ?? new List<RedirectRoute>());
            part._redirectRoutes.Setter(delegate (IEnumerable<RedirectRoute> routes) {
                if (routes == null)
                    routes = new List<RedirectRoute>();

                part.RoutesString = JsonConvert.SerializeObject(routes, Formatting.None);
                return routes;
            });

        }
    }
}