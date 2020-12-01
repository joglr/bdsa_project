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
            var s1 = new Student
            {
                FirstName = "Shrek",
                LastName = "the Ogre",
                Capabilities = new[] { c3, c5 }
            };

            context.Students.AddRange(s1);
            // Placements


            context.SaveChanges();
        }
    }
}