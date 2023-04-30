using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence;

public class Seed
{
    public static async Task SeedData(DataContext context,
        UserManager<User>? userManager, RoleManager<IdentityRole> roleManager)
    {
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            var role = new IdentityRole(){Name = "Admin"};
            await roleManager.CreateAsync(role);
        }
        if (!await roleManager.RoleExistsAsync("Resident"))
        {
            var role = new IdentityRole(){Name = "Resident"};
            await roleManager.CreateAsync(role);
        }
        if (!await roleManager.RoleExistsAsync("Student council"))
        {
            var role = new IdentityRole(){Name = "Student council"};
            await roleManager.CreateAsync(role);
        }
        if (!await roleManager.RoleExistsAsync("Commandant"))
        {
            var role = new IdentityRole(){Name = "Commandant"};
            await roleManager.CreateAsync(role);
        }
        if (!await roleManager.RoleExistsAsync("Cleaner"))
        {
            var role = new IdentityRole(){Name = "Cleaner"};
            await roleManager.CreateAsync(role);
        }
        if (!await roleManager.RoleExistsAsync("Security guard"))
        {
            var role = new IdentityRole(){Name = "Security guard"};
            await roleManager.CreateAsync(role);
        }
        if (!await roleManager.RoleExistsAsync("Duty officer"))
        {
            var role = new IdentityRole(){Name = "Duty officer"};
            await roleManager.CreateAsync(role);
        }
        if (!await roleManager.RoleExistsAsync("Supply manager"))
        {
            var role = new IdentityRole(){Name = "Supply manager"};
            await roleManager.CreateAsync(role);
        }
        if (!await roleManager.RoleExistsAsync("Linen keeper"))
        {
            var role = new IdentityRole(){Name = "Linen keeper"};
            await roleManager.CreateAsync(role);
        }
        if (!await roleManager.RoleExistsAsync("Fixer"))
        {
            var role = new IdentityRole(){Name = "Fixer"};
            await roleManager.CreateAsync(role);
        }
        
        if(context.Violations.Any())
            return;
        
        
        var AlexUser = new User
        {
            FirstName = "Aleksey",
            LastName = "Alekseev",
            MiddleName = "Petrovich",
            BirthDate = DateTime.UtcNow.AddYears(-40),
            Email = "alex@test.com",
            UserName = "alex@test.com",
            PhoneNumber = "1234567898",
            IsDeleted = false,
        };
        
        var SergeiUser = new User()
        {
            FirstName = "Sergei",
            LastName = "Petrov",
            MiddleName = "Petrovich",
            BirthDate = DateTime.UtcNow.AddYears(-40),
            Email = "sergei@test.com",
            UserName = "sergei@test.com",
            PhoneNumber = "1234567898",
            IsDeleted = false
        };
        
        var addressSvib = new Address()
        {
            Corps = 1,
            House = 2,
            Street = "Petrovskaya",
            Town = "Moscow",
            Country = "Russia"
        };
        
        var address2 = new Address()
        {
            Corps = 4,
            House = 2,
            Street = "Snezhaya",
            Town = "Rostov",
            Country = "Russia"
        };
        
        var address3 = new Address()
        {
            Corps = 4,
            House = 16,
            Street = "Snezhaya",
            Town = "Moscow",
            Country = "Russia"
        };
        var address4 = new Address()
        {
            Corps = 4,
            House = 2,
            Street = "Snezhaya",
            Town = "Rostov",
            Country = "Russia"
        };
        
        var address5 = new Address()
        {
            Corps = 4,
            House = 16,
            Street = "Snezhaya",
            Town = "Moscow",
            Country = "Russia"
        };

        var passportAlex = new Passport()
        {
            PassportSeries = "1234",
            PassportNumber = "123456",
            Gender = "м",
            RegisteredPlace = address3,
            BirthPlace = address2,
            IssuedBy = "issued by",
            IssuedCode = "1234",
            IssuedDate = DateTime.UtcNow,
            BirthDate = DateTime.UtcNow.AddYears(-40),
            User = AlexUser
        };
        
