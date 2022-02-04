using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Todo.Common.Dto;
using Todo.Common.Mappers;
using Todo.Core.Commands;
using Todo.Core.Models;
using Todo.Domain.Models;
using Todo.Domain.UnitOfWork;

namespace Todo.Core.CommandHandlers
{
    public class TodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, RequestResult<TodoItemDto>>,
        IRequestHandler<UpdateTodoItemCommand, RequestResult<TodoItemDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TodoItemCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RequestResult<TodoItemDto>> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var todoItem = CreateTodoItemModel(request);

                await _unitOfWork.GetGenericRepository<TodoItem>().CreateAsync(todoItem);
                await _unitOfWork.SaveAsync();

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

        public async Task<RequestResult<TodoItemDto>> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var todoItem = await _unitOfWork.GetGenericRepository<TodoItem>().GetAsync(request.Id) ??
                               throw new Exception($"Не найден объект todo по Id = '{request.Id}'");

                FillTodoItem(todoItem, request);
                _unitOfWork.GetGenericRepository<TodoItem>().Update(todoItem);
                await _unitOfWork.SaveAsync();

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

        private TodoItem CreateTodoItemModel(CreateTodoItemCommand createTodoItemCommand) => new()
        {
            TaskName = createTodoItemCommand.TaskName,
            Commentary = createTodoItemCommand.Commentary,
            IsCompleted = createTodoItemCommand.IsCompleted
        };

        private void FillTodoItem(TodoItem todoItem, UpdateTodoItemCommand todoItemCommand)
        {
            todoItem.IsCompleted = todoItemCommand.IsCompleted;
            todoItem.Commentary = todoItemCommand.Commentary;
            todoItem.TaskName = todoItemCommand.TaskName;
        }
    }
}
