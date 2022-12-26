using Base30.Core.Base.Controller;
using Base30.Core.Communication.Mediator;
using Base30.Core.DomainObjects;
using Base30.SysAdmin.Application.Commands.Search.Commands;
using Base30.SysAdmin.Application.Queries.Search;
using Microsoft.AspNetCore.Mvc;
namespace Base30.SysAdmin.Application.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IMediatoRHandler _mediatoRHandler;
        private readonly ICoreController _coreController;
        private readonly ISearchQueries _searchQueries;

        public SearchController(IMediatoRHandler mediatoRHandler,
                              ICoreController coreController,
                              ISearchQueries searchQueries)
        {
            _mediatoRHandler = mediatoRHandler;
            _coreController = coreController;
            _searchQueries = searchQueries;
        }
        [HttpPost]
        public async Task<IActionResult> Create(bool active, string name, string description)
        {
            SearchCreateCommand command = new SearchCreateCommand(DateTime.Now, DateTime.Now, Guid.NewGuid(), Guid.NewGuid(), active, name, description);
            await _mediatoRHandler.SendCommand(command);


            if (_coreController.OperationIsValid()) return Ok();

            var notification = _coreController.GetErrorMessage();
            return Ok(notification);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Guid id, bool active, string name, string description)
        {
            SearchUpdateCommand command = new SearchUpdateCommand(id, DateTime.Now, DateTime.Now, Guid.NewGuid(), Guid.NewGuid(), active, name, description);
            await _mediatoRHandler.SendCommand(command);


            if (_coreController.OperationIsValid()) return Ok();

            var notification = _coreController.GetErrorMessage();
            return Ok(notification);
        }

        [HttpGet("/SearchGetAll")]
        public IActionResult SearchGetAll()
        {
            IEnumerable<SearchDto?> searchDto = _searchQueries.GetAllNoSql().Result;

            Validation.ValidateIfNull(searchDto, "Nenhum Search cadastrado");

            return Ok(searchDto);
        }
        [HttpGet]
        public IActionResult LoadById(Guid id)
        {
            SearchDto? searchDto = _searchQueries.LoadByIdNoSql(id);

            Validation.ValidateIfNull(searchDto, "Registro não encontrado");

            return Ok(searchDto);
        }
    }
}

