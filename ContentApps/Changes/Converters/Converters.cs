using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPoco.fastJSON;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Core.Models;
using Umbraco.Web.UI.ContentApps.Changes.Converters.Models;

namespace Umbraco.Web.UI.ContentApps.Changes.Converters
{
    public static class Converters
    {
        /// <summary>
        /// Todo: It should be nice to make it possible for developers to add custom converters and/or 
        /// Todo: views for displaying property values on the pending changes dashboard.
        /// </summary>
        /// <param name="value">The RAW value of the IContent property</param>
        /// <param name="editorAlias">The property editor alias of the Content Type property</param>
        /// <returns>Returns (converted) value</returns>
        public static object ConvertValue(this object value, string editorAlias)
        {
            switch (editorAlias)
            {
                case "Umbraco.MultiNodeTreePicker":
                    return ConvertMultiNodeTreePicker(value);
                case "Umbraco.NestedContent":
                    return ConvertNestedContent(value);
                case "Umbraco.MediaPicker":
                    return ConvertMediaPicker(value);
                default: return value;  
            }
        }
        
        private static List<MultipleTreeNodePickerConverted> ConvertMultiNodeTreePicker(object value)
        {
            var returnList = new List<MultipleTreeNodePickerConverted>();

            if (value != null && !string.IsNullOrEmpty(value.ToString()))
            {
                var udis = value.ToString().Split(',');

                foreach (var stringUdi in udis)
                {
                    var udi = Udi.Parse(stringUdi);
                    var content = Current.Services.ContentService.GetById(((GuidUdi)udi).Guid);
                    if (content != null)
                    {
                        returnList.Add(new MultipleTreeNodePickerConverted
                        {
                            Name = content.Name,
                            Icon = content.ContentType.Icon,
                            EditingLink = "/umbraco#/content/content/edit/" + content.Id
                        });
                    }
                }
            }

            return returnList;
        }
        
        private static object ConvertNestedContent(object value)
        {
            if (value != null)
            {
                try
                {
                    return JSON.Parse(value.ToString());
                }
                catch (Exception exc)
                {
                    return null;
                }
            }

            return null;
        }
        
        private static object ConvertMediaPicker(object value)
        {
            if (value != null)
            {
                var udi = Udi.Parse(value.ToString());
                var media = Current.Services.MediaService.GetById(((GuidUdi)udi).Guid);
                if (media != null)
                {
                    return media.GetUrl("umbracoFile", null);
                }
            }

            return null;
        }
    } 
}
