using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using XamarinHackDayService.DataObjects;
using XamarinHackDayService.Models;

namespace XamarinHackDayService.Controllers
{
    public class NoteController : TableController<Note>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            XamarinHackDayContext context = new XamarinHackDayContext();
            DomainManager = new EntityDomainManager<Note>(context, Request, Services);
        }

        // GET tables/TodoItem
        public IQueryable<Note> GetAllTodoItems()
        {
            return Query();
        }

        // GET tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Note> GetTodoItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Note> PatchTodoItem(string id, Delta<Note> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/TodoItem
        public async Task<IHttpActionResult> PostTodoItem(Note item)
        {
            Note current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new {id = current.Id}, current);
        }

        // DELETE tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTodoItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}