using MediatR;

namespace Bigon.Application.Modules.CategoriesModule.Commands.CategoryRemoveCommand
{
    public class CategoryRemoveRequest : IRequest
    {
        public int Id { get; set; }
    }
}
