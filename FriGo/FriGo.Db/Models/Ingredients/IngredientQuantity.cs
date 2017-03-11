using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriGo.Db.Models.Ingredients
{
    public class IngredientQuantity : Entity
    {
        public int Quantity { get; set; }
        public Guid IngredientId { get; set; }

        public virtual Ingredient Ingredient { get; set; }
    }
}
