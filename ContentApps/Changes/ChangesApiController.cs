using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Umbraco.Core.Composing;
using Umbraco.Core.Services;
using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;
using Umbraco.Web.UI.ContentApps.Changes.Models;
using Umbraco.Web.WebApi;

namespace Umbraco.Web.UI.ContentApps.Changes
{
    [PluginController("Changes")]
    public class ChangesApiController : UmbracoAuthorizedApiController
    {
        private readonly IContentService _contentService;
        private readonly IEditingHelper _editingHelper;
        private readonly ILocalizationService _localizationService;

        public ChangesApiController(IContentService contentService, IEditingHelper editingHelper, ILocalizationService localizationService)
        {
            _contentService = contentService;
            _editingHelper = editingHelper;
            _localizationService = localizationService;
        }

        [HttpGet]
        public List<EditedProperty> GetEditedProperties(int contentId)
        {
            var content = _contentService.GetById(contentId);

            return _editingHelper.GetEditedProperties(content);
        }

        [HttpGet]
        public IEnumerable<Language> GetLanguages()
        {
            return _localizationService.GetAllLanguages().Select(x => new Language
            {
                Name = x.CultureName,
                IsoCode = x.IsoCode.ToLower()
            });
        }

        [HttpGet]
        public EditorInfo GetEditorInfo(int id)
        {
            var user = Current.Services.UserService.GetUserById(id);
            if (user != null)
            {
                return new EditorInfo
                {
                    Name = user.Name,
                    AvatarUrl = user.Avatar
                };
            }

            return null;
        }
    }
}
