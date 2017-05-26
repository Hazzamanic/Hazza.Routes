﻿using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

// This code was generated by Orchardizer
namespace Hazza.Routes
{
    public class Migrations : DataMigrationImpl {
            public int Create() {
            ContentDefinitionManager.AlterPartDefinition("RedirectRoutesPart", builder => builder
                .Attachable()
                .WithDescription("Attach to a content type to allow for 301 and 302 redirects")
            );


            return 1;
        }
    }
}
