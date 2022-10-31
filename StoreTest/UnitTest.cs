using Microsoft.AspNetCore.Mvc;
using StoreAssistantApp.Controllers;
using StoreAssistantApp.Services.Interface;

namespace StoreTest
{
	[TestClass]
	public class UnitTest
	{
		private readonly IStoreService service;

		public UnitTest(IStoreService service)
		{
			this.service = service;
		}
		[TestMethod]
		public void TestIndex()
		{
			var controller = new StoreController(service);
			var result = controller.Index() as IActionResult;
			Assert.AreEqual("Index",result);
		}
		[TestMethod]
		public void TestDelete()
		{
            var controller = new StoreController(service);
			var result = controller.DeleteHistory(-1);
            Assert.AreEqual("Index", result);
        }
	}
}