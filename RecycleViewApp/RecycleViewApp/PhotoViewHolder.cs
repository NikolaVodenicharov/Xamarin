using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace RecycleViewApp
{
    public class PhotoViewHolder : RecyclerView.ViewHolder
    {
        public PhotoViewHolder(View itemView) 
            : base(itemView)
        {
            this.Image = itemView.FindViewById<ImageView>(Resource.Id.imageView);
            this.Caption = itemView.FindViewById<TextView>(Resource.Id.textView);
        }

        public ImageView Image { get; set; }
        public TextView Caption { get; set; }

    }
}