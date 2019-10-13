using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Validator
{
    public abstract class BaseValidator<T> : AbstractValidator<T> where T : class
    {
        protected virtual string MaxLengthMessage => "{PropertyName} must be less than {MaxLength} characters.";
        protected virtual string NotAValidEnumMessage => "{PropertyName} is not a valid Enum value.";

        protected virtual string IsRequiredMessage => "{PropertyName} is required.";
    }
}
