﻿using System.Threading.Tasks;
using Elastic.Xunit.XunitPlumbing;
using Nest;
using Tests.Framework;
using static Tests.Framework.UrlTester;

namespace Tests.Cat.CatNodes
{
	public class CatNodesUrlTests : UrlTestsBase
	{
		[U] public override async Task Urls()
		{
			await GET("/_cat/nodes")
				.Fluent(c => c.CatNodes())
				.Request(c => c.CatNodes(new CatNodesRequest()))
				.FluentAsync(c => c.CatNodesAsync())
				.RequestAsync(c => c.CatNodesAsync(new CatNodesRequest()))
				;
		}
	}
}
