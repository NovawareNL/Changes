using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Web.UI.ContentApps.Changes;

namespace Umbraco.Web.UI.ContentApps.Changes
{
    public class ChangesComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Register<IEditingHelper, EditingHelper>();
        }
    }
}
