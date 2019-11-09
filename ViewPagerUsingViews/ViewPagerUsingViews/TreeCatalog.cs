using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ViewPagerUsingViews
{
    public class TreeCatalog
    {
        private TreePage[] treePages;

        private static TreePage[] buildInThreeCatalog = {
            new TreePage (Resource.Drawable.larch, "No.1: The Larch" ),
            new TreePage(Resource.Drawable.maple, "No.2: Maple"),
            new TreePage(Resource.Drawable.birch, "No.3: Birch"),
            new TreePage(Resource.Drawable.coconut, "No.4: Coconut"),
            new TreePage(Resource.Drawable.oak, "No.5: Oak"),
            new TreePage(Resource.Drawable.fir, "No.6: Fir"),
            new TreePage(Resource.Drawable.pine, "No.7: Pine"),
            new TreePage(Resource.Drawable.elm, "No.8: Elm" ),
        };

        public TreeCatalog()
        {
            this.treePages = buildInThreeCatalog;
        }

        public int TreeCount => this.treePages.Length;

        public TreePage this[int index]
        {
            get
            {
                return this.treePages[index];
            }
        }
    }
}