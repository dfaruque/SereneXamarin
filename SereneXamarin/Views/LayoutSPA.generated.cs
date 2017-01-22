#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SereneXamarin.Mobile.Views
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#line 3 "LayoutSPA.cshtml"
using Serenity;

#line default
#line hidden

#line 4 "LayoutSPA.cshtml"
using SereneXamarin;

#line default
#line hidden


[System.CodeDom.Compiler.GeneratedCodeAttribute("RazorTemplatePreprocessor", "4.2.1.73")]
public partial class LayoutSPA : LayoutSPABase
{

#line hidden

#line 176 "LayoutSPA.cshtml"
public static Action<System.IO.TextWriter> renderItem(Serenity.Navigation.NavigationItem item, int depth, int[] path)
                    {
#line default
#line hidden
return new Action<System.IO.TextWriter>(__razor_helper_writer => {

#line 176 "LayoutSPA.cshtml"
                    

#line default
#line hidden

#line 177 "LayoutSPA.cshtml"
                     

var isactive = false;
//for (var i = 0; i <= depth; i++)
//{
//if (path[i] != navigationModel.ActivePath[i])
//{
//isactive = false;
//break;
//}
//}

var klass = (isactive ? "active" : "") + (item.Children.IsEmptyOrNull() ? "" : " treeview");
var icon = (item.IconClass ?? (item.Children.Count > 0 ? "icon-layers" : (depth == 0 ? "icon-link" : "fa-circle-o")));
var title = (Serenity.LocalText.TryGet("Navigation." + item.FullPath) ?? item.Title);
var sectionUrl = (item.Url ?? "javascript:;");
var target = item.Target; if (target != null) { target += " target=" + target; }



#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "                    <li");

WriteAttributeTo (__razor_helper_writer, "class", " class=\"", "\""

#line 195 "LayoutSPA.cshtml"
, Tuple.Create<string,object,bool> ("", klass

#line default
#line hidden
, false)
);
WriteLiteralTo(__razor_helper_writer, ">\r\n                        <a");

WriteAttributeTo (__razor_helper_writer, "href", " href=\"", "\""

#line 196 "LayoutSPA.cshtml"
, Tuple.Create<string,object,bool> ("", sectionUrl

#line default
#line hidden
, false)
);
WriteLiteralTo(__razor_helper_writer, " ");


#line 196 "LayoutSPA.cshtml"
                WriteTo(__razor_helper_writer, target);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, ">\r\n                            <i");

WriteAttributeTo (__razor_helper_writer, "class", " class=\"", "\""
, Tuple.Create<string,object,bool> ("", "fa", true)

#line 197 "LayoutSPA.cshtml"
  , Tuple.Create<string,object,bool> (" ", icon

#line default
#line hidden
, false)
);
WriteLiteralTo(__razor_helper_writer, "></i>\r\n                            <span>");


#line 198 "LayoutSPA.cshtml"
    WriteTo(__razor_helper_writer, title);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "</span>\r\n");


#line 199 "LayoutSPA.cshtml"
                            

#line default
#line hidden

#line 199 "LayoutSPA.cshtml"
                             if (!item.Children.IsEmptyOrNull())
                            {


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "                                <i");

WriteLiteralTo(__razor_helper_writer, " class=\"fa fa-angle-left pull-right\"");

WriteLiteralTo(__razor_helper_writer, "></i>\r\n");


#line 202 "LayoutSPA.cshtml"
                            }


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "                        </a>\r\n\r\n");


#line 205 "LayoutSPA.cshtml"
                        

#line default
#line hidden

#line 205 "LayoutSPA.cshtml"
                         if (item.Children.Count > 0)
                        {


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "                            <ul");

WriteLiteralTo(__razor_helper_writer, " class=\"treeview-menu\"");

WriteLiteralTo(__razor_helper_writer, ">\r\n");


#line 208 "LayoutSPA.cshtml"
                                

#line default
#line hidden

#line 208 "LayoutSPA.cshtml"
                                  path[depth + 1] = 0; 

