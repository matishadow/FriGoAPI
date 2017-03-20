﻿using FluentValidation.Attributes;
using FriGo.Db.ModelValidators;

namespace FriGo.Db.Models.Ingredient
{
    [Validator(typeof(IngredientValidator))]
    public class Ingredient : Entity
    {
        public string Name { get; set; }
        public virtual Unit Unit { get; set; }
    }
}