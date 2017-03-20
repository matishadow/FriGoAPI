using System;
using System.Collections.Generic;
using FriGo.Db.Models.Ingredients;
using FriGo.Db.Models.Social;

namespace FriGo.Db.Models.Recipes
{
    public class Recipe : Entity
    {
        public Recipe()
        {
            CreatedAt = DateTime.Now;
        }

        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
