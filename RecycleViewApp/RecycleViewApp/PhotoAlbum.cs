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

namespace RecycleViewApp
{
    public class PhotoAlbum
    {
        private static Photo[] builtInPhotos = {
            new Photo { PhotoId = Resource.Drawable.buckingham_guards,
                        Caption = "Buckingham Palace" },
            new Photo { PhotoId = Resource.Drawable.la_tour_eiffel,
                        Caption = "The Eiffel Tower" },
            new Photo { PhotoId = Resource.Drawable.louvre_1,
                        Caption = "The Louvre" },
            new Photo { PhotoId = Resource.Drawable.before_mobile_phones,
                        Caption = "Before mobile phones" },
            new Photo { PhotoId = Resource.Drawable.big_ben_1,
                        Caption = "Big Ben skyline" },
            new Photo { PhotoId = Resource.Drawable.big_ben_2,
                        Caption = "Big Ben from below" },
            new Photo { PhotoId = Resource.Drawable.london_eye,
                        Caption = "The London Eye" },
            new Photo { PhotoId = Resource.Drawable.eurostar,
                        Caption = "Eurostar Train" },
            new Photo { PhotoId = Resource.Drawable.arc_de_triomphe,
                        Caption = "Arc de Triomphe" },
            new Photo { PhotoId = Resource.Drawable.louvre_2,
                        Caption = "Inside the Louvre" },
            new Photo { PhotoId = Resource.Drawable.versailles_fountains,
                        Caption = "Versailles fountains" },
            new Photo { PhotoId = Resource.Drawable.modest_accomodations,
                        Caption = "Modest accomodations" },
            new Photo { PhotoId = Resource.Drawable.notre_dame,
                        Caption = "Notre Dame" },
            new Photo { PhotoId = Resource.Drawable.inside_notre_dame,
                        Caption = "Inside Notre Dame" },
            new Photo { PhotoId = Resource.Drawable.seine_river,
                        Caption = "The Seine" },
            new Photo { PhotoId = Resource.Drawable.rue_cler,
                        Caption = "Rue Cler" },
            new Photo { PhotoId = Resource.Drawable.champ_elysees,
                        Caption = "The Avenue des Champs-Elysees" },
            new Photo { PhotoId = Resource.Drawable.seine_barge,
                        Caption = "Seine barge" },
            new Photo { PhotoId = Resource.Drawable.versailles_gates,
                        Caption = "Gates of Versailles" },
            new Photo { PhotoId = Resource.Drawable.edinburgh_castle_2,
                        Caption = "Edinburgh Castle" },
            new Photo { PhotoId = Resource.Drawable.edinburgh_castle_1,
                        Caption = "Edinburgh Castle up close" },
            new Photo { PhotoId = Resource.Drawable.old_meets_new,
                        Caption = "Old meets new" },
            new Photo { PhotoId = Resource.Drawable.edinburgh_from_on_high,
                        Caption = "Edinburgh from on high" },
            new Photo { PhotoId = Resource.Drawable.edinburgh_station,
                        Caption = "Edinburgh station" },
            new Photo { PhotoId = Resource.Drawable.scott_monument,
                        Caption = "Scott Monument" },
            new Photo { PhotoId = Resource.Drawable.view_from_holyrood_park,
                        Caption = "View from Holyrood Park" },
            new Photo { PhotoId = Resource.Drawable.tower_of_london,
                        Caption = "Outside the Tower of London" },
            new Photo { PhotoId = Resource.Drawable.tower_visitors,
                        Caption = "Tower of London visitors" },
            new Photo { PhotoId = Resource.Drawable.one_o_clock_gun,
                        Caption = "One O'Clock Gun" },
            new Photo { PhotoId = Resource.Drawable.victoria_albert,
                        Caption = "Victoria and Albert Museum" },
            new Photo { PhotoId = Resource.Drawable.royal_mile,
                        Caption = "The Royal Mile" },
            new Photo { PhotoId = Resource.Drawable.museum_and_castle,
                        Caption = "Edinburgh Museum and Castle" },
            new Photo { PhotoId = Resource.Drawable.portcullis_gate,
                        Caption = "Portcullis Gate" },
            new Photo { PhotoId = Resource.Drawable.to_notre_dame,
                        Caption = "Left or right?" },
            new Photo { PhotoId = Resource.Drawable.pompidou_centre,
                        Caption = "Pompidou Centre" },
            new Photo { PhotoId = Resource.Drawable.heres_lookin_at_ya,
                        Caption = "Here's Lookin' at Ya!" },
            };

        private List<Photo> photos;
        private Random random;

        public PhotoAlbum()
        {
            this.photos = builtInPhotos.ToList();
            this.random = new Random();
        }

        public int Count()
        {
            return this.photos.Count;
        }

        public Photo this[int i]
        {
            get { return this.photos[i]; }
        }

        public void Shuffle()
        {
            for (int i = 0; i < this.photos.Count; ++i)
            {
                Photo tmpPhoto = this.photos[i];

                int rnd = this.random.Next(i, this.photos.Count);

                this.photos[i] = this.photos[rnd];
                this.photos[rnd] = tmpPhoto;
            }
        }
    }
}