namespace ViewPagerUsingViews
{
    public class TreePage
    {
        public TreePage(int imageId, string caption)
        {
            this.ImageID = imageId;
            this.Caption = caption;
        }

        public int ImageID { get; set; }

        public string Caption { get; set; }
    }
}