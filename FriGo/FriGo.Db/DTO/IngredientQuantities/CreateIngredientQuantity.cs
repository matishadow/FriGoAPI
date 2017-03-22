using System;

namespace FriGo.Db.DTO.IngredientQuantities
{
    public class CreateIngredientQuantity
    {
        public Guid IngredientId { get; set; }
        public decimal Quantity { get; set; }
        public string Description { get; set; }
    }
}
