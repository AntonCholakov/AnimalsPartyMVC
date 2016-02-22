using System.Collections.Generic;

namespace AnimalsParty.Models
{
    public class Cat : Animal
    {
        public int PersonID { get; set; }
        public FurColorEnum FurColor { get; set; }

        public virtual Person Person { get; set; }

        public virtual List<Dog> Dogs { get; set; }
    }

    public enum FurColorEnum
    {
        White,
        Black,
        Brown,
        Yellow,
        Green
    }
}