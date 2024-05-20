using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler
            : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUsersDbContext _dbContext;

        public UpdateUserCommandHandler(IUsersDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateUserCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Users.FirstOrDefaultAsync(User =>
                    User.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new Exception();
            }

            entity.Name = request.Name;
            entity.Email = request.Email;
            entity.Password = request.Password;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
