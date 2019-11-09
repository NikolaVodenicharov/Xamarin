using Android.Content;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace ViewPagerUsingViews
{
    public class TreePagerAdapter : PagerAdapter
    {
        private Context context;
        private TreeCatalog treeCatalog;

        public TreePagerAdapter(Context context, TreeCatalog treeCatalog)
        {
            this.context = context;
            this.treeCatalog = treeCatalog;
        }

        public override int Count => treeCatalog.TreeCount;

        public override Java.Lang.Object InstantiateItem(View container, int position)
        {
            var imageView = new ImageView(context);
            imageView.SetImageResource(this.treeCatalog[position].ImageID);

            var viewPager = container.JavaCast<ViewPager>();
            viewPager.AddView(imageView);

            return imageView;
        }

        public override void DestroyItem(View container, int position, Java.Lang.Object view)
        {
            var viewPager = container.JavaCast<ViewPager>();
            viewPager.RemoveView(view as View);
        }

        public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
        {
            return new Java.Lang.String(treeCatalog[position].Caption);
        }

        public override bool IsViewFromObject(View view, Object @object)
        {
            return view == @object;
        }
    }
}