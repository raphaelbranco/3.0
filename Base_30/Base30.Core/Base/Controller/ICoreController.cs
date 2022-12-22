
namespace Base30.Core.Base.Controller
{
    public interface ICoreController : IDisposable
    {
        bool OperationIsValid();

        IEnumerable<string> GetErrorMessage();

        void NotifyError(string codigo, string mensagem);
    }
}
