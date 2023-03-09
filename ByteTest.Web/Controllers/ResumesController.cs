using ByteTest.Application.Commands.Resume.Models;
using ByteTest.Application.Dtos;
using ByteTest.Application.Queries.Models;
using ByteTest.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace ByteTest.Web.Controllers;

public class ResumesController : Controller
{
    private readonly IMediator _mediator;
    private readonly IUnitOfWork _unitOfWork;
    
    public ResumesController(IMediator mediator, IUnitOfWork unitOfWork)
    {
        _mediator = mediator;
        _unitOfWork = unitOfWork;
    }

    // GET: Resumes
    public async Task<IActionResult> Index()
    {
        return View(await _mediator.Send(new GetResumesQuery()));
    }
    
    // GET: Resumes/Create
    public async Task<IActionResult> Create()
    {
        return PartialView(new CreateUpdateResumeDto
        {
            Degrees = await _unitOfWork.DegreesRepository.ListAsync()
        });
    }
    
    // POST: Resumes/Create
    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CommandProperties properties)
    {
        var result = await _mediator.Send(new CreateCommand { Properties = properties } );
        return result.ToResponse();
    }
    
    // GET: Resumes/Update/5
    public async Task<IActionResult> Update(int id)
    {
        var result = await _mediator.Send(new GetResumeQuery{ Id = id });
        if (result.IsSuccess)
        {
            return PartialView(result.Value);
        }

        return BadRequest();
    }

    // Put: Resumes/Update/5
    [HttpPut]
    public async Task<IActionResult> Update([FromRoute]int id, [FromForm] CommandProperties properties)
    {
        var result = await _mediator.Send(new UpdateCommand { Id = id, Properties = properties } );
        return result.ToResponse();
    }

    // Delete: Resumes/Delete/5
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteCommand{ Id = id });
        return result.ToResponse();
    }
    
    // GET: Resumes/GetCv/5
    public async Task<IActionResult> GetCv(int id)
    {
        var result = await _mediator.Send(new GetResumeCvQuery{ Id = id });
        if (result.IsSuccess)
        {
            return File(result.Value.Cv, result.Value.CvContentType);
        }

        return BadRequest();
    }
}