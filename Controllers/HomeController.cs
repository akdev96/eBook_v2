using Ebook8.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static NuGet.Packaging.PackagingConstants;
using static System.Reflection.Metadata.BlobBuilder;

namespace Ebook8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private object _context;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                // Hardcoded username and password for demonstration
                string hardcodedUsername = "mohomednawer@gmail.com";
                string hardcodedPassword = "nawer1234";

                // Validate credentials
                if (model.Username == hardcodedUsername && model.Password == hardcodedPassword)
                {
                    // Redirect to Main Menu upon successful login
                    return RedirectToAction("MainMenu");
                }

                // Add a model error if authentication fails
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
            }

            // Return the same view if login fails
            return View(model);
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                // Save user to the database
                var Register = new Register
                {
                    Name = model.Name,
                    Email = model.Email,
                    Phone = model.Phone,
                    Address = model.Address // Note: Use hashing in production!
                };

                // Redirect to login or another page
                return RedirectToAction("Login");
            }

            return View(model);
        }

        public IActionResult Index()
        {
            // Sample product list
            var Books = new List<Book1>
            {
                new Book1 { Id = 1, Name = "Harry potter", Description = "Fantasy", Price = 19.99M, ImageUrl = "/Images/harry_potter.jpeg" },
                new Book1 { Id = 2, Name = "Diary of A Wimpy Kid", Description = "Comedy", Price = 19.99M, ImageUrl = "/images/diary_of_wimpy_kid.jpeg" },
                new Book1 { Id = 3, Name = "Matilda", Description = "Mystry", Price = 19.99M, ImageUrl = "/Images/sherlock_holmes.jpeg" },
                new Book1 { Id = 3, Name = "To Kill a Mokingbird", Description = "Mystry", Price = 19.99M, ImageUrl = "/Images/to_kill_a_mocking_bird.jpeg" },
                new Book1 { Id = 4, Name = "Scooby Doo", Description = "Mystry", Price = 19.99M, ImageUrl = "/Images/scooby_doo.jpeg" },
                new Book1 { Id = 5, Name = "Sherlock Homes", Description = "Mystry", Price = 19.99M, ImageUrl = "/Images/sherlock_holmes.jpeg" },
            };

            return View(Books);
        }
        public IActionResult MainMenu()
        {
            // Sample products
            var Mainmenu = new List<Book1>
    {
        new Book1 { Id = 1, Name = "Titanic", Description = "Romantic", Price = 19.99M, ImageUrl = "/images/book1.jpg" },
        new Book1 { Id = 2, Name = "Money Heist", Description = "Crime", Price = 24.99M, ImageUrl = "/images/book2.jpg" },
        new Book1 { Id = 3, Name = "House of Dragon", Description = "Thriller", Price = 14.99M, ImageUrl = "/images/book3.jpg" },
        new Book1 { Id = 4, Name = "Harry potter", Description = "Fantasy", Price = 19.99M, ImageUrl = "All_the_NewBookstoReadThisNovember,FromSci-FiNovelstoMemoirs.jpeg" },
        new Book1 { Id = 5, Name = "Diary of A Wimpy Kid", Description = "Comedy", Price = 19.99M, ImageUrl = "/images/product1.jpeg" },
        new Book1 { Id = 6, Name = "Matilda", Description = "Mystry", Price = 19.99M, ImageUrl = "All the New Books to Read This November, From Sci-Fi Novels to Memoirs.jpeg" },
        new Book1 { Id = 7, Name = "To Kill a Mokingbird", Description = "Mystry", Price = 19.99M, ImageUrl = "To Kill a Mockingbird.jpeg" },
        new Book1 { Id = 8, Name = "Scooby Doo", Description = "Mystry", Price = 19.99M, ImageUrl = "The Sherlock Holmes Book Magazine (Digital).jpeg" },
        new Book1 { Id = 9, Name = "Sherlock Homes", Description = "Mystry", Price = 19.99M, ImageUrl = "The Sherlock Holmes Book Magazine (Digital).jpeg" },

    };

            return View(Mainmenu);
        }
       
        public IActionResult orderconfirmation()
        {
            return View();
        }
        public IActionResult adminmn()
        {
            return View();
        }

        public IActionResult adminsupermn()
        {
            return View();
        }

        public IActionResult superadmin(superadmin model)
        {
            if (ModelState.IsValid)
            {
                // Hardcoded credentials for the superadmin
                string username = "superadmin";
                string password = "admin1234";

                // Validate credentials
                if (model.susername == username && model.spassword == password)
                {
                    // Redirect to adminmn page upon successful login
                    return RedirectToAction("adminsupermn");
                }
                else
                {
                    // Add error message for invalid login
                    ModelState.AddModelError(string.Empty, "Invalid username or password.");
                }
            }

            // Return the same view if login fails
            return View(model);
        }




        public IActionResult AddToCart(int productId)
        {
            // Logic to add product to cart
            TempData["Message"] = $"Product with ID {productId} added to cart!";
            return RedirectToAction("Index", "Home");
        }
        public IActionResult thankyou()
        {
            // You could add logic here to save the order details, clear the cart, etc.

            // Redirect to the thank you page
            return View();


        }
        public IActionResult admin(admin model)
        {
            if (ModelState.IsValid)
            {
                // Single hardcoded admin username and password for demonstration
                string username = "admin1";
                string password = "admin1234";

                // Validate credentials
                if (model.username == username && model.password == password)
                {
                    // Redirect based on some condition (you can customize this condition)
                    if (model.username == "admin1")
                    {
                        return RedirectToAction("adminmn"); // Example: Redirect to adminmn
                    }
                }
                else
                {
                    // Invalid login
                    ModelState.AddModelError(string.Empty, "Invalid username or password.");
                }
            }

            // Return the same view if login fails
            return View(model);
        
    

    }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
