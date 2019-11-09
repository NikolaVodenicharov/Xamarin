using System;
using Android.Support.V4.App;

namespace ViewPagerUsingFragments
{
    public class FlashCardDeckAdapter : FragmentPagerAdapter
    {
        private FlashCardDeck deck;

        public FlashCardDeckAdapter(Android.Support.V4.App.FragmentManager fragmentManager, FlashCardDeck flashCardDeck)
            :base(fragmentManager)
        {
            this.deck = flashCardDeck;
        }

        public override int Count => this.deck.NumCards;

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            return 
                FlashCardFragment
                .CreateInstance(
                    this.deck[position].Problem,
                    this.deck[position].Answer)
                as Android.Support.V4.App.Fragment;
        }

        public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
        {
            return new Java.Lang.String("Problem " + (position + 1));
        }
    }
}