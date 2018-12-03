using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using TimeTable.Application.Schedule.Queries.GetScheduleDetail;
using TimeTable.Application.Schedule.Queries.GetScheduleList;
using TimeTable.Persistance;

namespace TimeTable.Application.Tests.Queries
{
    [TestClass]
    public class Query_UnitTests_NoData
    {
        public TimeTableContext db { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<TimeTableContext>()
             .UseInMemoryDatabase(databaseName: "InMemoryPopulated")
             .Options;

            db = new TimeTableContext(options);
        }

        [TestMethod]
        public void TestGetScheduleDetailQuery_NoData()
        {
            var cmd = new GetScheduleDetailQueryHandler(db);
            var qry = new GetScheduleDetailQuery { Id = 1 };
            var cancel = new CancellationToken();
            var cqrsResult = cmd.Handle(qry, cancel);
            Assert.ThrowsException<AggregateException>(() => cqrsResult.Result);
        }

        [TestMethod]
        public void TestGetScheduleListQuery_NoData()
        {
            var cmd = new GetScheduleListQueryHandler(db);
            var qry = new GetScheduleListQuery();
            var cancel = new CancellationToken();
            var cqrsResult = cmd.Handle(qry, cancel);
            Assert.IsTrue(cqrsResult.Result.Schedules.Count == 0);
        }
    }
}
