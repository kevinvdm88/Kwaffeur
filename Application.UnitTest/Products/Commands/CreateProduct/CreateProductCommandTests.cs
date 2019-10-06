using Application.Persons.Commands.CreatePerson;
using Application.UnitTest.Common;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UnitTest.Products.Commands.CreateProduct
{
    [TestClass]
    public class CreateProductCommandTests : CommandTestBase
    {
        [TestMethod]
        public void Handle_GivenValidRequest_ShouldRaiseCustomerCreatedNotification()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var sut = new CreatePersonCommandHandler(_context);

            //      var newCustomerId = "QAZQ1";

        }
    }
}
