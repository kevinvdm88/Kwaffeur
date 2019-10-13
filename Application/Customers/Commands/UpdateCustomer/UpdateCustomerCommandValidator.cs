using Application.Common.Validator;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : BaseValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            CreatePersonValidator();
            CreateAddressValidator();
            CreateContactDataValidator();
            CreateCustomerValidator();
        }

        private void CreatePersonValidator()
        {
            RuleFor(x => x.Person.FirstName).NotEmpty().WithMessage(IsRequiredMessage)
                .MaximumLength(150).WithMessage(MaxLengthMessage);
            RuleFor(x => x.Person.LastName).NotEmpty().WithMessage(IsRequiredMessage)
                .MaximumLength(150).WithMessage(MaxLengthMessage);
            RuleFor(x => x.Person.GenderType).IsInEnum().WithMessage(NotAValidEnumMessage);
        }

        private void CreateAddressValidator()
        {
            RuleFor(x => x.Address.Street).NotEmpty().WithMessage(IsRequiredMessage)
                .MaximumLength(200).WithMessage(MaxLengthMessage);
            RuleFor(x => x.Address.Number).NotEmpty().WithMessage(IsRequiredMessage)
                .MaximumLength(20).WithMessage(MaxLengthMessage);
            RuleFor(x => x.Address.City).NotEmpty().WithMessage(IsRequiredMessage)
                .MaximumLength(200).WithMessage(MaxLengthMessage);

            //use dropdown !
            RuleFor(x => x.Address.Country).MaximumLength(200).WithMessage(MaxLengthMessage);
            RuleFor(x => x.Address.State).MaximumLength(200).WithMessage(MaxLengthMessage);
            RuleFor(x => x.Address.ZipCode).MaximumLength(30).WithMessage(MaxLengthMessage);
        }

        private void CreateContactDataValidator()
        {
            RuleFor(x => x.ContactData.Email)
                .MaximumLength(200).WithMessage(MaxLengthMessage)
                .NotEmpty().WithMessage(IsRequiredMessage)
                .EmailAddress().WithMessage("Please select a valid emailaddress");
            RuleFor(x => x.ContactData.Fax).MaximumLength(30).WithMessage(MaxLengthMessage);
            RuleFor(x => x.ContactData.Mobile).MaximumLength(30).WithMessage(MaxLengthMessage);
            RuleFor(x => x.ContactData.Phone).MaximumLength(30).WithMessage(MaxLengthMessage);
            RuleFor(x => x.ContactData.VatNumber).MaximumLength(30).WithMessage(MaxLengthMessage);
        }

        private void CreateCustomerValidator()
        {
            RuleFor(x => x.CustomerType).IsInEnum().WithMessage(NotAValidEnumMessage);
        }
    }
}
