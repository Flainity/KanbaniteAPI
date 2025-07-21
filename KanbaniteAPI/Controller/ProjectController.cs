using KanbaniteAPI.Entity;
using KanbaniteAPI.Model;
using KanbaniteAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace KanbaniteAPI.Controller;

[ApiController]
[Route("project")]
public class ProjectController(IKanbaniteRepository<Project> projectRepository) : ControllerBase
{
    [HttpGet]
    public IEnumerable<Project> List()
    {
        return projectRepository.List();
    }

    [HttpGet("{id}")]
    public Project? Get(Guid id)
    {
        return projectRepository.GetById(id);
    }

    [HttpPost]
    public Project Post([FromBody] ProjectDto projectDto)
    {
        var project = new Project
        {
            Id = Guid.NewGuid(),
            Name = projectDto.Name,
            Shorthand = projectDto.Shorthand
        };
        
        projectRepository.Insert(project);
        projectRepository.Save();

        return project;
    }
}