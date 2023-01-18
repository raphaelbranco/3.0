using Base30.Core.Base.Controller;
using Base30.Core.Communication.Mediator;
using Base30.Core.DomainObjects;
using Base30.Authentication.Application.Commands.AspNetUsers.Commands;
using Base30.Authentication.Application.Queries.AspNetUsers;
using Microsoft.AspNetCore.Mvc;
using Authentication.Application.Commands.Users.Command;

namespace Base30.SysAdmin.Application.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediatoRHandler _mediatoRHandler;
        private readonly ICoreController _coreController;
        private readonly IAspNetUsersQueries _aspnetusersQueries;
        

        public UsersController(IMediatoRHandler mediatoRHandler,
                              ICoreController coreController,
                              IAspNetUsersQueries aspnetusersQueries)
        {
            _mediatoRHandler = mediatoRHandler;
            _coreController = coreController;
            _aspnetusersQueries = aspnetusersQueries;
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


        [HttpGet]
        public IActionResult LoadById(Guid id)
        {
            AspNetUsersDto? aspnetusersDto = _aspnetusersQueries.LoadByIdNoSql(id);

            Validation.ValidateIfNull(aspnetusersDto, "Registro não encontrado");

            return Ok(aspnetusersDto);
        }

        [HttpPost("/Login")]
        public async Task<IActionResult> Login(string email = "teste@14.com", string password = "12345S#s1")
        {
            LoginCommand command = new LoginCommand(email, password);
            await _mediatoRHandler.SendCommand(command);


            if (_coreController.OperationIsValid()) return Ok();

            var notification = _coreController.GetErrorMessage();
            return Ok(notification);
        }

        [HttpPost("/LogOut")]
        public async Task<IActionResult> LogOut(string email = "teste@14.com")
        {
            LogOutCommand command = new LogOutCommand(email);
            await _mediatoRHandler.SendCommand(command);

            if (_coreController.OperationIsValid()) return Ok();

            var notification = _coreController.GetErrorMessage();
            return Ok(notification);
        }


    }

}
