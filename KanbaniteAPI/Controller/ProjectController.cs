using System.Net;
using KanbaniteAPI.Contracts;
using KanbaniteAPI.Domain.Project;
using KanbaniteAPI.Domain.Task;
using KanbaniteAPI.Entity;
using KanbaniteAPI.Extension;
using KanbaniteAPI.Repository;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace KanbaniteAPI.Controller;

[ApiController]
[Route("project")]
public class ProjectController(IKanbaniteRepository<Project> projectRepository) : ControllerBase
{
    [HttpGet]
    [EndpointSummary("List Projects")]
    [EndpointDescription("Lists all projects currently in the system")]
    public async Task<KanbaniteResponse<List<ProjectDetailDto>>> List()
    {
        var projects = await projectRepository.ListAsync();

        return this.SendApiResponse(projects.Adapt<List<ProjectDetailDto>>());
    }

    [HttpGet("{id}")]
    [EndpointSummary("Get Project")]
    [EndpointDescription("Get a project by its ID")]
    public async Task<KanbaniteResponse<ProjectDetailDto>> Get([FromRoute] string id)
    {
        if (!Guid.TryParse(id, out var guid))
        {
            return this.SendApiError<ProjectDetailDto>(["Invalid ID format"], "The provided ID format is invalid.");
        }
        
        var project = await projectRepository.GetByIdAsync(guid);

        return project.IsSome
            ? this.SendApiResponse(project.Adapt<ProjectDetailDto>())
            : this.SendApiError<ProjectDetailDto>(["Project not found"], $"Project with id {id} does not exist.",
                HttpStatusCode.NotFound);
    }
}