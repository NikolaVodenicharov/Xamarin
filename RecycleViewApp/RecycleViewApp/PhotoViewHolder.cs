using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;

namespace RecycleViewApp
{
    public class PhotoViewHolder : RecyclerView.ViewHolder
    {
        public PhotoViewHolder(View itemView, Action<int> listener) 
            : base(itemView)
        {
            this.Image = itemView.FindViewById<ImageView>(Resource.Id.imageView);
            this.Caption = itemView.FindViewById<TextView>(Resource.Id.textView);

            itemView.Click += (sender, e) => listener(base.LayoutPosition);
        }

        public ImageView Image { get; set; }
        public TextView Caption { get; set; }

    }
}