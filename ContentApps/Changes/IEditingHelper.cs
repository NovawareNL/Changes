using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using Umbraco.Web.UI.ContentApps.Changes.Models;

namespace Umbraco.Web.UI.ContentApps.Changes
{
    public interface IEditingHelper
    {
        ILanguage GetDefaultLanguage();
        List<EditedProperty> GetEditedProperties(IContent content);
    }
}
