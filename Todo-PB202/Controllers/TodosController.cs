using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo_PB202.Services;

namespace Todo_PB202.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodosController : ControllerBase
{

    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly CloudinaryService _cloudinaryService;

    public TodosController(AppDbContext context, IMapper mapper, CloudinaryService cloudinaryService)
    {
        _context = context;
        _mapper = mapper;
        _cloudinaryService = cloudinaryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var todos = await _context.Todos.ToListAsync();

        var dtos = _mapper.Map<List<TodoGetDto>>(todos);

        return Ok(dtos);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(TodoCreateDto dto)
    {
        var todo = _mapper.Map<Todo>(dto);

        await _context.Todos.AddAsync(todo);
        await _context.SaveChangesAsync();

        return Created();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        var todo = await _context.Todos.FindAsync(id);

        if (todo is null)
            return NotFound("This todo item is not found");

        _context.Todos.Remove(todo);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateAsync([FromBody] TodoUpdateDto dto)
    {
        var existTodo = await _context.Todos/*.AsNoTracking()*/.FirstOrDefaultAsync(x => x.Id == dto.Id);

        if (existTodo is null)
            return NotFound("This todo item is not found");

        existTodo = _mapper.Map(dto, existTodo);

        _context.Todos.Update(existTodo);
        await _context.SaveChangesAsync();

        return Ok();
    }

   public class dto
    {
        public IFormFile file{ get; set; }
    }


    [HttpPost("NewImageUpload")]
    public async Task<IActionResult> Test([FromForm] dto dto)
    {
        string url = await _cloudinaryService.FileCreateAsync(dto.file);


        return Ok(url);
    }

    [HttpDelete("DeleteImage")]
    public async Task<IActionResult> Delete(string url)
    {
        await _cloudinaryService.FileDeleteAsync(url);

        return Ok();
    }

}
