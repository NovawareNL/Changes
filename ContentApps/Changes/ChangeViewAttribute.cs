using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Umbraco.Web.UI.ContentApps.Changes
{
    public class ChangeViewAttribute : Attribute
    {
        public string View { get; set; }
        public string PropertyEditorAlias { get; set; }
    }
}
