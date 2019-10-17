using Lab1A.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using Lab1A.Models;
using System.Collections.Generic;
using Lab1A.Controllers;

namespace DealershipApiTest
{
    [TestClass]
    public class UnitTest1
    {
        private static DealershipMgr _context;
        public static List<Dealership> DealershipList { get; set; }
        [ClassInitialize]
        public static void Initialize(TestContext tc)
        {
            _context = new DealershipMgr();
            DealershipList.Add(new Dealership { Name = "Why", Email = "WhyAmIDoingThis@PleaseHelp.com", PhoneNumber = "905-543-6043" });
            DealershipList.Add(new Dealership { Name = "Car Place", Email = "CarPlace@gmail.com", PhoneNumber = "903-763-4543" });
            DealershipList.Add(new Dealership { Name = "Devons Cars", Email = "DevonsCars@hotmail.com", PhoneNumber = "365-008-6341" });
        }

        [TestMethod]
        public void DealershipApiGetAllTest()
        {
            DealershipsController dealerships = new DealershipsController(_context);

            IEnumerable<Dealership> testDealership = dealerships.GetDealership();

            Assert.IsInstanceOfType(testDealership, typeof(DbSet<Dealership>));

            DbSet<Dealership> testDbDealership = testDealership as DbSet<Dealership>;

            int count = DealershipList.Count;

            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void DealershipApiPass()
        {
            DealershipsController dealerships = new DealershipsController(_context);

            Dealership testDealership = dealerships.GetDealership(2);

            Assert.IsInstanceOfType(testDealership, typeof(Dealership));

            Assert.AreEqual("Devons Cars", testDealership.Name);
            Assert.AreEqual("365-008-6341", testDealership.Name);
        }

        [TestMethod]
        public void DealershipApiFail()
        {
            DealershipsController dealerships = new DealershipsController(_context);

            Dealership testDealership = dealerships.GetDealership(5);

            Assert.IsInstanceOfType(testDealership, typeof(Dealership));

            Assert.IsNull(testDealership);
        }

        [TestMethod]
        public void DealershipApiPostPass()
        {
            DealershipsController dealerships = new DealershipsController(_context);

            Dealership newDealership = new Dealership { Name = "My Dealership", Email = "MyDealership@outlook.com", PhoneNumber = "905-531-0912" };

            Dealership testDealership = dealerships.PostDealership(newDealership);

            Assert.AreEqual(4, DealershipList.Count);
            Assert.AreEqual("Devons Cars", DealershipList[4].Name);
        }

        [TestMethod]
        public void DealershipApiPostFail()
        {
            DealershipsController dealerships = new DealershipsController(_context);

            Dealership newDealership = new Dealership { Email = "CoolDealership@outlook.com", PhoneNumber = "905-428-0697" };

            Dealership testDealership = dealerships.PostDealership(newDealership);

            Assert.AreNotEqual(4, DealershipList.Count);
        }
    }
}
