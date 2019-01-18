using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Umbraco.Web.UI.ContentApps.Changes.Models
{
    public class EditedProperty
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string EditorAlias { get; set; }
        public string Alias { get; set; }
        public string StorageType { get; set; }
        public List<ValueChange> Changes { get; set; }

        /////////////////
         
        public string View { get; set; }
    }
}
