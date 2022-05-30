﻿using AmirImamTask.DataServices;
using AmirImamTask.Entities;
using AmirImamTask.Entities.Helpers;
using EdenPlugins.ApiCoreConfiguration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StringEncryption;

namespace AmirImamTask.BusinessServices;

public class PersonService : ServiceBase<Person>, IPersonService
{
    private readonly UserManager<IdentityUser> userManager;
    private readonly IdentityUserHelper userHelper;

    public PersonService(ApplicationDbContext context,
        UserManager<IdentityUser> userManager,
        IdentityUserHelper userHelper) : base(context)
    {
        this.userManager = userManager;
        this.userHelper = userHelper;
    }

    public override async Task<ResponseResult<Person>> CreateAsync(Person entity)
    {
        var anyPersonByPhone = Set.Any(it => it.PhoneNumber == entity.PhoneNumber);
        if (anyPersonByPhone == true)
        {
            return ResponseResult<Person>.Error("DuplicatePhoneNumber", "DuplicatePhoneNumber");
        }
        var userResult = await userHelper.RegisterAsync(entity.Email, entity.PhoneNumber, entity.Locker);
        if (userResult.Result.Succeeded == false)
        {
            return ResponseResult<Person>.Error(userResult.Result.Errors);
        }

        entity.IdentityUserId = userResult.User.Id;
        entity.Locker = entity.Locker.Encrypt(userResult.User.Id);
        var result = await base.CreateAsync(entity);
        if (result.Success == true)
        {
            //result.Model.ConfirmationCode = new Random().Next(1111, 9999).ToString();
            //EmailModel emailModel = new()
            //{
            //    Subject = "Projitor| Email Confirmation",
            //    To = new string[] { userResult.User.Email },
            //    Body = $"Your confirmation code is {result.Model.ConfirmationCode}"
            //    //Body = $"<a href='{"https://"}{"localhost:7078/confirm-email"}'>Click here to confirm your email</a>"
            //};
            //await emailsManager.SendAsync(emailModel);
        }
        return result;
    }


    public async Task<ResponseResult<Person>> LoginAsync(LoginModel model)
    {
        //Combined configurations for Asp.Net Core API and Sql Server in NuGet package created by me 
        //https://www.nuget.org/packages/EdenPlugins.ApiCoreConfiguration/1.0.4
        var result = await userHelper.LoginAsync(model.Email, model.Password, model.Token);
        if (result.Result.Succeeded == false)
        {
            return ResponseResult<Person>.Error(result.Result.Errors);
        }
        //if (result.User.EmailConfirmed == false)
        //{
        //    return ResponseResult<Person>.Error("Email", "EmailNotConfirmed");
        //}

        Person? member = await base.Set.Where(it => it.IdentityUserId == result.User.Id).FirstOrDefaultAsync();
        if (member == null)
        {
            return ResponseResult<Person>.Error("Person", "NotFound");
        }

        member.AccessToken = result.Token;
        return ResponseResult<Person>.Ok(member);
    }
}
