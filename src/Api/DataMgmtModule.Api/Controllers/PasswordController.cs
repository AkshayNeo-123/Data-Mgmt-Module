using DataMgmtModule.Application.Feactures.Users.Commands.ResetPassword;
using DataMgmtModule.Application.Feactures.Users.Commands.SendOtp;
using DataMgmtModule.Application.Feactures.Users.Commands.VerifyOtp;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataMgmtModule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PasswordController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("send-otp")]
        public async Task<IActionResult> SendOtp([FromBody] SendOtpCommand command)
        {
            await _mediator.Send(command);
            return Ok(new { Message = "OTP sent to email." });
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpCommand command)
        {
            var result = await _mediator.Send(command);
            return result
                ? Ok(new { Message = "OTP verified." })
                : BadRequest(new { Message = "Invalid or expired OTP." });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command)
        {
            await _mediator.Send(command);
            return Ok(new { Message = "Password reset successful." });
        }
    }
}
