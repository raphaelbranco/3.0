using Base30.Core.Base.Controller;
using Base30.Core.Communication.Mediator;
using Base30.Core.DomainObjects;
using Base30.Authentication.Application.Commands.AspNetUsers.Commands;
using Base30.Authentication.Application.Queries.AspNetUsers;
using Microsoft.AspNetCore.Mvc;
using Authentication.Application.Commands.Users.Command;
using Authentication.Application.Queries.User.Services;
using Microsoft.AspNetCore.Authorization;
using Authentication.Application.Dto;

namespace Base30.SysAdmin.Application.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediatoRHandler _mediatoRHandler;
        private readonly ICoreController _coreController;
        private readonly IAspNetUsersQueries _aspnetusersQueries;
        private readonly ITokenService _tokenService;

        public UsersController(IMediatoRHandler mediatoRHandler,
                              ICoreController coreController,
                              IAspNetUsersQueries aspnetusersQueries,
                              ITokenService tokenService)
        {
            _mediatoRHandler = mediatoRHandler;
            _coreController = coreController;
            _aspnetusersQueries = aspnetusersQueries;
            _tokenService = tokenService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(string email = "teste@2.com", string password = "12345S#s1", string phonenumber = "(11)99999-9999")
        {
            string username = email;

            AspNetUsersCreateCommand command = new AspNetUsersCreateCommand(DateTime.Now, DateTime.Now, Guid.NewGuid(), username, email, password, phonenumber);
            await _mediatoRHandler.SendCommand(command);

            if (_coreController.OperationIsValid()) return Ok();

            var notification = _coreController.GetErrorMessage();
            return Ok(notification);
        }

        [Authorize]
        [HttpGet]
        public IActionResult LoadById(Guid id)
        {
            AspNetUsersDto? aspnetusersDto = _aspnetusersQueries.LoadByIdNoSql(id);

            Validation.ValidateIfNull(aspnetusersDto, "Registro não encontrado");

            return Ok(aspnetusersDto);
        }

        [HttpPost("/Login")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            LoginCommand command = new LoginCommand(login.email, login.password);
            await _mediatoRHandler.SendCommand(command);


            if (_coreController.OperationIsValid())
            {
                string token = _tokenService.CreateToken(login.email, "");
                return Ok(token);
            }

            var notification = _coreController.GetErrorMessage();
            return Unauthorized(notification);
        }

        [HttpPost("/LogOut")]
        public async Task<IActionResult> LogOut(LogOutDto logout)
        {
            LogOutCommand command = new LogOutCommand(logout.email);
            await _mediatoRHandler.SendCommand(command);

            if (_coreController.OperationIsValid()) return Ok();

            var notification = _coreController.GetErrorMessage();
            return Ok(notification);
        }


    }


}
