using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Umbraco.Web.UI.ContentApps.Changes.Models
{
    public class ValueChange
    {
        public string Culture { get; set; }
        public object EditedValue { get; set; }
        public object PublishedValue { get; set; }
    }
}
