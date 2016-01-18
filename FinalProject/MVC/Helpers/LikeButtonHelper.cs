using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Controllers;

namespace MVC.Helpers
{

    public enum Status { Like = 1, Dislike = 0 }

    public static class LikeButtonHelper
    {
        public static MvcHtmlString List(this HtmlHelper html, string[] items)
        {
            TagBuilder ul = new TagBuilder("ul");
            foreach (string item in items)
            {
                TagBuilder li = new TagBuilder("li");
                li.SetInnerText(item);
                ul.InnerHtml += li.ToString();
            }
            return new MvcHtmlString(ul.ToString());
        }


        public static MvcHtmlString LikeButton(this HtmlHelper html, bool status, int id)
        {
            TagBuilder button = new TagBuilder("button");
            button.Attributes.Add("type", "submit");
            //button.Attributes.Add("name", "status");
            //button.Attributes.Add("value", (status? Status.Like : Status.Dislike).ToString().ToLower());
            button.Attributes.Add("class", "btn "+
                (status ? "like" : "not_like"));
            //button.Attributes.Add("aria-label", "Left Align");
            button.Attributes.Add("id", id+"-button");
            //button.Attributes.Add("onclick", "pressLike(this)");

            TagBuilder span = new TagBuilder("span");
            span.Attributes.Add("class", "glyphicon glyphicon-heart");

            button.InnerHtml += span;

            return new MvcHtmlString(button.ToString());
        }
    }
}