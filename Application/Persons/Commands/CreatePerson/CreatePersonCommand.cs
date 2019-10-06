using Domain.Enums;
using Domain.ValueObjects;
using MediatR;

namespace Application.Persons.Commands.CreatePerson
{
    public class CreatePersonCommand : IRequest<int>
    {
        public Name Name { get; set; }
        public GenderType GenderType { get; set; }

    }
}
