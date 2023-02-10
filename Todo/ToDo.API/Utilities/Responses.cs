using ToDo.API.ViewModels;

namespace ToDo.API.Utilities;

public static class Responses
{
    public static ResultViewModels ApplicartionErrorMensage()
    {
        return new ResultViewModels
        {
            Message = "Ocorreu algum error interno na aplicação, por favor tente novamente",
            Success = false,
            Data = null
        };
    }

    public static ResultViewModels DomainErrorMenssage(string message)
    {
        return new ResultViewModels
        {
            Message = message,
            Success = false,
            Data = null
        };
    }

    public static ResultViewModels DomainErrorMessage(string message, IReadOnlyCollection<string> errors)
    {
        return new ResultViewModels
        {
            Message = message,
            Success = false,
            Data = errors
        };
    }

    public static ResultViewModels UnauthorizedErrorMessage()
    {
        return new ResultViewModels
        {
            Message = "A combinação de login e senha está incorreta!",
            Success = false,
            Data = null
        };
    }
}