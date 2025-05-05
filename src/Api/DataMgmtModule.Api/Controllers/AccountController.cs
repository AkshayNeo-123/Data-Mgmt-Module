using System.Data;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Application.Models.Authentication;
using DataMgmtModule.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DataMgmtModule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IAuth _auth;

        public AccountController(IAuth auth)
        {
            _auth = auth;
        }
        // comment added

        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        //{
        //    if (loginRequest == null || string.IsNullOrEmpty(loginRequest.UserName) || string.IsNullOrEmpty(loginRequest.Password))
        //    {
        //        return BadRequest("Invalid client request");
        //    }

        //    using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DbConnectionString")))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("CheckUserLogin", conn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@Username", loginRequest.UserName);
        //            cmd.Parameters.AddWithValue("@Password", loginRequest.Password);

        //            await conn.OpenAsync();
        //            int result = (int)await cmd.ExecuteScalarAsync();

        //            if (result > 0)
        //            {
        //                return Ok("Login successful");
        //            }
        //            else
        //            {
        //                return Unauthorized("Invalid Username or Credentials");
        //            }
        //        }
        //    }
        //}

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var result =await _auth.Login(loginRequest);
            HttpContext.Session.SetInt32("UserId", result.UserId);
            return Ok(result);
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> logout()
        {
            HttpContext.Session.Clear();
            return Ok(new { message = "LogOut Successfully" });
        }
    }
}
