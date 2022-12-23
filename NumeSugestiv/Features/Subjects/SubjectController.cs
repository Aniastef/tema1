using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;
using NumeSugestiv.Features.Subjects.Models;
using NumeSugestiv.Features.Subjects.Views;

namespace NumeSugestiv.Features.Subjects;

[ApiController]
[Route("subjects")]
public class SubjectController
{
    private static List<SubjectModel> _mockDb = new List<SubjectModel>();
    
    
    [HttpPost]
    public SubjectResponse Add(SubjectModel request)
    {
        var subject = new SubjectModel()//mapping
        {
            Id = Guid.NewGuid().ToString(),
            Name = request.Name,
            ProfessorMail = request.ProfessorMail,
            Grades = request.Grades
        };
        _mockDb.Add(subject);

        return new SubjectResponse
        {
            Id = subject.Id,
            Name=subject.Name,
            ProfessorMail = subject.ProfessorMail,
            Grades = subject.Grades
        };
    }

    [HttpGet]
    public IEnumerable<SubjectResponse> Get()
    {
        return _mockDb.Select(
            subject => new SubjectResponse()
            {
                Id = subject.Id,
                Name=subject.Name,
                ProfessorMail = subject.ProfessorMail,
                Grades = subject.Grades
            }).ToList();
    }

    [HttpGet("{id}")]
    public SubjectResponse Get([FromRoute] string id)
    {
        var subject = _mockDb.FirstOrDefault(x => x.Id == id);
        if (subject is null)
        {
             return null;
        }
        
        return new SubjectResponse()
        {
            Id = subject.Id,
            Name=subject.Name,
            ProfessorMail = subject.ProfessorMail,
            Grades = subject.Grades
        };
        
        
    }
    
    //creati o functie de delete si una de update (HttpDelete si HttpPatch) 
    [HttpDelete("{id}")]
    public SubjectResponse Delete([FromRoute] string id)
    {
        var subject = _mockDb.FirstOrDefault(x => x.Id == id);
        if (subject is null)
        {
            return null;
        }

        _mockDb.Remove(subject);
        
        return new SubjectResponse()
        {
            Id =subject.Id,
            Name=subject.Name,
            ProfessorMail = subject.ProfessorMail,
            Grades = subject.Grades
        };
    }

    [HttpPatch("{id}")]
    public SubjectResponse Update([FromRoute] string id, SubjectRequest request)
    {
        var subject = _mockDb.FirstOrDefault(x => x.Id == id);
        if (subject is null)
        {
            return null;
        }

        subject.Name = request.Name;
        subject.ProfessorMail = request.ProfessorMail;
        subject.Grades = request.Grades;
        
        return new SubjectResponse()
        {
            Id = subject.Id,
            Name=subject.Name,
            ProfessorMail = subject.ProfessorMail,
            Grades = subject.Grades
        };
    }
}