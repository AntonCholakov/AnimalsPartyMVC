using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace AnimalsParty.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;

            bundles.Add(new StyleBundle("~/Content/bootstrap")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/bootstrap-theme.css"));

            bundles.Add(new ScriptBundle("~/Scripts/bootstrap")
                .Include("~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/Scripts/jquery")
                .Include("~/Scripts/jquery-{version}.js"));
        }
    }
}