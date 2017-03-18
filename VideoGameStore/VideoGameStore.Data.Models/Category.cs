using System.Collections.Generic;

namespace VideoGameStore.Data.Models
{
    public class Category
    {
        private ICollection<Game> games;

        public Category()
        {
            this.games = new HashSet<Game>();
        }

        public int Id { get; set; }
        
        public string Name { get; set; }

        public ICollection<Game> Games
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