#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "\r\n");


#line 209 "LayoutSPA.cshtml"
                                

#line default
#line hidden

#line 209 "LayoutSPA.cshtml"
                                 foreach (var child in item.Children)
                                {
                                    

#line default
#line hidden

#line 211 "LayoutSPA.cshtml"
      WriteTo(__razor_helper_writer, renderItem(child, depth + 1, path));


#line default
#line hidden

#line 211 "LayoutSPA.cshtml"
                                                                       ;
                                }


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "                            </ul>\r\n");


#line 214 "LayoutSPA.cshtml"
                                    }


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "                    </li>\r\n");


#line 216 "LayoutSPA.cshtml"
                                    path[depth]++;


#line default
#line hidden
});

#line 217 "LayoutSPA.cshtml"
}
#line default
#line hidden


public override void Execute()
{
WriteLiteral("\r\n<!DOCTYPE html>\r\n");


#line 5 "LayoutSPA.cshtml"
  
    //Func<string, IHtmlString> json = x => new HtmlString(Serenity.JSON.Stringify(x));
    //var hideNav = Request["hideNav"] == "1";
    var logged = Serenity.Authorization.Username;
    //var themeCookie = Request.Cookies["ThemePreference"];
    var theme = "blue";//themeCookie != null && !themeCookie.Value.IsEmptyOrNull() ? themeCookie.Value : "blue";
    var rtl = System.Globalization.CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft;
    var user = (UserDefinition)Serenity.Authorization.UserDefinition;
    var userImage = (user == null || string.IsNullOrEmpty(user.UserImage)) ? "~/Content/adminlte/img/avatar04.png" :
        "~/upload/" + user.UserImage;
    var navigationModel = new SereneXamarin.Navigation.NavigationModel();

    Func<string, string> Href = x => x; //to fix Href issue in razor generator



#line default
#line hidden
WriteLiteral("\r\n\r\n<!--[if IE 8]> <html");

WriteLiteral(" lang=\"bn-BD\"");

WriteLiteral(" class=\"ie8 no-js\"");

WriteLiteral("> <![endif]-->\r\n<!--[if IE 9]> <html");

WriteLiteral(" lang=\"bn-BD\"");

WriteLiteral(" class=\"ie9 no-js\"");

WriteLiteral("> <![endif]-->\r\n<!--[if !IE]><!-->\r\n<html");

WriteLiteral(" lang=\"bn-BD\"");

WriteLiteral(" class=\"no-js\"");

WriteLiteral(">\r\n<!--<![endif]-->\r\n<head>\r\n\r\n    <meta");

WriteLiteral(" charset=\"utf-8\"");

WriteLiteral(" />\r\n    <meta");

WriteLiteral(" http-equiv=\"X-UA-Compatible\"");

WriteLiteral(" content=\"IE=edge\"");

WriteLiteral(">\r\n    <meta");

WriteLiteral(" http-equiv=\"Content-Type\"");

WriteLiteral(" content=\"text/html;charset=utf-8\"");

WriteLiteral(" />\r\n    <meta");

WriteLiteral(" name=\"viewport\"");

WriteLiteral(" content=\"width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no\"" +
"");

WriteLiteral(" />\r\n    ");

WriteLiteral("\r\n\r\n    <link");

WriteLiteral(" href=\"font-open-sans.css\"");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(">\r\n    <link");

WriteLiteral(" href=\"font-awesome.css\"");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(">\r\n    <link");

WriteLiteral(" href=\"simple-line-icons.css\"");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(">\r\n    <link");

WriteLiteral(" href=\"ionicons.css\"");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(">\r\n    <link");

WriteLiteral(" href=\"aristo.css\"");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(">\r\n    <link");

WriteLiteral(" href=\"bootstrap.css\"");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(">\r\n    <link");

WriteLiteral(" href=\"jquery.colorbox.css\"");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(">\r\n    <link");

WriteLiteral(" href=\"jquery.fileupload.css\"");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(">\r\n    <link");

WriteLiteral(" href=\"pace.css\"");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(">\r\n    <link");

WriteLiteral(" href=\"slick.grid.css\"");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(">\r\n    <link");

WriteLiteral(" href=\"select2.css\"");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(">\r\n    <link");

WriteLiteral(" href=\"toastr.css\"");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(">\r\n    <link");

WriteLiteral(" href=\"serenity.css\"");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(">\r\n    <link");

WriteLiteral(" href=\"site.css\"");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(">\r\n\r\n    <script");

WriteLiteral(" type=\"application/json\"");

WriteLiteral(" id=\"ScriptCulture\"");

WriteLiteral(">\r\n        {\"DateOrder\":\"mdy\",\"DateFormat\":\"MM/dd/yyyy\",\"DateSeparator\":\"/\",\"Date" +
"TimeFormat\":\"MM/dd/yyyy HH:mm:ss\",\"DecimalSeparator\":\".\",\"GroupSepearator\":\",\"}\r" +
"\n    </script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">window.paceOptions = { minTime: 250, ghostTime: 250, restartOnRequestAfter: 250," +
" ajax: { trackMethods: [\'GET\', \'POST\'], trackWebSockets: true, ignoreURLs: [] } " +
"};</script>\r\n    <script");

WriteLiteral(" src=\"Bundle.Libs.js.download\"");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n\r\n\r\n    <script");

WriteLiteral(" src=\"jquery.maskedinput.js.download\"");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n\r\n\r\n    <script");

WriteLiteral(" src=\"Bundle.Site.js.download\"");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n\r\n    <script");

WriteLiteral(" src=\"LocalText.Site.en-US.Public.js.download\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"ColumnsBundle.js.download\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"FormBundle.js.download\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"TemplateBundle.js.download\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"RegisteredScripts.js.download\"");

WriteLiteral("></script>\r\n\r\n    <script");

WriteLiteral(" src=\"FakeAjax.js\"");

WriteLiteral("></script>\r\n    <title> - SereneXamarin</title>\r\n</head>\r\n<body");

WriteLiteral(" id=\"s-Page\"");

WriteLiteral(" class=\"fixed sidebar-mini hold-transition skin-blue\"");

WriteLiteral(">\r\n\r\n    <div");

WriteLiteral(" class=\"wrapper\"");

WriteLiteral(">\r\n        <header");

WriteLiteral(" class=\"main-header\"");

WriteLiteral(">\r\n            <a");

WriteAttribute ("href", " href=\"", "\""
, Tuple.Create<string,object,bool> ("", Href("~/")
, false)
);
WriteLiteral(" class=\"logo\"");

WriteLiteral(">\r\n                <span");

WriteLiteral(" class=\"logo-mini\"");

WriteLiteral("><i></i></span>\r\n                <span");

WriteLiteral(" class=\"logo-lg\"");

WriteLiteral("><i></i><b>");


#line 120 "LayoutSPA.cshtml"
                                           Write(Serenity.LocalText.Get("Navigation.SiteTitle"));


#line default
#line hidden
WriteLiteral("</b></span>\r\n            </a>\r\n            <nav");

WriteLiteral(" class=\"navbar navbar-static-top\"");

WriteLiteral(" role=\"navigation\"");

WriteLiteral(">\r\n                <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"sidebar-toggle\"");

WriteLiteral(" data-toggle=\"offcanvas\"");

WriteLiteral(" role=\"button\"");

WriteLiteral(">\r\n                    <span");

WriteLiteral(" class=\"sr-only\"");

WriteLiteral(">Toggle navigation</span>\r\n                </a>\r\n\r\n                <div");

WriteLiteral(" class=\"navbar-custom-menu\"");

WriteLiteral(">\r\n                    <ul");

WriteLiteral(" class=\"nav navbar-nav\"");

WriteLiteral(">\r\n                        <li");

WriteLiteral(" class=\"dropdown user user-menu\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"dropdown-toggle\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(">\r\n                                <img");

WriteAttribute ("src", " src=\"", "\""

#line 131 "LayoutSPA.cshtml"
   , Tuple.Create<string,object,bool> ("", userImage

#line default
#line hidden
, false)
);
WriteLiteral(" class=\"user-image\"");

WriteLiteral(" alt=\"User Image\"");

WriteLiteral(">\r\n                                <span");

WriteLiteral(" class=\"hidden-xs\"");

WriteLiteral(">");


#line 132 "LayoutSPA.cshtml"
                                                   Write(Serenity.Authorization.Username);


#line default
#line hidden
WriteLiteral("</span>\r\n                            </a>\r\n                            <ul");

WriteLiteral(" class=\"dropdown-menu\"");

WriteLiteral(">\r\n                                <!-- User image -->\r\n                         " +
"       <li");

WriteLiteral(" class=\"user-header\"");

WriteLiteral(">\r\n                                    <img");

WriteAttribute ("src", " src=\"", "\""

#line 137 "LayoutSPA.cshtml"
       , Tuple.Create<string,object,bool> ("", userImage

#line default
#line hidden
, false)
);
WriteLiteral(" class=\"img-circle\"");

WriteLiteral(" alt=\"User Image\"");

WriteLiteral(">\r\n\r\n                                    <p>\r\n");

WriteLiteral("                                        ");


#line 140 "LayoutSPA.cshtml"
                                    Write(user != null ? user.DisplayName : "");


#line default
#line hidden
WriteLiteral("\r\n                                    </p>\r\n                                </li>" +
"\r\n\r\n                                <!-- Menu Footer-->\r\n                       " +
"         <li");

WriteLiteral(" class=\"user-footer\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"pull-left\"");

WriteLiteral(">\r\n                                        <a");

WriteAttribute ("href", " href=\"", "\""
, Tuple.Create<string,object,bool> ("", Href("~/Account/ChangePassword")
, false)
);
WriteLiteral(" class=\"btn btn-default btn-flat\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-lock fa-fw\"");

WriteLiteral("></i> ");


#line 147 "LayoutSPA.cshtml"
                                                                                                                                        Write(SereneXamarin.Texts.Forms.Membership.ChangePassword.FormTitle);


#line default
#line hidden
WriteLiteral("</a>\r\n                                    </div>\r\n                               " +
"     <div");

WriteLiteral(" class=\"pull-right\"");

WriteLiteral(">\r\n                                        <a");

WriteAttribute ("href", " href=\"", "\""
, Tuple.Create<string,object,bool> ("", Href("~/Account/Signout")
, false)
);
WriteLiteral(" class=\"btn btn-default btn-flat\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-sign-out fa-fw\"");

WriteLiteral("></i> ");


#line 150 "LayoutSPA.cshtml"
                                                                                                                                     Write(Serenity.LocalText.Get("Navigation.LogoutLink"));


#line default
#line hidden
WriteLiteral("</a>\r\n                                    </div>\r\n                               " +
" </li>\r\n                            </ul>\r\n                        </li>\r\n\r\n    " +
"                    <li>\r\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" data-toggle=\"control-sidebar\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-gears\"");

WriteLiteral("></i></a>\r\n                        </li>\r\n                    </ul>\r\n            " +
"    </div>\r\n            </nav>\r\n        </header>\r\n\r\n        <aside");

WriteLiteral(" class=\"main-sidebar\"");

WriteLiteral(">\r\n            <section");

WriteLiteral(" class=\"sidebar\"");

WriteLiteral(">\r\n                <form");

WriteLiteral(" action=\"#\"");

WriteLiteral(" method=\"get\"");

WriteLiteral(" class=\"sidebar-form\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"SidebarSearch\"");

WriteLiteral(" name=\"q\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" autocomplete=\"off\"");

WriteLiteral(">\r\n                        <span");

WriteLiteral(" class=\"input-group-btn\"");

WriteLiteral(">\r\n                            <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" name=\"search\"");

WriteLiteral(" id=\"search-btn\"");

WriteLiteral(" class=\"btn btn-flat\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral("></i></button>\r\n                        </span>\r\n                    </div>\r\n    " +
"            </form>\r\n                <ul");

WriteLiteral(" class=\"sidebar-menu\"");

WriteLiteral(" id=\"SidebarMenu\"");

WriteLiteral(">\r\n\r\n");

WriteLiteral("\r\n");


#line 219 "LayoutSPA.cshtml"
                    

#line default
#line hidden

#line 219 "LayoutSPA.cshtml"
                      var path = new int[10]; 

#line default
#line hidden
WriteLiteral("\r\n");


#line 220 "LayoutSPA.cshtml"
                    

#line default
#line hidden

#line 220 "LayoutSPA.cshtml"
                     foreach (var item in navigationModel.Items)
                    {
                        

#line default
#line hidden

#line 222 "LayoutSPA.cshtml"
                   Write(renderItem(item, 0, path));


#line default
#line hidden

#line 222 "LayoutSPA.cshtml"
                                                  ;
                    }


#line default
#line hidden
WriteLiteral("\r\n                    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
                        function openWindow(url, width, height) {
                            height = height || (screen.availHeight - 60);
                            width = width || (screen.availWidth - 10);
                            var x = (screen.availWidth - width) / 2 - 5; if (x < 0) x = 0;
                            var y = (screen.availHeight - height) / 2 - 25; if (y < 0) y = 0;
                            var winPopup = window.open(url, """", ""status=0, toolbar=0, width="" + width + "", height="" + height +
                                "", scrollbars=1, resizable=yes, left="" + x + "", top="" + y);
                        }
                    </script>
                </ul>
            </section>
        </aside>

        <div");

WriteLiteral(" class=\"content-wrapper\"");

WriteLiteral(">\r\n            <section");

WriteLiteral(" class=\"content\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" id=\"GridDiv\"");

WriteLiteral("></div>\r\n            </section>\r\n        </div>\r\n\r\n        <footer");

WriteLiteral(" class=\"main-footer\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"pull-right hidden-xs\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");


#line 247 "LayoutSPA.cshtml"
           Write(Texts.Site.Layout.FooterInfo);


#line default
#line hidden
WriteLiteral("\r\n            </div>\r\n            <strong>");


#line 249 "LayoutSPA.cshtml"
               Write(Texts.Site.Layout.FooterCopyright);


#line default
#line hidden
WriteLiteral("</strong> ");


#line 249 "LayoutSPA.cshtml"
                                                           Write(Texts.Site.Layout.FooterRights);


#line default
#line hidden
WriteLiteral("\r\n        </footer>\r\n\r\n        <aside");

WriteLiteral(" class=\"control-sidebar control-sidebar-dark\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"tab-content\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"tab-pane active\"");

WriteLiteral(" id=\"control-sidebar-settings-tab\"");

WriteLiteral(">\r\n                    <form");

WriteLiteral(" method=\"post\"");

WriteLiteral(">\r\n                        <h3");

WriteLiteral(" class=\"control-sidebar-heading\"");

WriteLiteral(">");


#line 256 "LayoutSPA.cshtml"
                                                       Write(Texts.Site.Layout.GeneralSettings);


#line default
#line hidden
WriteLiteral("</h3>\r\n\r\n                        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                            <label");

WriteLiteral(" class=\"control-sidebar-subheading\"");

WriteLiteral(">");


#line 259 "LayoutSPA.cshtml"
                                                                 Write(Texts.Site.Layout.Language);


#line default
#line hidden
WriteLiteral("</label>\r\n                            <select");

WriteLiteral(" id=\"LanguageSelect\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("></select>\r\n                        </div>\r\n\r\n                        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(" style=\"margin-top: 15px;\"");

WriteLiteral(">\r\n                            <label");

WriteLiteral(" class=\"control-sidebar-subheading\"");

WriteLiteral(">");


#line 264 "LayoutSPA.cshtml"
                                                                 Write(Texts.Site.Layout.Theme);


#line default
#line hidden
WriteLiteral("</label>\r\n                            <select");

WriteLiteral(" id=\"ThemeSelect\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("></select>\r\n                        </div>\r\n                    </form>\r\n        " +
"        </div>\r\n            </div>\r\n        </aside>\r\n        <div");

WriteLiteral(" class=\"control-sidebar-bg\"");

WriteLiteral("></div>\r\n    </div>\r\n\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n        $().ready(function () {\r\n            new SereneXamarin.Common.SidebarS" +
"earch($(\'#SidebarSearch\'), $(\'#SidebarMenu\')).init();\r\n            new SereneXam" +
"arin.Common.LanguageSelection($(\'#LanguageSelect\'), \'");


#line 277 "LayoutSPA.cshtml"
                                                                          Write(System.Globalization.CultureInfo.CurrentUICulture.Name);


#line default
#line hidden
WriteLiteral("\');\r\n            new SereneXamarin.Common.ThemeSelection($(\'#ThemeSelect\'));\r\n   " +
"         ");

WriteLiteral(@"

            var doLayout = function () {
                height = (this.window.innerHeight > 0) ? this.window.innerHeight : this.screen.height;
                height -= $('header.main-header').outerHeight() || 0;
                height -= $('section.content-header').outerHeight() || 0;
                height -= $('footer.main-footer').outerHeight() || 0;
                if (height < 200) height = 200;
                $(""section.content"").css(""min-height"", (height) + ""px"");

                $('body').triggerHandler('layout');
            };

            $(window).bind(""load resize layout"", doLayout);
            doLayout();
        });
    </script>
    }
</body>
</html>");

}
}

// NOTE: this is the default generated helper class. You may choose to extract it to a separate file 
// in order to customize it or share it between multiple templates, and specify the template's base 
// class via the @inherits directive.
public abstract class LayoutSPABase
{

		// This field is OPTIONAL, but used by the default implementation of Generate, Write, WriteAttribute and WriteLiteral
		//
		System.IO.TextWriter __razor_writer;

		// This method is OPTIONAL
		//
		/// <summary>Executes the template and returns the output as a string.</summary>
		/// <returns>The template output.</returns>
		public string GenerateString ()
		{
			using (var sw = new System.IO.StringWriter ()) {
				Generate (sw);
				return sw.ToString ();
			}
		}

		// This method is OPTIONAL, you may choose to implement Write and WriteLiteral without use of __razor_writer
		// and provide another means of invoking Execute.
		//
		/// <summary>Executes the template, writing to the provided text writer.</summary>
		/// <param name="writer">The TextWriter to which to write the template output.</param>
		public void Generate (System.IO.TextWriter writer)
		{
			__razor_writer = writer;
			Execute ();
			__razor_writer = null;
		}

		// This method is REQUIRED, but you may choose to implement it differently
		//
		/// <summary>Writes a literal value to the template output without HTML escaping it.</summary>
		/// <param name="value">The literal value.</param>
		protected void WriteLiteral (string value)
		{
			__razor_writer.Write (value);
		}

		// This method is REQUIRED if the template contains any Razor helpers, but you may choose to implement it differently
		//
		/// <summary>Writes a literal value to the TextWriter without HTML escaping it.</summary>
		/// <param name="writer">The TextWriter to which to write the literal.</param>
		/// <param name="value">The literal value.</param>
		protected static void WriteLiteralTo (System.IO.TextWriter writer, string value)
		{
			writer.Write (value);
		}

		// This method is REQUIRED, but you may choose to implement it differently
		//
		/// <summary>Writes a value to the template output, HTML escaping it if necessary.</summary>
		/// <param name="value">The value.</param>
		/// <remarks>The value may be a Action<System.IO.TextWriter>, as returned by Razor helpers.</remarks>
		protected void Write (object value)
		{
			WriteTo (__razor_writer, value);
		}

		// This method is REQUIRED if the template contains any Razor helpers, but you may choose to implement it differently
		//
		/// <summary>Writes an object value to the TextWriter, HTML escaping it if necessary.</summary>
		/// <param name="writer">The TextWriter to which to write the value.</param>
		/// <param name="value">The value.</param>
		/// <remarks>The value may be a Action<System.IO.TextWriter>, as returned by Razor helpers.</remarks>
		protected static void WriteTo (System.IO.TextWriter writer, object value)
		{
			if (value == null)
				return;

			var write = value as Action<System.IO.TextWriter>;
			if (write != null) {
				write (writer);
				return;
			}

			//NOTE: a more sophisticated implementation would write safe and pre-escaped values directly to the
			//instead of double-escaping. See System.Web.IHtmlString in ASP.NET 4.0 for an example of this.
			writer.Write(System.Net.WebUtility.HtmlEncode (value.ToString ()));
		}

		// This method is REQUIRED, but you may choose to implement it differently
		//
		/// <summary>
		/// Conditionally writes an attribute to the template output.
		/// </summary>
		/// <param name="name">The name of the attribute.</param>
		/// <param name="prefix">The prefix of the attribute.</param>
		/// <param name="suffix">The suffix of the attribute.</param>
		/// <param name="values">Attribute values, each specifying a prefix, value and whether it's a literal.</param>
		protected void WriteAttribute (string name, string prefix, string suffix, params Tuple<string,object,bool>[] values)
		{
			WriteAttributeTo (__razor_writer, name, prefix, suffix, values);
		}

		// This method is REQUIRED if the template contains any Razor helpers, but you may choose to implement it differently
		//
		/// <summary>
		/// Conditionally writes an attribute to a TextWriter.
		/// </summary>
		/// <param name="writer">The TextWriter to which to write the attribute.</param>
		/// <param name="name">The name of the attribute.</param>
		/// <param name="prefix">The prefix of the attribute.</param>
		/// <param name="suffix">The suffix of the attribute.</param>
		/// <param name="values">Attribute values, each specifying a prefix, value and whether it's a literal.</param>
		///<remarks>Used by Razor helpers to write attributes.</remarks>
		protected static void WriteAttributeTo (System.IO.TextWriter writer, string name, string prefix, string suffix, params Tuple<string,object,bool>[] values)
		{
			// this is based on System.Web.WebPages.WebPageExecutingBase
			// Copyright (c) Microsoft Open Technologies, Inc.
			// Licensed under the Apache License, Version 2.0
			if (values.Length == 0) {
				// Explicitly empty attribute, so write the prefix and suffix
				writer.Write (prefix);
				writer.Write (suffix);
				return;
			}

			bool first = true;
			bool wroteSomething = false;

			for (int i = 0; i < values.Length; i++) {
				Tuple<string,object,bool> attrVal = values [i];
				string attPrefix = attrVal.Item1;
				object value = attrVal.Item2;
				bool isLiteral = attrVal.Item3;

				if (value == null) {
					// Nothing to write
					continue;
				}

				// The special cases here are that the value we're writing might already be a string, or that the
				// value might be a bool. If the value is the bool 'true' we want to write the attribute name instead
				// of the string 'true'. If the value is the bool 'false' we don't want to write anything.
				//
				// Otherwise the value is another object (perhaps an IHtmlString), and we'll ask it to format itself.
				string stringValue;
				bool? boolValue = value as bool?;
				if (boolValue == true) {
					stringValue = name;
				} else if (boolValue == false) {
					continue;
				} else {
					stringValue = value as string;
				}

				if (first) {
					writer.Write (prefix);
					first = false;
				} else {
					writer.Write (attPrefix);
				}

				if (isLiteral) {
					writer.Write (stringValue ?? value);
				} else {
					WriteTo (writer, stringValue ?? value);
				}
				wroteSomething = true;
			}
			if (wroteSomething) {
				writer.Write (suffix);
			}
		}
		// This method is REQUIRED. The generated Razor subclass will override it with the generated code.
		//
		///<summary>Executes the template, writing output to the Write and WriteLiteral methods.</summary>.
		///<remarks>Not intended to be called directly. Call the Generate method instead.</remarks>
		public abstract void Execute ();

}
}
#pragma warning restore 1591