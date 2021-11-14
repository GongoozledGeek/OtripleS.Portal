// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using OtripleS.Portal.Web.Brokers.Apis;
using OtripleS.Portal.Web.Models.Courses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OtripleS.Portal.Web.Services.Courses
{
    public class CourseService : ICourseService
    {
        private readonly IApiBroker apiBroker;

        public CourseService(IApiBroker apiBroker)
        {
            this.apiBroker = apiBroker;
        }

        public async ValueTask<List<Course>> RetrieveAllCoursesAsync() => 
            await this.apiBroker.GetAllCoursesAsync();
    }
}
