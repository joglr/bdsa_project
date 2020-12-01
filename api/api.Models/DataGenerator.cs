using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
            var e1 = new Employer { CompanyName = "Spotify", CompanyDescription = "Steams music online", CompanyImage = "ᕕ(⌐■_■)ᕗ ♪♬" };
            var e2 = new Employer { CompanyName = "Fitness World", CompanyDescription = "Gotta get stronk", CompanyImage = "❚█══█❚" };
            var e3 = new Employer { CompanyName = "Wizards of the Coast", CompanyDescription = "Roll som dice, and kill some dragons", CompanyImage = "(∩ ͡° ͜ʖ ͡°)⊃━☆ﾟ. *" };
            var e4 = new Employer { CompanyName = "Star Bucks", CompanyDescription = "Don't talk to me before i get my coffe", CompanyImage = "( -_-)旦~" };
            var e5 = new Employer { CompanyName = "Hogwards", CompanyDescription = "Learn some magic, or get killed trying. Proberbly the last one", CompanyImage = "ᒡ◯ᵔ◯ᒢ" };

            context.Employers.AddRange(e1, e2, e3, e4, e5);

            // Students
            var s1 = new Student { FirstName = "Shrek", LastName = "the Ogre", Capabilities = new[] { c3, c5 } };
            var s2 = new Student { FirstName = "Harry", LastName = "Potter", Capabilities = new[] { c8, c1 } };
            var s3 = new Student { FirstName = "Darth", LastName = "Vader", Capabilities = new[] { c8, c6, c1 } };
            var s4 = new Student { FirstName = "Tony", LastName = "Stark", Capabilities = new[] { c5, c6, c4 } };
            var s5 = new Student { FirstName = "Kaj", LastName = "popkorn", Capabilities = new[] { c2, c4, c7, c1 } };

            // Placements
            var p1 = new Placement { EmployerCompany = e1, RequiredCapabilities = new[] { c1, c8 }, NiceToHaveCapabilities = new[] { c4 }, PlacementImage = "ヽ(⌐■_■)ノ♪♬" };
            var p2 = new Placement { EmployerCompany = e1, RequiredCapabilities = new[] { c3, c5 }, NiceToHaveCapabilities = new[] { c4 }, PlacementImage = "♫♪.ılılıll|̲̅̅●̲̅̅|̲̅̅=̲̅̅|̲̅̅●̲̅̅|llılılı.♫♪" };
            var p3 = new Placement { EmployerCompany = e5, RequiredCapabilities = new[] { c4, c7 }, NiceToHaveCapabilities = new[] { c8 }, PlacementImage = "°º¤ø,¸¸,ø¤º°`°º¤ø,¸,ø¤°º¤ø,¸¸,ø¤º°`°º¤ø,¸" };
            var p4 = new Placement { EmployerCompany = e3, RequiredCapabilities = new[] { c1, c2 }, NiceToHaveCapabilities = new[] { c7 }, PlacementImage = "__̴ı̴̴̡̡̡ ̡͌l̡̡̡ ̡͌l̡*̡̡ ̴̡ı̴̴̡ ̡̡͡|̲̲̲͡͡͡ ̲▫̲͡ ̲̲̲͡͡π̲̲͡͡ ̲̲͡▫̲̲͡͡ ̲|̡̡̡ ̡ ̴̡ı̴̡̡ ̡͌l̡̡̡̡.___" };

            // StudentPlacements
            var SP1 = new StudentPlacement { Student = s2, Placement = p1 };
            var SP2 = new StudentPlacement { Student = s3, Placement = p1 };
            var SP3 = new StudentPlacement { Student = s1, Placement = p2 };
            var SP4 = new StudentPlacement { Student = s5, Placement = p3 };

            s1.Placements = new[] { SP3 };
            s2.Placements = new[] { SP1 };
            s3.Placements = new[] { SP2 };
            s4.Placements = new StudentPlacement[] { };
            s5.Placements = new[] { SP4 };

            p1.Applicants = new[] { SP1, SP2 };
            p2.Applicants = new[] { SP3 };
            p3.Applicants = new[] { SP4 };
            p4.Applicants = new StudentPlacement[] { };

            context.Students.AddRange(s1, s2, s3, s4, s5);
            context.Placements.AddRange(p1, p2, p3, p4);

            context.SaveChanges();
        }
    }
}