using System;
using System.Threading.Tasks;
using AutoFixture;
using BLL.Contracts;
using BLL.Implementation;
using DataAccess.Contracts;
using Domain.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BLL.Tests
{
    public class TaskCreateServiceTests
    {
        [Test]
        public async Task CreateAsync_AssigneeValidationSucceed_CreatesTask()
        {
            // Arrange
            var task = new TaskUpdateModel();
            var expected = new Domain.Task();
            
            var assigneeGetService = new Mock<IAssigneeGetService>();
            assigneeGetService.Setup(x => x.ValidateAsync(task));

            var taskDataAccess = new Mock<ITaskDataAccess>();
            taskDataAccess.Setup(x => x.InsertAsync(task)).ReturnsAsync(expected);

            var taskGetService = new TaskCreateService(taskDataAccess.Object, assigneeGetService.Object);
            
            // Act
            var result = await taskGetService.CreateAsync(task);
            
            // Assert
            result.Should().Be(expected);
        }

        [Test]
        public async Task CreateAsync_AssigneeValidationFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var task = new TaskUpdateModel();
            var expected = fixture.Create<string>();
            
            var assigneeGetService = new Mock<IAssigneeGetService>();
            assigneeGetService
                .Setup(x => x.ValidateAsync(task))
                .Throws(new InvalidOperationException(expected));

            var taskDataAccess = new Mock<ITaskDataAccess>();

            var taskGetService = new TaskCreateService(taskDataAccess.Object, assigneeGetService.Object);
            
            // Act
            var action = new Func<Task>(() => taskGetService.CreateAsync(task));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            taskDataAccess.Verify(x => x.InsertAsync(task), Times.Never);
        }
        
    }
}