        var svibCampus = new Campus()
        {
            Name = "Komplesk objeshitiy nomer 3 korpus 4",
            HtmlInfo = "<h1 style=\"color: #5e9ca0;\">You can edit <span style=\"color: #2b2301;\">this demo</span> text!</h1><h2 style=\"color: #2e6c80;\">How to use the editor:</h2><p>Paste your documents in the visual editor on the left or your HTML code in the source editor in the right. <br />Edit any of the two areas and see the other changing in real time.&nbsp;</p><p>Click the <span style=\"background-color: #2b2301; color: #fff; display: inline-block; padding: 3px 10px; font-weight: bold; border-radius: 5px;\">Clean</span> button to clean your source code.</p><h2 style=\"color: #2e6c80;\">Some useful features:</h2><ol style=\"list-style: none; font-size: 14px; line-height: 32px; font-weight: bold;\"><li style=\"clear: both;\"><img style=\"float: left;\" src=\"https://html-online.com/img/01-interactive-connection.png\" alt=\"interactive connection\" width=\"45\" /> Interactive source editor</li></ol><h2 style=\"color: #2e6c80;\">Cleaning options:</h2><p><strong>Save this link into your bookmarks and share it with your friends. It is all FREE! </strong><br /><strong>Enjoy!</strong></p><p><strong>&nbsp;</strong></p>",
            Address = addressSvib
        };

        var slesarProfession = new Profession()
        {
            Name = "Слесарь"
        };
        
        var employeeAlex = new Employee()
        {
            EmploymentDate = DateTime.UtcNow.AddYears(-40),
            User = AlexUser,
            Professions = new HashSet<Profession>{slesarProfession},
            Campuses = new HashSet<Campus>(){svibCampus}
        };

        var room1610 = new Room()
        {
            Block = 1610,
            BlockCode = "м",
            RoomRating = 10,
            RepairDate = DateTime.UtcNow.AddYears(-10)
        };

        var SergeiResident = new Resident()
        {
            GraduationDate = DateTime.UtcNow.AddYears(3),
            IsLeftCampus = false,
            RoomName = "1610Б",
            Campus = svibCampus,
            Room = room1610,
            User = SergeiUser
        };
        
        var passportSergei = new Passport()
        {
            PassportSeries = "1234",
            PassportNumber = "123456",
            Gender = "м",
            RegisteredPlace = address4,
            BirthPlace = address5,
            IssuedBy = "issued by",
            IssuedCode = "1234",
            IssuedDate = DateTime.UtcNow,
            BirthDate = DateTime.UtcNow.AddYears(-40),
            User = AlexUser
        };

        var news = new News()
        {
            CreateDate = DateTime.UtcNow,
            Title = "Title",
            Content = "Content",
            MainPhotoId = Guid.Empty,
            Employee = employeeAlex
        };

        var thing = new Thing()
        {
            Name = "stul obuknoveniy",
            
        };

        
        var roomThing = new RoomThing()
        {
            Room = room1610,
            Thing = thing,
            Count = 3
        };

        var violation = new Violation()
        {
            Description = "Шумели ночью",
            Employee = employeeAlex,
            IncidentDateTime = DateTime.UtcNow.AddYears(-1),
            IsSpent = false,
            Resident = SergeiResident
        };


        string password = "Password123!";
        await userManager.CreateAsync(SergeiUser, password);
        await userManager.CreateAsync(AlexUser, password);
        await context.Residents.AddAsync(SergeiResident);
        await context.Employees.AddAsync(employeeAlex);
        await context.News.AddAsync(news);
        await context.Passports.AddAsync(passportAlex);
        await context.Passports.AddAsync(passportSergei);
        await context.Professions.AddAsync(slesarProfession);
        await context.Rooms.AddAsync(room1610);
        await context.RoomThings.AddAsync(roomThing);
        await context.Things.AddAsync(thing);
        await context.Violations.AddAsync(violation);

        await context.SaveChangesAsync();
        //add user with such roles as admin, resident, student council, commandant,
        //cleaner, security guard, duty officer, supply manager, linen keeper, fixers(Электромонтер, столяр-плотник, слесарь-сантехник:)

    }
}