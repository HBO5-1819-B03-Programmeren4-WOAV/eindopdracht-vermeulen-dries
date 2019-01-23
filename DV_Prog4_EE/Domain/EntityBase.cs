using System;

namespace DV_Prog4_EE.Domain
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
