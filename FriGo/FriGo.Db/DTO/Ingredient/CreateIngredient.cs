using System;

namespace FriGo.Db.DTO.Ingredient
{
    public class CreateIngredient
    {
        public Guid UnitId { get; set; }
        public string Name { get; set; }
    }
}