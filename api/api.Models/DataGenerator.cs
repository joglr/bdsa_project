using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using api.Entities;

namespace api.Models
{
  public static class DataGenerator
  {
    public static void GenerateData(this PlaDatContext context)
    {
      // Capabilities
      var c1 = new Capability { Name = "Teamwork", Description = "Being able to work together with other people" };
      var c2 = new Capability { Name = "Obejct oriented programing", Description = "Basic knowledge of the consepts of OOP" };
      var c3 = new Capability { Name = "Functionel programing", Description = "Basic knowledge of the consepts of functionel programing" };
      var c4 = new Capability { Name = "The mircosoft package", Description = "Using programs such as wword, excel and powerpoint" };
      var c5 = new Capability { Name = "Java", Description = "Can program in the language Java" };
      var c6 = new Capability { Name = "C#", Description = "Can program in the language C#" };
      var c7 = new Capability { Name = "Irich", Description = "profesional comunication" };
      var c8 = new Capability { Name = "Magic", Description = "wave a wand and stuff" };

      context.Capabilities.AddRange(c1, c2, c3, c4, c5, c6, c7, c8);

      // Employers
      var spotify = new Employer { CompanyName = "Spotify", CompanyDescription = "Steams music online", CompanyImage = "ᕕ(⌐■_■)ᕗ ♪♬" };
      var fitnessWorld = new Employer { CompanyName = "Fitness World", CompanyDescription = "Gotta get stronk", CompanyImage = "❚█══█❚" };
      var WotC = new Employer { CompanyName = "Wizards of the Coast", CompanyDescription = "Roll som dice, and kill some dragons", CompanyImage = "(∩ ͡° ͜ʖ ͡°)⊃━☆ﾟ. *" };
      var starBucks = new Employer { CompanyName = "Star Bucks", CompanyDescription = "Don't talk to me before i get my coffe", CompanyImage = "( -_-)旦~" };
      var hogwards = new Employer { CompanyName = "Hogwards", CompanyDescription = "Learn some magic, or get killed trying. Proberbly the last one", CompanyImage = "ᒡ◯ᵔ◯ᒢ" };

      context.Employers.AddRange(spotify, fitnessWorld, WotC, starBucks, hogwards);

      // Students
      var s1 = new Student { FirstName = "Shrek", LastName = "the Ogre", PhoneNumber = "1234", Email = "shrek@hotmail.com", Capabilities = new List<Capability> { c3, c5 } };
      var s2 = new Student { FirstName = "Harry", LastName = "Potter", PhoneNumber = "1234", Email = "harry@hotmail.com", Capabilities = new List<Capability> { c8, c1 } };
      var s3 = new Student { FirstName = "Darth", LastName = "Vader", PhoneNumber = "1234", Email = "darth@hotmail.com", Capabilities = new List<Capability> { c8, c6, c1 } };
      var s4 = new Student { FirstName = "Tony", LastName = "Stark", PhoneNumber = "1234", Email = "tony@hotmail.com", Capabilities = new List<Capability> { c5, c6, c4 } };
      var s5 = new Student { FirstName = "Kaj", LastName = "popkorn", PhoneNumber = "1234", Email = "kaj@hotmail.com", Capabilities = new List<Capability> { c2, c4, c7, c1 } };

      context.Students.AddRange(s1, s2, s3, s4, s5);

      // Placements
      var p1 = new Placement
      {
        Title = "Musik mand",
        EmployerCompany = spotify,
        PlacementImage = "ヽ(⌐■_■)ノ♪♬",
        Description = "Make some cool music stuff",
        Location = "Copenhagen",
        MinHours = 12,
        MaxHours = 18,
        Capabilities = new List<Capability> { c1, c8 },
      };
      var p2 = new Placement
      {
        Title = "Music man",
        EmployerCompany = spotify,
        PlacementImage = "♫♪.ılılıll|̲̅̅●̲̅̅|̲̅̅=̲̅̅|̲̅̅●̲̅̅|llılılı.♫♪",
        Description = "Make some cool music",
        Location = "Copenhagen",
        MinHours = 12,
        MaxHours = 18,
        Capabilities = new List<Capability> { c3, c5 },
      };
      var p3 = new Placement
      {
        Title = "Grand Wizard",
        EmployerCompany = hogwards,
        PlacementImage = "°º¤ø,¸¸,ø¤º°`°º¤ø,¸,ø¤°º¤ø,¸¸,ø¤º°`°º¤ø,¸",
        Description = "Make some cool wizard spells stuffs",
        Location = "Copenhagen",
        MinHours = 12,
        MaxHours = 18,
        Capabilities = new List<Capability> { c4, c7 },
      };
      var p4 = new Placement
      {
        Title = "Sømand",
        EmployerCompany = WotC,
        PlacementImage = "__̴ı̴̴̡̡̡ ̡͌l̡̡̡ ̡͌l̡*̡̡ ̴̡ı̴̴̡ ̡̡͡|̲̲̲͡͡͡ ̲▫̲͡ ̲̲̲͡͡π̲̲͡͡ ̲̲͡▫̲̲͡͡ ̲|̡̡̡ ̡ ̴̡ı̴̡̡ ̡͌l̡̡̡̡.___",
        Description = "Make some cool coasts",
        Location = "Copenhagen",
        MinHours = 12,
        MaxHours = 18,
        Capabilities = new List<Capability> { c1, c2 },
      };

      context.Placements.AddRange(p1, p2, p3, p4);


      // StudentPlacements
      /*var SP1 = new StudentPlacement { Student = s2, Placement = p1 };
      var SP2 = new StudentPlacement { Student = s3, Placement = p1 };
      var SP3 = new StudentPlacement { Student = s1, Placement = p2 };
      var SP4 = new StudentPlacement { Student = s5, Placement = p3 };

      s1.Placements = new[] { SP3 };
      s2.Placements = new[] { SP1 };
      s3.Placements = new[] { SP2 };
      s4.Placements = new StudentPlacement[] { };
      s5.Placements = new[] { SP4 };

      p1.Applicants = new List<Student> { SP1, SP2 };
      p2.Applicants = new[] { SP3 };
      p3.Applicants = new[] { SP4 };
      p4.Applicants = new StudentPlacement[] { };

      context.Students.AddRange(s1, s2, s3, s4, s5);
      context.Placements.AddRange(p1, p2, p3, p4);*/

      context.SaveChanges();
    }
  }
}
