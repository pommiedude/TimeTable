using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeTable.Persistance;
using TimeTable.Application.Schedule.Commands.CreateSchedule;
using System;
using System.Threading;
using MediatR;
using TimeTable.Application.Schedule.Commands.DeleteSchedule;

namespace TimeTable.Application.Tests.Commands
{
    [TestClass]
    public class Command_UnitTests_WithData
    {
        public TimeTableContext db { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<TimeTableContext>()
             .UseInMemoryDatabase(databaseName: "InMemoryPopulated")
             .Options;

            db = new TimeTableContext(options);

            // Load sample data for this test
            ApplicationDbInitializer.Initialize(db).Wait();
        }

        [TestMethod]
        public void Test_CreateScheduleCommand_Create()
        {
            var cmdHandler = new CreateScheduleCommandHandler(db);
            var cmd = new CreateScheduleCommand { Title = "Title", Line = "Line", Date = DateTime.Now };
            var cancel = new CancellationToken();
            var cmdResult = cmdHandler.Handle(cmd, cancel);
            var rslt = cmdResult.Result;
            Assert.IsTrue(rslt != null);
        }

        [TestMethod]
        public void Test_DeleteScheduleCommand_NonExisting()
        {
            var cmdHandler = new DeleteScheduleCommandHandler(db);
            var cmd = new DeleteScheduleCommand { Id = 9999 };
            var cancel = new CancellationToken();
            var cqrsResult = cmdHandler.Handle(cmd, cancel);
            Assert.ThrowsException<AggregateException>(() => cqrsResult.Result);
        }
    }
}
