// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Moq;
using OtripleS.Portal.Web.Brokers.Apis;
using OtripleS.Portal.Web.Models.Courses;
using OtripleS.Portal.Web.Services.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using Tynamix.ObjectFiller;

namespace OtripleS.Portal.Web.Tests.Unit.Services.Courses
{
    public partial class CourseServiceTests
    {
        private readonly Mock<IApiBroker> apiBrokerMock;
        private readonly ICourseService courseService;

        public CourseServiceTests()
        {
            this.apiBrokerMock = new Mock<IApiBroker>();
            this.courseService = new CourseService(
                apiBroker: this.apiBrokerMock.Object);
        }

        private static int CreateRandomNumber() => new IntRange(min: 2, max: 10).GetValue();

        public static List<Course> CreateRandomCourses() =>
            CreateCourseFiller().Create(count: CreateRandomNumber()).ToList();

        private static Filler<Course> CreateCourseFiller()
        {
            var filler = new Filler<Course>();

            filler.Setup()
                  .OnType<DateTimeOffset>().Use(DateTimeOffset.Now);

            return filler;
        }
    }
}
