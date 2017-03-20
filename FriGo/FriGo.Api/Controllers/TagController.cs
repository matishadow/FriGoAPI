using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FriGo.Db.Models.Recipe;
using Swashbuckle.Swagger.Annotations;

namespace FriGo.Api.Controllers
{
    public class TagController : ApiController
    {
        /// <summary>
        /// Returns all tags
        /// </summary>
        /// <returns>An array of tags</returns>
        /// <response code="200"></response>
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(IEnumerable<Tag>))]
        public virtual HttpResponseMessage Get()
        {
            throw new NotImplementedException();
        }       
    }
}
