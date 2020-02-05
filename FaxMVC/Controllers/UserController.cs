using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Services;
using Core;
using Core.Interfaces;
using FaxMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FaxMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SignInManager<User> _signInManager;
        private readonly IMessageUserService _messageUserService;
        public UserController(IUnitOfWork unitOfWork, SignInManager<User> signInManager, IMessageUserService messageUserService)
        {
            _unitOfWork = unitOfWork;
            _signInManager = signInManager;
            _messageUserService = messageUserService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserModel model)
        {
            if (ModelState.IsValid)
            {
                User newUser = new User
                {
                    UserName = model.Username,
                    Email = model.Email
                };

                IdentityResult result = await _unitOfWork.Users.CreateAsync(newUser, model.Password);
                if (result.Succeeded)
                {
                    await _unitOfWork.Users.UpdateAsync(newUser);
                    //Send user a email confirmation token
                    var token = await _unitOfWork.Users.GenerateEmailConfirmationTokenAsync(newUser);
                    var confirmEmailUrl = Url.Action("ConfirmEmail", "User", new { token = token, email = model.Email }, Request.Scheme);
                    var k = _messageUserService.SendMessage(confirmEmailUrl, "Email confirmation Faksistent", model.Email);
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View();
            
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await _unitOfWork.Users.FindByEmailAsync(email);

            if (user != null)
            {
                var result = await _unitOfWork.Users.ConfirmEmailAsync(user, token);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {

            var user = await _unitOfWork.Users.FindByNameAsync(model.Username);

            if (user != null)
            {
                //Check if email is confirmed
                if (!await _unitOfWork.Users.IsEmailConfirmedAsync(user))
                {
                    return View();
                }
                else
                {
                    var signInrResult = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

                    if (signInrResult.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            return View();

        }

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            var user = await _unitOfWork.Users.FindByEmailAsync(model.Email);

            if (user != null)
            {
                var token = await _unitOfWork.Users.GeneratePasswordResetTokenAsync(user);
                var resultUrl = Url.Action("ResetPassword", "User", new ResetPasswordModel { Token = token, Email = model.Email }, Request.Scheme);
                bool messageSent = _messageUserService.SendMessage(resultUrl, "Password recovery for Faksistent", model.Email);

            }

            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {

            return View(new ResetPasswordModel { Token = token, Email = email });
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _unitOfWork.Users.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var result = await _unitOfWork.Users.ResetPasswordAsync(user, model.Token, model.Password);
                }
            }

            return View();
        }

    }
}