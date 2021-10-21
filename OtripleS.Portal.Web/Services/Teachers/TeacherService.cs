﻿// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using OtripleS.Portal.Web.Brokers.API;
using OtripleS.Portal.Web.Brokers.Logging;
using OtripleS.Portal.Web.Models.Teachers;

namespace OtripleS.Portal.Web.Services.Teachers
{
    public class TeacherService : ITeacherService
    {
        private readonly IApiBroker apiBroker;
        private readonly ILoggingBroker loggingBroker;

        public TeacherService(
            IApiBroker apiBroker,
            ILoggingBroker loggingBroker)
        {
            this.apiBroker = apiBroker;
            this.loggingBroker = loggingBroker;
        }

        public async ValueTask<IEnumerable<Teacher>> RetrieveAllTeachersAsync() =>
            await this.apiBroker.GetAllTeachersAsync();
    }
}
