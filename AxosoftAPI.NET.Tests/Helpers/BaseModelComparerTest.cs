using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AxosoftAPI.NET;
using AxosoftAPI.NET.Models;
using System.Collections.Generic;
using System.Linq;
using AxosoftAPI.NET.Helpers;

namespace AxosoftAPI.NET.Tests.Helpers
{
	[TestClass]
	public class BaseModalComparerTest
	{
		[TestMethod]
		public void BaseModalComparer_Equals_SameObject()
		{
			var bmComparer = new BaseModelComparer<BaseModel>();
			var bModel = new BaseModel();

			var result = bmComparer.Equals(bModel, bModel);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void BaseModalComparer_Equals_SameId()
		{
			var bmComparer = new BaseModelComparer<BaseModel>();
			var bModel1 = new BaseModel { Id = 666 };
			var bModel2 = new BaseModel { Id = 666 };

			var result = bmComparer.Equals(bModel1, bModel2);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void BaseModalComparer_Equals_LeftNull()
		{
			var bmComparer = new BaseModelComparer<BaseModel>();
			var bModel = new BaseModel();

			var result = bmComparer.Equals(null, bModel);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void BaseModalComparer_Equals_RightNull()
		{
			var bmComparer = new BaseModelComparer<BaseModel>();
			var bModel = new BaseModel();

			var result = bmComparer.Equals(bModel, null);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void BaseModalComparer_Equals_LeftNullId()
		{
			var bmComparer = new BaseModelComparer<BaseModel>();
			var bModel1 = new BaseModel();
			var bModel2 = new BaseModel { Id = 666 };

			var result = bmComparer.Equals(bModel1, bModel2);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void BaseModalComparer_Equals_RightNullId()
		{
			var bmComparer = new BaseModelComparer<BaseModel>();
			var bModel1 = new BaseModel { Id = 666 };
			var bModel2 = new BaseModel();

			var result = bmComparer.Equals(bModel1, bModel2);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void BaseModalComparer_GetHashCode()
		{
			var intValue = 99;

			var bmComparer1 = new BaseModelComparer<BaseModel>();

			var result = bmComparer1.GetHashCode(new BaseModel { Id = intValue });

			Assert.AreEqual(intValue.GetHashCode(), result);
		}

		[TestMethod]
		public void BaseModalComparer_GetHashCode_Null()
		{
			var bmComparer1 = new BaseModelComparer<BaseModel>();

			var result = bmComparer1.GetHashCode(null);

			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void BaseModalComparer_GetHashCode_NullId()
		{
			var bmComparer1 = new BaseModelComparer<BaseModel>();

			var result = bmComparer1.GetHashCode(new BaseModel());

			Assert.AreEqual(0, result);
		}
	}
}
