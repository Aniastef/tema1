using NumeSugestiv.Base;
namespace NumeSugestiv.Features.Subjects.Models;

public class SubjectModel:Model
{
     public string Name { get; set; }
     
     public string ProfessorMail { get; set; }

     public List<Double> Grades { get; set; }
}