using System;

namespace FriGo.Db.DTO.Ingredients
{
    public class CreateIngredient
    {
        public Guid UnitId { get; set; }
        public string Name { get; set; }
    }
}