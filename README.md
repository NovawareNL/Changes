
## Changes Content App
For an editor without technical knowledge it can be a challenge to compare (pending) changes in Umbraco. Especially when using property types like Nested Content and Content/Media pickers, the built-in Umbraco rollback and audit trail functionality is not always as clear as you would like.

That is why we have developed the content app Changes. Changes delivers a good user experience when it comes to reviewing pending changes.

![Change Content App](https://github.com/NovawareNL/Changes/blob/master/changescontentapp.PNG)

**Current release of Changes comes with:**

 - Insight into saved content changes that are not published yet,
 - Insight into the pending changes for the default language,
 - See the pending changes per language.

**The following will be added in the future:**

 - Accept or deny individual pending changes,
 - Accept and/or deny rights depending on user groups,
 - Developers can simply add views so custom property editors can also be compared,
 - Comments can be added to changes for more context,
 - See the pending change in full context (complete value of property) or only see the pending change,
 - You can browse through content versions + associated changes.

**How to install:**

Simply copy the App_Plugins and ContentApps folder to your Umbraco 8 Umbraco.Web.UI project and have fun!
