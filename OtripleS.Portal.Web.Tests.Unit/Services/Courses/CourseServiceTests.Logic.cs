// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using FluentAssertions;
using Force.DeepCloner;
using Moq;
using OtripleS.Portal.Web.Models.Courses;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace OtripleS.Portal.Web.Tests.Unit.Services.Courses
{
    public partial class CourseServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveAllCoursesAsync()
        {
            var randomCourses = CreateRandomCourses();
            var returningCourses = randomCourses;
            var expectedRetrievedCourses = returningCourses.DeepClone();

            this.apiBrokerMock.Setup(broker => 
                broker.GetAllCoursesAsync())
                    .ReturnsAsync(returningCourses);

            List<Course> retrievedCourses = 
                await this.courseService.RetrieveAllCoursesAsync();

            retrievedCourses.Should().BeEquivalentTo(expectedRetrievedCourses);

            this.apiBrokerMock.Verify(broker => 
                broker.GetAllCoursesAsync(),
                    Times.Once);

            this.apiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
