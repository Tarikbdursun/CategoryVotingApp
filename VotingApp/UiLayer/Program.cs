using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using Entity.Concrete;
using Entity.Dtos;
using System;
using System.Linq;

namespace UiLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            StartMenu();
        }

        static void StartMenu()
        {
            IAuthService authService = new AuthManager(new EfUserDal());
            
        startmenu:
            Console.WriteLine("Press 'R' for Register");
            Console.WriteLine("Press 'L' for Login");
            string input1 = Console.ReadLine();
            input1 = input1.ToUpper();
            switch (input1)
            {
                case "R": Register();
                    break;
                case "L": Login();
                    break;
                default:
                    goto startmenu;
            }

            void Login()
            {
                Console.WriteLine("Username: ");
                string userName = Console.ReadLine();
                Console.WriteLine("Password: ");
                string password = Console.ReadLine();

                
                UserForLoginDto user = new UserForLoginDto() { Username = userName, Password = password };
                var result = authService.Login(user);
                if (!result.Success)
                {
                    Console.WriteLine(result.Message);
                    StartMenu();
                    return;
                }

                VoteMenu();
            }

            void Register()
            {
                Console.WriteLine("Username: ");
                string userName = Console.ReadLine();
                Console.WriteLine("Password: ");
                string password = Console.ReadLine();

                var result = authService.Register(userName, password);
                if (!result.Success)
                {
                    Console.WriteLine(result.Message);
                    StartMenu();
                    return;
                }

                VoteMenu();
            }
        }

        private static void VoteMenu()
        {
            ICategoryService categoryManager = new CategoryManager(new EfCategoryDal());
            IVotingService votingService = new VotingManager(new EfCategoryDal());
            var categoryList = categoryManager.GetAll().Data;
            categoryList.OrderBy(x => x.ID);
            for (int i = 0; i < categoryList.Count; i++)
            {
                var currentCategory = categoryList[i];
                string info = $"{currentCategory.ID}) {currentCategory.CategoryName} (Press [{currentCategory.ID}] for vote it.)";
                Console.WriteLine(info);
            }
            string vote = Console.ReadLine();
            int votedCategoryId;
            if(!CheckVote(vote,categoryManager,out votedCategoryId))
            {
                Console.WriteLine("Please Try Again");
                VoteMenu();
            }
            else
            {
                Category votedCategory = categoryManager.GetCategoryById(votedCategoryId).Data;
                votingService.VoteCategory(votedCategory);
                Console.WriteLine();
                Console.WriteLine(votingService.GetVotesRate());
            }
        }

        private static bool CheckVote(string vote, ICategoryService categoryService, out int categoryId)
        {
            try
            {
                int id = int.Parse(vote);
                if (categoryService.GetCategoryById(id).Data != null)
                {
                    categoryId = id;
                    return true;
                }
            }
            catch (Exception)
            {
                categoryId = 0;
                return false;                
            }

            categoryId = 0;
            return false;
        }
    }
}
