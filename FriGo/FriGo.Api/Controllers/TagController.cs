using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FriGo.Db.Models.Recipes;
using Swashbuckle.Swagger.Annotations;

namespace FriGo.Api.Controllers
{
    public class TagController : BaseFriGoController
    {
        /// <summary>
        /// Returns all tags
        /// </summary>
        /// <returns>An array of tags</returns>
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(IEnumerable<Tag>))]
        public virtual HttpResponseMessage Get()
        {
            throw new NotImplementedException();
        }       
    }
}
