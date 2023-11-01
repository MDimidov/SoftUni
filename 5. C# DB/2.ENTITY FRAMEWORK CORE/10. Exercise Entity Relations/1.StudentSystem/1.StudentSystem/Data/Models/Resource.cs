using System.ComponentModel.DataAnnotations;
using P01_StudentSystem.Data.Models.Enum;

namespace P01_StudentSystem.Data.Models;

public class Resource
{
    public int ResourceId { get; set; }

    [MaxLength(50)]
    public string Name { get; set; } = null!;

    //Do it varchar
    public string Url { get; set; } = null!;

    public ResourceType ResourceType { get; set; }

    public int CourseId { get; set; }

    public Course Course { get; set; } = null!;
}
