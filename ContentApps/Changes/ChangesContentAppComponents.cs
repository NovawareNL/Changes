using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Components;
using Umbraco.Web.Actions;
using Umbraco.Web.UI.ContentApps.Changes;

namespace Umbraco.Web.UI.ContentApps.Changes
{
    public class ChangesContentAppComponents : UmbracoComponentBase, IUmbracoUserComponent
    {
        public override void Compose(Composition composition)
        {
            base.Compose(composition);

            composition.Container.Register<ChangesApiController>();
            composition.Container.Register<IEditingHelper, EditingHelper>();
        }
    }
}
