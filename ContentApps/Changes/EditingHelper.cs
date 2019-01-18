using System.Collections.Generic;
using System.Linq;
using NPoco.fastJSON;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Services;
using Umbraco.Web.UI.ContentApps.Changes.Converters;
using Umbraco.Web.UI.ContentApps.Changes.Models;

namespace Umbraco.Web.UI.ContentApps.Changes
{
    public class EditingHelper : IEditingHelper
    {
        private readonly ILocalizationService _localizationService;

        public EditingHelper(ILocalizationService localizationService)
        {
            _localizationService = localizationService;
        }

        public ILanguage GetDefaultLanguage()
        {
            var defaultLanguageId = _localizationService.GetDefaultLanguageId();
            if (defaultLanguageId.HasValue)
            {
                var language = _localizationService.GetLanguageById(defaultLanguageId.Value);
                return language;
            }

            return null;
        }

        public List<EditedProperty> GetEditedProperties(IContent content)
        {
            var editedProperties = new List<EditedProperty>();
            var defaultLanguage = GetDefaultLanguage();

            if (content != null && content.Edited)
            {
                foreach (var property in content.Properties)
                {
                    var editedProperty = new EditedProperty
                    {
                        Name = property.PropertyType.Name,
                        Description = property.PropertyType?.Description,
                        EditorAlias = property.PropertyType?.PropertyEditorAlias,
                        Alias = property.Alias,
                        Changes = new List<ValueChange>()
                    };
                    
                    foreach (var value in property.Values)
                    {
                        if (value.EditedValue == null && value.PublishedValue == null)
                            continue;
                        
                        if (!value.EditedValue.Equals(value.PublishedValue))
                        {
                            editedProperty.Changes.Add(new ValueChange
                            {
                                // When allow varying on property type is false, set the culture to the default language
                                Culture = string.IsNullOrEmpty(value.Culture) || !property.PropertyType.VariesByCulture() ?
                                    defaultLanguage?.IsoCode.ToLower() : value.Culture.ToLower(),

                                EditedValue = value.EditedValue.ConvertValue(editedProperty.EditorAlias),
                                PublishedValue = value.PublishedValue.ConvertValue(editedProperty.EditorAlias)
                            });
                        }
                    }

                    if (editedProperty.Changes.Any())
                        editedProperties.Add(editedProperty);
                }
            }

            return editedProperties;
        }
    }
}
