﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainTicketsWebsite.Data;
using TrainTicketsWebsite.Models;
using TrainTicketsWebsite.Utilities;

namespace TrainTicketsWebsite.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthUsersController : Controller
{
    private readonly DataContext _context;
    
    public AuthUsersController(DataContext context)
    {
        _context = context;
    }
    
    //Đăng ký tài khoản
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUser registerUser)
    {
        if (ModelState.IsValid)
        {
            if (await _context.UsersInfo.AnyAsync(u => (u.userName == registerUser.userName || u.email == registerUser.email)))
            {
                return BadRequest("Username or email already exists");
            }
            
            var user = new Users
            {
                userName = registerUser.userName,
                email = registerUser.email,
                password = registerUser.password,
                role = "customer"
            };
            
            await _context.UsersInfo.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok("Sign Up Success");
        }
        return BadRequest("Invalid data");
    }
    
    // Đăng nhập tài khoản
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUser loginUser)
    {
        if (ModelState.IsValid)
        {
            var user = await _context.UsersInfo.FirstOrDefaultAsync(u => 
                (u.userName == loginUser.userNameOrEmail || u.email == loginUser.userNameOrEmail));
            if (user == null)
            {
                return BadRequest("Account does not exist");
            }
            
            if (user.password != loginUser.password)
            {
                return BadRequest("Incorrect password");
            }
            
            return Ok("Logged in successfully");
        }
        return BadRequest("Invalid data");
    }
}