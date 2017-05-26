using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hazza.Routes.Models;

namespace Hazza.Routes.ViewModels {
    public class RedirectRouteViewModel {
        public IEnumerable<RedirectRoute> Routes { get; set; }
        public string MainPath { get; set; }
    }
}