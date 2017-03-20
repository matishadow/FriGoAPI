using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriGo.Db.DTO.IngredientQuantity
{
    public class CreateIngredientQuantity
    {
        public Guid IngredientId { get; set; }
        public decimal Quantity { get; set; }
        public string Description { get; set; }
    }
}
