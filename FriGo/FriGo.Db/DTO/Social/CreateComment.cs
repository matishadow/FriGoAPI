using System;
using FriGo.Db.DTO.Account;
using FriGo.Db.DTO.Recipe;

namespace FriGo.Db.DTO.Social
{
    public class CreateComment
    {        
        public Guid RecipeId { get; set; }     
        public string Text { get; set; }
    }
}