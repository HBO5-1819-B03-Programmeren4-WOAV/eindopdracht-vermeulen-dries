using System;

namespace Prog5_eindopdracht_DV.Domain
{
    public abstract class EntityBase
    {
        public int Id { get; set; }

        private DateTime? created;
        public DateTime? Created
        {
            get
            {
                return created ?? DateTime.Now;
            }

            set { created = value; }
        }
    }
}
