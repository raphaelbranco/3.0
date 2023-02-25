using Base30.Core.Base.Controller;
using Base30.Core.Communication.Mediator;
using Base30.Core.DomainObjects;
using Base30.SysAdmin.Application.Commands.Menu.Commands;
using Base30.SysAdmin.Application.Queries.Menu;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace Base30.SysAdmin.Application.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MenuController: ControllerBase
    {
        private readonly IMediatoRHandler _mediatoRHandler;
        private readonly ICoreController _coreController;
        private readonly IMenuQueries _menuQueries;


        public MenuController(IMediatoRHandler mediatoRHandler,
                              ICoreController coreController,
                              IMenuQueries menuQueries)
        {
            _mediatoRHandler = mediatoRHandler;
            _coreController = coreController;
            _menuQueries = menuQueries;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<MenuDto?> menuDto = _menuQueries.GetAll().Result;

            Validation.ValidateIfNull(menuDto, "Nenhum menu cadastrado");

            return Ok(menuDto);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(MenuDto menuCreate)
        {
            MenuCreateCommand command = new MenuCreateCommand(new Guid(), new Guid(), menuCreate.name, menuCreate.name, null, menuCreate.order);
            await _mediatoRHandler.SendCommand(command);

            if (_coreController.OperationIsValid()) return Ok();
            
            var notification = _coreController.GetErrorMessage();                
            return Ok(notification);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(Guid id, string nome, int order)
        {
            MenuUpdateCommand command = new MenuUpdateCommand(id, new Guid(), nome, nome, null, order);
            await _mediatoRHandler.SendCommand(command);

            if (_coreController.OperationIsValid()) return Ok();
            
            var notification = _coreController.GetErrorMessage();
            return Ok(notification);
        }

    }
}
