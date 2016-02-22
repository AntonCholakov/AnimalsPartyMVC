using System.Collections.Generic;

namespace AnimalsParty.Models
{
    public class Dog : Animal
    {
        public int PersonID { get; set; }
        public BreedEnum Breed { get; set; }

        public virtual Person Person { get; set; }

        public virtual List<Cat> Cats { get; set; }
    }

    public enum BreedEnum
    {
        TestBreed1,
        TestBreed2,
        TestBreed3,
        TestBreed4,
        TestBreed5,
    }
}