using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriGo.Db.Models.Ingredients;

namespace FriGo.Db.DTO.Ingredients
{
    public class IngredientDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
