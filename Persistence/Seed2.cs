// using Domain;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.EntityFrameworkCore;
//
// namespace Persistence;
//
// public class Seed2
// {
//     public static async Task SeedData(CampusContext context,
//         UserManager<User> userManager, RoleManager<UserRole> roleManager)
//     {
//         #region Add roles
//         
//         if (!await roleManager.RoleExistsAsync("Admin"))
//         {
//             var role = new UserRole(){Name = "Admin"};
//             await roleManager.CreateAsync(role);
//         }
//         if (!await roleManager.RoleExistsAsync("Resident"))
//         {
//             var role = new UserRole(){Name = "Resident"};
//             await roleManager.CreateAsync(role);
//         }
//         if (!await roleManager.RoleExistsAsync("Student council"))
//         {
//             var role = new UserRole(){Name = "Student council"};
//             await roleManager.CreateAsync(role);
//         }
//         if (!await roleManager.RoleExistsAsync("Commandant"))
//         {
//             var role = new UserRole(){Name = "Commandant"};
//             await roleManager.CreateAsync(role);
//         }
//         if (!await roleManager.RoleExistsAsync("Cleaner"))
//         {
//             var role = new UserRole(){Name = "Cleaner"};
//             await roleManager.CreateAsync(role);
//         }
//         if (!await roleManager.RoleExistsAsync("Security guard"))
//         {
//             var role = new UserRole(){Name = "Security guard"};
//             await roleManager.CreateAsync(role);
//         }
//         if (!await roleManager.RoleExistsAsync("Duty officer"))
//         {
//             var role = new UserRole(){Name = "Duty officer"};
//             await roleManager.CreateAsync(role);
//         }
//         if (!await roleManager.RoleExistsAsync("Supply manager"))
//         {
//             var role = new UserRole(){Name = "Supply manager"};
//             await roleManager.CreateAsync(role);
//         }
//         if (!await roleManager.RoleExistsAsync("Linen keeper"))
//         {
//             var role = new UserRole(){Name = "Linen keeper"};
//             await roleManager.CreateAsync(role);
//         }
//         if (!await roleManager.RoleExistsAsync("Fixer"))
//         {
//             var role = new UserRole(){Name = "Fixer"};
//             await roleManager.CreateAsync(role);
//         }
//         
//         #endregion
//
//         var campus1 = new Campus()
//         {
//             Name = "Комплекс общежитий № 3 управления по взаимодействию с проживающими РУТ МИИТ, корпус 3",
//             Address = new Address()
//             {
//                 Country = "Russia",
//                 Town = "Moscow",
//                 Street = "Snezhnaya",
//                 House = 16,
//                 Corps = 4
//             },
//             HtmlInfo = "Campus"
//         };
//         if (!context.Campuses.Any()) await context.Campuses.AddAsync(campus1);
//         var password = "Pa$$word123!";
//         
//         if (!await context.Employees.AnyAsync())
//         {
//             
//             await context.Campuses.AddAsync(campus1);
//             
//             var user1 = new User
//             {
//                 FirstName = "Петя",
//                 LastName = "Петров",
//                 MiddleName = "Петрович",
//                 BirthDate = DateTime.UtcNow.AddYears(-40),
//                 UserName = "petya@test.com",
//                 Email = "petya@test.com"
//             };
//             var commendProf = new Profession()
//             {
//                 Name = "Коммендант"
//             };
//             var employee1 = new Employee()
//             {
//                 EmploymentDate = DateTime.Now.AddYears(-4),
//                 User = user1,
//                 Profession = commendProf,
//                 Campuses = new HashSet<Campus>(){campus1}
//             };
//             
//             
//             var user2 = new User
//             {
//                 FirstName = "Антон",
//                 LastName = "Антонов",
//                 MiddleName = "Антонович",
//                 BirthDate = DateTime.UtcNow.AddYears(-20),
//                 UserName = "anton@test.com",
//                 Email = "anton@test.com"
//             };
//             
//             var user3 = new User
//             {
//                 FirstName = "Аня",
//                 LastName = "Петрова",
//                 MiddleName = "Петровна",
//                 BirthDate = DateTime.UtcNow.AddYears(-30),
//                 UserName = "anya@test.com",
//                 Email = "anya@test.com"
//             };
//             var zavProf = new Profession()
//             {
//                 Name = "Заведующий хозяйством"
//             };
//             var employee3 = new Employee()
//             {
//                 EmploymentDate = DateTime.Now.AddYears(-4),
//                 User = user3,
//                 Profession = zavProf,
//                 Campuses = new HashSet<Campus>(){campus1}
//             };
//             
//             
//             var user4 = new User
//             {
//                 FirstName = "Станислав",
//                 LastName = "Антонов",
//                 MiddleName = "Григорьевич",
//                 BirthDate = DateTime.UtcNow.AddYears(-20),
//                 UserName = "stanislav@test.com",
//                 Email = "stanislav@test.com"
//             };
//             var monterProf = new Profession()
//             {
//                 Name = "Электромонтер"
//             };
//             var employee4 = new Employee()
//             {
//                 EmploymentDate = DateTime.Now.AddYears(-4),
//                 User = user4,
//                 Profession = monterProf,
//                 Campuses = new HashSet<Campus>(){campus1}
//             };
//             
//             await userManager.CreateAsync(user1, password);
//             await userManager.CreateAsync(user2, password);
//             await userManager.CreateAsync(user3, password);
//             await userManager.CreateAsync(user4, password);
//
//             await context.Employees.AddRangeAsync(employee1, employee3, employee4);
//             await context.Professions.AddRangeAsync(zavProf, monterProf, commendProf);
//             
//             #region Add Roles (Admin, commandant, supply manager, fixer)
//         
//             var commandant = await userManager.FindByEmailAsync("petya@test.com");
//             await userManager.AddToRoleAsync(commandant, "Commandant");
//             var admin = await userManager.FindByEmailAsync("anton@test.com");
//             await userManager.AddToRoleAsync(admin, "Admin");
//             var supplyManager = await userManager.FindByEmailAsync("anya@test.com");
//             await userManager.AddToRoleAsync(supplyManager, "Supply manager");
//             var fixer = await userManager.FindByEmailAsync("stanislav@test.com");
//             await userManager.AddToRoleAsync(fixer, "Fixer");
//         
//             #endregion
//         }
//         
//         var bob = new User
//         {
//             FirstName = "Bob",
//             LastName = "Bobov",
//             MiddleName = "Bobovich",
//             BirthDate = DateTime.UtcNow.AddYears(-40),
//             UserName = "bob",
//             Email = "bob@test.com"
//         };
//         var jane = new User
//         {
//             FirstName = "Jane",
//             LastName = "Janov",
//             MiddleName = "Janovich",
//             BirthDate = DateTime.UtcNow.AddYears(-40),
//             UserName = "jane",
//             Email = "jane@test.com"
//         };
//         if (!context.Users.Any())
//         {
//             await userManager.CreateAsync(bob, password);
//             var dutyOfficer = await userManager.FindByEmailAsync("petya@test.com");
//             await userManager.AddToRoleAsync(dutyOfficer, "Duty officer");
//             await userManager.CreateAsync(jane, password);
//         }
//         
//         var zavhoz = new Profession()
//         {
//             Name = "Заведующий общежитием"
//         };
//         if (!context.Professions.Any()) await context.Professions.AddAsync(zavhoz);
//
//         var roomState = new RoomState()
//         {
//             State = 6,
//             Remarks = "Очень старые столы, под замену"
//         };
//         if (!context.RoomStates.Any()) await context.RoomStates.AddAsync(roomState);
//
//         var thing = new Thing()
//         {
//             Name = "taburetka"
//         };
//         if (!context.Things.Any()) await context.Things.AddAsync(thing);
//
//         var room = new Room()
//         {
//             RepairDate = DateTime.UtcNow.AddYears(-6),
//             RoomRating = 7,
//             RoomState = roomState
//         };
//         if (!context.Rooms.Any()) await context.Rooms.AddAsync(room);
//
//         var roomThing = new RoomThing()
//         {
//             Room = room,
//             Thing = thing,
//             Count = 4
//         };
//         if (!context.RoomThings.Any()) await context.RoomThings.AddAsync(roomThing);
//
//         var employee = new Employee()
//         {
//             User = bob,
//             EmploymentDate = DateTime.UtcNow.AddYears(-3),
//             Professions = 
//             Campuses = new HashSet<Campus>(){campus1}
//         };
//         if (!context.Employees.Any()) await context.Employees.AddAsync(employee);
//         
//         var resident = new Resident()
//         {
//             User = jane,
//             GraduationDate = DateTime.UtcNow.AddYears(2),
//             RoomName = "1610 б",
//             Campus = campus1,
//             Room = room
//         };
//         if (!context.Residents.Any()) await context.Residents.AddAsync(resident);
//
//         var violation = new Violation()
//         {
//             Description = "Шумели ночью в 2:00",
//             IncidentDateTime = DateTime.UtcNow,
//             IsSpent = false,
//             Resident = resident,
//             Employee = employee
//         };
//         if (!context.Violations.Any()) await context.Violations.AddAsync(violation);
//         
//         var news = new News()
//         {
//             Content = "<h1 style=\"color: #5e9ca0;\">You can edit <span style=\"color: #2b2301;\">this demo</span> text!</h1> <h2 style=\"color: #2e6c80;\">How to use the editor:</h2> <p>Paste your documents in the visual editor on the left or your HTML code in the source&nbsp;</p> <p>Click the <span style=\"background-color: #2b2301; color: #fff; display: inline-block; padding: 3px 10px; font-weight: bold; border-radius: 5px;\">Clean</span> button to clean your source code.</p> <h2 style=\"color: #2e6c80;\">Some useful features:</h2> <ol style=\"list-style: none; font-size: 14px; line-height: 32px; font-weight: bold;\"> <li style=\"clear: both;\"><img style=\"float: left;\" src=\"https://html-online.com/img/01-interactive-connection.png\" alt=\"interactive connection\" width=\"45\" /> Interactive source editor</li> </ol> <h2 style=\"color: #2e6c80;\">Cleaning options:</h2> <table class=\"editorDemoTable\" style=\"width: 519px;\"> <tbody> <tr> <td style=\"width: 229.531px;\">Remove all tags</td> <td style=\"width: 273.469px;\">This leaves <strong style=\"color: blue;\">only the plain</strong> <em>text</em>. <img style=\"margin: 1px;\" src=\"images/smiley.png\" alt=\"laughing\" width=\"16\" height=\"16\" /></td> </tr> <tr> <td style=\"width: 229.531px;\">Remove successive &amp;nbsp;s</td> <td style=\"width: 273.469px;\">Never use non-breaking spaces&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;to set margins.</td> </tr> </tbody> </table> <p>&nbsp;</p> <p><strong>Save this link into your bookmarks and share it with your friends. It is all FREE! </strong><br /><strong>Enjoy!</strong></p> <p><strong>&nbsp;</strong></p>",
//             CreateDate = DateTime.UtcNow,
//             User = bob,
//             Title = "Test new"
//         };
//         if (!context.News.Any()) await context.News.AddAsync(news);
//
//         await context.SaveChangesAsync();
//     }
// }