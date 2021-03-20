using System;
using BLL.Implementation;
using Domain.Contracts;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using AutoFixture;
using DataAccess.Contracts;
using FluentAssertions;

namespace BLL.Tests
{
    [TestFixture]
    public class AssigneeGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_AssigneeExists_DoesNothing()
        {
            // Arrange
            var assigneeContainer = new Mock<IAssigneeContainer>();
            var assignee = new Domain.Assignee();
            var assigneeDataAccess = new Mock<IAssigneeDataAccess>();

            assigneeDataAccess.Setup(x => x.GetByAsync(assigneeContainer.Object)).ReturnsAsync(assignee);

            var assigneeGetService = new AssigneeGetService(assigneeDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => assigneeGetService.ValidateAsync(assigneeContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_AssigneeNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            
            var assigneeContainer = new Mock<IAssigneeContainer>();
            assigneeContainer.Setup(x => x.AssigneeId).Returns(id);
            
            var assigneeDataAccess = new Mock<IAssigneeDataAccess>();
            assigneeDataAccess.Setup(x => x.GetByAsync(assigneeContainer.Object)).ReturnsAsync((Domain.Assignee)null);

            var assigneeGetService = new AssigneeGetService(assigneeDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => assigneeGetService.ValidateAsync(assigneeContainer.Object));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Assignee not found by id {id}");
        }
    }
}