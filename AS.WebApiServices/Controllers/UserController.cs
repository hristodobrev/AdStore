﻿using AS.ApplicationServices.RequestModels.User;
using AS.Data.Context;
using AS.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AS.WebApiServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AdStoreDbContext _dbContext;
        public UserController(AdStoreDbContext context)
        {
            _dbContext = context;
        }

        [HttpPost]
        public IActionResult Create(CreateUserRequestModel model)
        {
            this._dbContext.Users.Add(new User
            {
                Username = model.Username,
                Password = model.Password,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                Town = model.Town,
                IsPremium = model.IsPremium
            });

            this._dbContext.SaveChanges();

            return Ok();
        }
    }
}
