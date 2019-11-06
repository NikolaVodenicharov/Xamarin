using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace RecycleViewApp
{
    public class PhotoAlbumAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;

        private PhotoAlbum photoAlbum;

        public PhotoAlbumAdapter(PhotoAlbum photoAlbum)
        {
            this.photoAlbum = photoAlbum;
        }

        public override int ItemCount => this.photoAlbum.Count();

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater
                .From(parent.Context)
                .Inflate(Resource.Layout.PhotoCardView, parent, false);

            var photoViewHolder = new PhotoViewHolder(itemView, this.OnClick);

            return photoViewHolder;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var photoViewHolder = holder as PhotoViewHolder;

            photoViewHolder
                .Image
                .SetImageResource(this.photoAlbum[position].PhotoId);

            photoViewHolder
                .Caption
                .Text = this.photoAlbum[position].Caption;
        }

        private void OnClick(int position)
        {
            this.ItemClick?.Invoke(this, position);
        }
    }
}