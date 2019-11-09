namespace ViewPagerUsingFragments
{
    public  class FlashCardDeck
    {
        private static string multiply = "\u00D7";
        private static string divide = "\u00F7";
        private static string plus = "\u002B";
        private static string minus = "\u2212";

        private static FlashCard[] builtInFlashCards = 
        {
            new FlashCard { problem = "42 " + divide + " 7",
                            answer = "6" },
            new FlashCard { problem = "9 " + plus + " 3",
                            answer = "12" },
            new FlashCard { problem = "4 " + multiply + " 7",
                            answer = "28" },
            new FlashCard { problem = "85 " + minus + " 9",
                            answer = "76" },
            new FlashCard { problem = "17 " + plus + " -1",
                            answer = "16" },
            new FlashCard { problem = "64 " + multiply + " 2",
                            answer = "128" }
        };


        private FlashCard[] flashCards;

        public FlashCardDeck() 
        { 
            flashCards = builtInFlashCards; 
        }


        public FlashCard this[int i] { get { return flashCards[i]; } }


        public int NumCards { get { return flashCards.Length; } }
    }
}