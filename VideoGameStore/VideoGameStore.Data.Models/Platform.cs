using System.Collections.Generic;

namespace VideoGameStore.Data.Models
{
    public class Platform
    {
        private ICollection<Game> games;

        public Platform()
        {
            this.games = new HashSet<Game>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Game> Games
        {
            get
            {
                return this.games;
            }
            set
            {
                this.games = value;
            }
        }
    }
}