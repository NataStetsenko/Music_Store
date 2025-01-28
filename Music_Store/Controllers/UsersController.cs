using Microsoft.AspNetCore.Mvc;
using Music_Store.BLL.DTO;
using Music_Store.BLL.Interfaces;
using Music_Store.Models;
using Music_Store.BLL.Services;

namespace Music_Store.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userServis;
        private readonly IRepositoryMiddle<UserDTO> repositoryMiddle;
        public UsersController(IUserService userServis, IRepositoryMiddle<UserDTO> repositoryMiddle)
        {
            this.userServis = userServis;
            this.repositoryMiddle = repositoryMiddle;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreate userView)
        {
            if (ModelState.IsValid)
            {
                if (repositoryMiddle.Check(userView.Login) && userServis.CheckEmail(Mail: userView.Mail))
                {
                    HttpContext.Session.SetString("login", userView.Login); // создание сессионной переменной
                    UserDTO userDTO = new()
                    {
                        Name = userView.Name,
                        Surname = userView.Surname,
                        Login = userView.Login,
                        Password = userView.Password,
                        Mail = userView.Mail,
                        UserLevel = 0
                    };
                    HttpContext.Session.SetString("Level", userDTO.UserLevel.ToString());
                    if (userView.Login == "admin")
                    {
                        userDTO.UserLevel = 2;
                    }
                    await repositoryMiddle.Create(userDTO);
                    return Redirect("/Musics/Index2");
                }
                else
                {
                    if (userView.Login == "admin")
                        ModelState.AddModelError("Login", "admin - запрещенное имя");
                    else
                        ModelState.AddModelError("Login", "Такой логин уже есть");
                    return View(userView);
                }
            }
            return View(userView);
        }
        public async Task<IActionResult> AllUsers()
        {
            var model = await repositoryMiddle.GetAll();
            return View(model);
        }
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await repositoryMiddle.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUserConfirmed(int id)
        {
            await repositoryMiddle.Delete(id);
            return RedirectToAction(nameof(AllUsers));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var user = await repositoryMiddle.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserDTO user)
        {
            if (user.UserLevel < 0 || user.UserLevel > 1)
            {
                HttpContext.Session.SetString("Level", user.UserLevel.ToString());
                ModelState.AddModelError("UserLevel", "Не может быть больше 1");
                return View(user);
            }
            if (ModelState.IsValid)
            {
                await repositoryMiddle.Update(user);
                return RedirectToAction(nameof(AllUsers));
            }
            return View(user);
        }
        private bool UserExists(int id)
        {
            return repositoryMiddle.Get(id) != null;
        }
        public IActionResult Sing()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Sing([Bind("Login,Password")] UserSing user)
        {
            if (user.Login != null && user.Password != null)
            {
                if (userServis.CheckLogin2(Login: user.Login))
                {
                    var usr = await repositoryMiddle.Get(name: user.Login);
                    ISoltServic temp = new SoltServic();
                    if (temp.PasswordCheck(user.Password, usr.Password, usr.PassSalt))
                    {
                        HttpContext.Session.SetString("login", user.Login); // создание сессионной переменной
                        HttpContext.Session.SetString("Level", usr.UserLevel.ToString());
                        return Redirect("/Musics/Index2");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Не корректный пароль");
                        return View(user);
                    }
                }
                else
                {
                    ModelState.AddModelError("Login", "Логин не заригестрирован 2");
                    return View(user);
                }
            }
            else
            {
                ModelState.AddModelError("Password", "Необходимо заполнить");
                ModelState.AddModelError("Login", "Необходимо заполнить");
                return View(user);
            }
        }

        public IActionResult CheckLogin(string Login)
        {
            return Json(repositoryMiddle.Check(Login));
        }
        public IActionResult CheckLogin2(string Login)
        {
            return Json(userServis.CheckLogin2(Login));
        }
        public IActionResult CheckEmail(string Mail)
        {
            return Json(userServis.CheckEmail(Mail));
        }
    }
}


