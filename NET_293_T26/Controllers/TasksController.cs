using Microsoft.AspNetCore.Mvc;
using NET_293_T26.Models.Entities;

namespace NET_293_T26.Controllers
{
	public class TasksController : Controller
	{
		private readonly ToDoTasksContext _context;
		public TasksController(ToDoTasksContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> GetListTask()
		{
			var items = _context.ToDoTasks.ToList();
			return Ok(items);
		}

		public async Task<IActionResult> GetTaskById(Guid id)
		{
			var item = _context.ToDoTasks.FirstOrDefault(x => x.Id == id);
			return Ok(item);
		}

		[HttpPost]
		public async Task<IActionResult> AddTask(string ten, int uutien, string trangthai, string mota)
		{
			//1 - Hoan thanh; 2 - Dang lam; 3 - Huy bo
			var item = new ToDoTask
			{
				Id = Guid.NewGuid(),
				Name = ten,
				Priority = uutien.ToString(),
				Status = trangthai,
				Note = mota,
				IsActive = true
			};
			_context.ToDoTasks.Add(item);
			await _context.SaveChangesAsync();
			return Ok(item);
		}

		[HttpPut]
		public async Task<IActionResult> EditTask(Guid id, string ten, int uutien, int trangthai, string mota)
		{
			//1 - Hoan thanh; 2 - Dang lam; 3 - Huy bo
			var item = _context.ToDoTasks.FirstOrDefault(x => x.Id == id);
			if (item == null)
			{
				return NotFound();
			}
			item.Name = ten;
			item.Priority = uutien.ToString();
			item.Status = trangthai.ToString();
			item.Note = mota;
			_context.ToDoTasks.Update(item);
			await _context.SaveChangesAsync();
			return Ok(item);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteTask(Guid id)
		{
			var item = _context.ToDoTasks.FirstOrDefault(x => x.Id == id);
			_context.ToDoTasks.Remove(item);
			await _context.SaveChangesAsync();
			return Ok();
		}
	}
}
