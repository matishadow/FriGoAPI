using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FriGo.Db.DTO.Ingredient;
using FriGo.Db.DTO.Unit;
using FriGo.Db.Models;
using FriGo.Db.Models.Ingredient;
using FriGo.ServiceInterfaces;
using Swashbuckle.Swagger.Annotations;

namespace FriGo.Api.Controllers
{
    public class UnitController : ApiController
    {
        /// <summary>
        /// Returns all types of unit
        /// </summary>
        /// <returns>An array of units</returns>
        /// <response code="200"></response>
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(IEnumerable<Unit>))]
        public virtual HttpResponseMessage Get()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get one unit by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One type of unit</returns>
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(Unit))]
        public virtual HttpResponseMessage Get(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create new type of unit
        /// </summary>
        /// <param name="createUnit"></param>
        [SwaggerResponse(HttpStatusCode.Created, Type = typeof(Ingredient), Description = "Unit created")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, Type = typeof(Error), Description = "Forbidden")]
        [Authorize]
        public virtual HttpResponseMessage Post(CreateUnit createUnit)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Modify existing type of unit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="editUnit"></param>
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(Ingredient), Description = "Unit updated")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, Type = typeof(Error), Description = "Forbidden")]
        [SwaggerResponse(HttpStatusCode.NotFound, Type = typeof(Error), Description = "Not found")]
        [Authorize]
        public virtual void Put(Guid id, EditUnit editUnit)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete type of unit
        /// </summary>
        /// <param name="id"></param>
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Unit deleted")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, Type = typeof(Error), Description = "Forbidden")]
        [SwaggerResponse(HttpStatusCode.NotFound, Type = typeof(Error), Description = "Not found")]
        [Authorize]
        public virtual void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
