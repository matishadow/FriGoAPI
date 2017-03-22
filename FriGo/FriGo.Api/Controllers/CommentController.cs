using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using FriGo.Db.DTO.Social;
using FriGo.Db.Models;
using FriGo.Db.Models.Social;
using FriGo.ServiceInterfaces;
using Swashbuckle.Swagger.Annotations;

namespace FriGo.Api.Controllers
{
    public class CommentController : BaseFriGoController
    {
        public CommentController(IMapper autoMapper) : base(autoMapper)
        {
        }

        /// <summary>
        /// Get comments of recipe
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns>Rating of a recipe</returns>
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(IEnumerable<CommentDto>))]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Not found")]
        public virtual HttpResponseMessage Get(Guid recipeId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Edit comment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="editComment"></param>
        /// <returns></returns>
        [Authorize]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(CommentDto), Description = "Comment updated")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, Type = typeof(Error), Description = "Forbidden")]
        [SwaggerResponse(HttpStatusCode.NotFound, Type = typeof(Error), Description = "Not found")]
        [Authorize]
        public virtual HttpResponseMessage Put(Guid id, EditComment editComment)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Comment recipe
        /// </summary>
        /// <param name="recipeId"></param>
        /// <param name="createComment"></param>
        /// <returns></returns>
        [Authorize]
        [SwaggerResponse(HttpStatusCode.Created, Type = typeof(CommentDto), Description = "Comment created")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, Type = typeof(Error), Description = "Forbidden")]
        [Authorize]
        public virtual HttpResponseMessage Post(Guid recipeId, CreateComment createComment)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete comment
        /// </summary>
        /// <param name="id"></param>
        [Authorize]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Comment deleted")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, Type = typeof(Error), Description = "Forbidden")]
        [SwaggerResponse(HttpStatusCode.NotFound, Type = typeof(Error), Description = "Not found")]
        [Authorize]
        public virtual HttpResponseMessage Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
