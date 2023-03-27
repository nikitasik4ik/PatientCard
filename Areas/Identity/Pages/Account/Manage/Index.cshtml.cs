// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PatientCard.Areas.Identity.Data;

namespace PatientCard.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Display(Name = "Имя")]
            public string FirstName { get; set; }
            [Display(Name = "Фамилия")]
            public string LastName { get; set; }
            [Display(Name = "Username")]
            public string Username { get; set; }
            [Phone]
            [Display(Name = "Номер телефона")]

            public string Phone { get; set; }
            [Display(Name = "Отчество")]
            public string? Patronymic { get; set; }
            [Display(Name = "Пол")]
            public string? GenderName { get; set; }
            [Display(Name = "Дата рождения")]
            public DateTime? DataBirth { get; set; }
            [Display(Name = "Паспортные данные")]
            public int? PassportSeries { get; set; }
            [Display(Name = "Адрес регистрации")]
            public string? AdressReg { get; set; }
            [Display(Name = "Адрес проживания")]
            public string? AdressRes { get; set; }

            [Display(Name = "СНИЛС")]
            public int? Snils { get; set; }
            [Display(Name = "Полис")]
            public int? Polisy { get; set; }
            [Display(Name = "Место работы")]
            public string? PlaceWork { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Input = new InputModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = userName,
                Phone = phoneNumber,
                Patronymic = user.Patronymic,
                GenderName = user.GenderName,
                DataBirth = user.DataBirth,
                PassportSeries = user.PassportSeries,
                AdressReg = user.AdressReg,
                AdressRes = user.AdressRes,
                Snils = user.Snils,
                Polisy = user.Polisy,
                PlaceWork = user.PlaceWork
            };
        }


        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    var firstName = user.FirstName;
        //    var lastName = user.LastName;
        //    if (Input.FirstName != firstName)
        //    {
        //        user.FirstName = Input.FirstName;
        //        await _userManager.UpdateAsync(user);
        //    }
        //    if (Input.LastName != lastName)
        //    {
        //        user.LastName = Input.LastName;
        //        await _userManager.UpdateAsync(user);
        //    }
        //    if (user == null)
        //    {
        //        return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        await LoadAsync(user);
        //        return Page();
        //    }

        //    var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
        //    if (Input.Phone != phoneNumber)
        //    {
        //        var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.Phone);
        //        if (!setPhoneResult.Succeeded)
        //        {
        //            StatusMessage = "Unexpected error when trying to set phone number.";
        //            return RedirectToPage();
        //        }
        //    }

        //    await _signInManager.RefreshSignInAsync(user);
        //    StatusMessage = "Your profile has been updated";
        //    return RedirectToPage();
        //}
        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (Input.FirstName != user.FirstName)
            {
                user.FirstName = Input.FirstName;
                await _userManager.UpdateAsync(user);
            }
            if (Input.LastName != user.LastName)
            {
                user.LastName = Input.LastName;
                await _userManager.UpdateAsync(user);
            }
            if (Input.Patronymic != user.Patronymic)
            {
                user.Patronymic = Input.Patronymic;
                await _userManager.UpdateAsync(user);
            }
            if (Input.GenderName != user.GenderName)
            {
                user.GenderName = Input.GenderName;
                await _userManager.UpdateAsync(user);
            }
            if (Input.DataBirth != user.DataBirth)
            {
                user.DataBirth = Input.DataBirth;
                await _userManager.UpdateAsync(user);
            }
            if (Input.PassportSeries != user.PassportSeries)
            {
                user.PassportSeries = Input.PassportSeries;
                await _userManager.UpdateAsync(user);
            }
            if (Input.AdressReg != user.AdressReg)
            {
                user.AdressReg = Input.AdressReg;
                await _userManager.UpdateAsync(user);
            }
            if (Input.AdressRes != user.AdressRes)
            {
                user.AdressRes = Input.AdressRes;
                await _userManager.UpdateAsync(user);
            }
            if (Input.Snils != user.Snils)
            {
                user.Snils = Input.Snils;
                await _userManager.UpdateAsync(user);
            }
            if (Input.Polisy != user.Polisy)
            {
                user.Polisy = Input.Polisy;
                await _userManager.UpdateAsync(user);
            }
            if (Input.PlaceWork != user.PlaceWork)
            {
                user.PlaceWork = Input.PlaceWork;
                await _userManager.UpdateAsync(user);
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.Phone != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.Phone);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Данные успешно сохранены";
            return RedirectToPage();
        }

    }
}
