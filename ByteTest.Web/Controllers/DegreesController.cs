using ByteTest.Application.Commands.Degree.Models;
using ByteTest.Application.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace ByteTest.Web.Controllers;

public class DegreesController : Controller
{
    private readonly IMediator _mediator;
    
    public DegreesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: Resumes
    public async Task<IActionResult> Index()
    {
        return View(await _mediator.Send(new GetDegreesQuery()));
    }
    
    // GET: Degrees/Create
    public IActionResult Create()
    {
        return PartialView();
    }
    
    // POST: Degrees/Create
    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CommandProperties properties)
    {
        var result = await _mediator.Send(new CreateCommand { Properties = properties } );
        return result.ToResponse();
    }
    
    // GET: Degrees/Update/5
    public async Task<IActionResult> Update(int id)
    {
        var result = await _mediator.Send(new GetDegreeQuery{ Id = id });
        if (result.IsSuccess)
        {
            return PartialView(result.Value);
        }

        return BadRequest();
    }

    // Put: Degrees/Update/5
    [HttpPut]
    public async Task<IActionResult> Update([FromRoute]int id, [FromForm] CommandProperties properties)
    {
        var result = await _mediator.Send(new UpdateCommand { Id = id, Properties = properties } );
        return result.ToResponse();
    }

    // Delete: Degrees/Delete/5
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteCommand{ Id = id });
        return result.ToResponse();
    }
}