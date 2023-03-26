using MediatR;

namespace App.Library.Core.Commands
{
    public class CommandBase : IRequest<Unit>
    {
    }

    public class CommandBase<T> : IRequest<Unit>
    {
        public T Response { get; set; }

        public void SetResponse(T response)
        {
            Response = response;
        }

    }
}
