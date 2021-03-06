﻿using System;
using System.Threading.Tasks;
using Elastic.Xunit.XunitPlumbing;
using FluentAssertions;
using Nest;
using Tests.Core.ManagedElasticsearch.Clusters;
using Tests.Domain;
using Tests.Framework;
using Tests.Framework.Integration;
using Tests.Framework.ManagedElasticsearch.Clusters;

namespace Tests.Search.Request
{
	public class PostFilterUsageTests : SearchUsageTestBase
	{
		public PostFilterUsageTests(ReadOnlyCluster cluster, EndpointUsage usage) : base(cluster, usage) { }

		protected override object ExpectJson =>
			new { post_filter = new { match_all = new { } } };


		protected override SearchRequest<Project> Initializer =>
			new SearchRequest<Project>()
			{
				PostFilter = new QueryContainer(new MatchAllQuery())
			};

		protected override Func<SearchDescriptor<Project>, ISearchRequest> Fluent => s => s
			.PostFilter(f => f.MatchAll());

		[I]
		public async Task ShouldHaveHits() => await AssertOnAllResponses((r) =>
		{
			r.Hits.Should().NotBeNull();
		});
	}
}
