using Microsoft.AspNetCore.Mvc;
using SecretSanta.Web.Data;
using SecretSanta.Web.ViewModels;
using System;
using SecretSanta.Web.Api;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SecretSanta.Web.Controllers
{
    public class UsersController : Controller
    {
        public IUsersClient Client { get; }

        public UsersController(IUsersClient client)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IActionResult> Index()
        {
            ICollection<UpdateUser> users = await Client.GetAllAsync();
            List<UserViewModel> viewModelUsers = new();
            int counter = 0;
            foreach(UpdateUser user in users)
            {
                viewModelUsers.Add(new UserViewModel
                {
                    Id = counter,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                });
                counter++;
            }
            return View(viewModelUsers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await Client.PostAsync(new UpdateUser {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName
                });
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            UpdateUser updateUser = await Client.GetAsync(id);
            UserViewModel userViewModel = new(){
                FirstName = updateUser.FirstName,
                LastName = updateUser.LastName,
                Id = id
            };
            return View(userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                //MockData.Users[MockData.Users.IndexOf(MockData.Users.Find(user => user.Id == viewModel.Id))] = viewModel;

                await Client.PutAsync(viewModel.Id, new UpdateUser{
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName
                });
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await Client.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
