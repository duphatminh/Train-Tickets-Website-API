using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainTicketsWebsite.Data;
using TrainTicketsWebsite.Models;
using TrainTicketsWebsite.Utilities;

namespace TrainTicketsWebsite.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : Controller
{
    private readonly DataContext _context;
    
    public AuthController(DataContext context)
    {
        _context = context;
    }
    
    //Đăng ký tài khoản
    [HttpPost("register")]
    public async Task<IActionResult> Register(LoginUser loginUser)
    {
        bool isEmail = ValidationHelper.IsEmail(loginUser.userNameOrEmail);
        
        if (ModelState.IsValid)
        {
            if (await _context.Users.AnyAsync(u => (isEmail && u.email == loginUser.userNameOrEmail) || (!isEmail && u.userName == loginUser.userNameOrEmail)))
            {
                return BadRequest("Username hoặc Email đã tồn tại");
            }
            
            var user = new Users
            {
                userName = isEmail ? null : loginUser.userNameOrEmail,
                email = isEmail ? loginUser.userNameOrEmail : null,
                password = loginUser.password,
                role = "customer"
            };
            
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok("Đăng ký thành công");

        }
        return BadRequest("Dữ liệu không hợp lệ");
    }
    
    // Đăng nhập tài khoản
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUser loginUser)
    {
        if (ModelState.IsValid)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => 
                (u.userName == loginUser.userNameOrEmail || u.email == loginUser.userNameOrEmail) && 
                u.password == loginUser.password) ;
            if (user == null)
            {
                return BadRequest("Tài khoản không tồn tại");
            }

            if (user.password != loginUser.password)
            {
                return BadRequest("Mật khẩu không đúng");
            }

            return Ok("Đăng nhập thành công");
        }
        return BadRequest("Dữ liệu không hợp lệ");
    }
}