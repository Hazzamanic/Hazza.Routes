﻿using System;
using System.Collections.Generic;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Utilities;

// This code was generated by Orchardizer

namespace Hazza.Routes.Models {
    public class RedirectRoutesPart : ContentPart {
        internal LazyField<IEnumerable<RedirectRoute>> _redirectRoutes = new LazyField<IEnumerable<RedirectRoute>>();

        public IEnumerable<RedirectRoute> Routes {
            get { return _redirectRoutes.Value; }
            set { _redirectRoutes.Value = value; }
        }

        internal string RoutesString {
            get { return this.Retrieve(x => x.RoutesString); }
            set { this.Store(x => x.RoutesString, value); }
        }

        public IEnumerable<RedirectRoute> OldRoutes {
            get; set;
        }
    }

    public class RedirectRoute {
        public string Alias { get; set; }
        public Redirect RedirectType { get; set; }
    }

    public enum Redirect {
        MovedPermanently, MovedTemporarily
    }
}