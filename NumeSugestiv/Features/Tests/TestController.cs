using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;
using NumeSugestiv.Features.Tests.Models;
using NumeSugestiv.Features.Tests.Views;

namespace NumeSugestiv.Features.Tests;

[ApiController]
[Route("tests")]
public class TestController
{
    private static List<TestModel> _mockDb = new List<TestModel>();
    
    [HttpPost]
    public TestResponse Add(TestModel request)
    {
        var test = new TestModel()//mapping
        {
            Id = Guid.NewGuid().ToString(),
            Subject = request.Subject,
            TestDate = request.TestDate,
        };
        _mockDb.Add(test);

        return new TestResponse()
        {
            Id = test.Id,
            Subject= test.Subject,
            TestDate = test.TestDate,
        };
    }

    [HttpGet]
    public IEnumerable<TestResponse> Get()
    {
        return _mockDb.Select(
           test => new TestResponse()
            {
                Id = test.Id,
                Subject= test.Subject,
                TestDate = test.TestDate,
            }).ToList();
    }

    [HttpGet("{id}")]
    public TestResponse Get([FromRoute] string id)
    {
        var test = _mockDb.FirstOrDefault(x => x.Id == id);
        if (test is null)
        {
             return null;
        }
        
        return new TestResponse()
        {
            Id = test.Id,
            Subject= test.Subject,
            TestDate = test.TestDate,
        };
        
        
    }
    
    //creati o functie de delete si una de update (HttpDelete si HttpPatch) 
    [HttpDelete("{id}")]
    public TestResponse Delete([FromRoute] string id)
    {
        var test = _mockDb.FirstOrDefault(x => x.Id == id);
        if (test is null)
        {
            return null;
        }

        _mockDb.Remove(test);
        
        return new TestResponse()
        {
            Id = test.Id,
            Subject= test.Subject,
            TestDate = test.TestDate,
        };
    }

    [HttpPatch("{id}")]
    public TestResponse Update([FromRoute] string id, TestRequest request)
    {
        var test = _mockDb.FirstOrDefault(x => x.Id == id);
        if (test is null)
        {
            return null;
        }

        test.Subject = request.Subject;
        test.TestDate = request.TestDate;
        
        return new TestResponse()
        {
            Id = test.Id,
            Subject= test.Subject,
            TestDate = test.TestDate,
        };
    }
}