using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Todo.Common.Dto;
using Todo.Common.Mappers;
using Todo.Core.Models;
using Todo.Core.Queries;
using Todo.Domain.Models;
using Todo.Domain.UnitOfWork;

namespace Todo.Core.QueryHandlers
{
    public class TodoItemQueryHandler : IRequestHandler<TodoItemQuery, RequestResult<TodoItemDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TodoItemQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RequestResult<TodoItemDto>> Handle(TodoItemQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var todoItem = await _unitOfWork.GetGenericRepository<TodoItem>().CreateAsync(request.Id) ??
                               throw new Exception($"Не найден объект todo по Id = '{request.Id}'");
                return new RequestResult<TodoItemDto>
                {
                    Result = todoItem.MapTodoItemDto()
                };
            }
            catch (Exception ex)
            {
                return new RequestResult<TodoItemDto>
                {
                    Error = true,
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
