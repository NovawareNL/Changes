using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Core.Models.ContentEditing;
using Umbraco.Core.Models.Membership;

namespace Umbraco.Web.UI.ContentApps.Changes
{
    public class ChangesContentApp : IContentAppFactory
    {
        public ContentApp GetContentAppFor(object source, IEnumerable<IReadOnlyUserGroup> userGroups)
        {
            if (!(source is IContent)) 
                return null;
            
            var changesApp = new ContentApp
            {
                Alias = "changes",
                Name = "Changes",
                Icon = "icon-edit",
                View = "/App_Plugins/Changes/app.html",
                Weight = 0

            };

            return changesApp;

        }
    }
}