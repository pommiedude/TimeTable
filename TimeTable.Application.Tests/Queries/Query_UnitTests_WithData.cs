using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using TimeTable.Application.Schedule.Queries.GetScheduleDetail;
using TimeTable.Application.Schedule.Queries.GetScheduleList;
using TimeTable.Persistance;

namespace TimeTable.Application.Tests.Queries
{
    [TestClass]
    public class Query_UnitTests_WithData
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
        public void TestGetScheduleDetailQuery_WithData()
        {
            var cmd = new GetScheduleDetailQueryHandler(db);
            var qry = new GetScheduleDetailQuery { Id = 1 };
            var cancel = new CancellationToken();
            var cqrsResult = cmd.Handle(qry, cancel);
            Assert.IsTrue(cqrsResult.Result.ScheduleId == 1);
        }

        [TestMethod]
        public void TestGetScheduleListQuery_WithData()
        {
            var cmd = new GetScheduleListQueryHandler(db);
            var qry = new GetScheduleListQuery();
            var cancel = new CancellationToken();
            var cqrsResult = cmd.Handle(qry, cancel);
            Assert.IsTrue(cqrsResult.Result.Schedules.Count > 1);
        }
    }
}
