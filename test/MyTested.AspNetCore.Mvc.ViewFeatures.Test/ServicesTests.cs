﻿namespace MyTested.AspNetCore.Mvc.Test
{
    using Internal;
    using Internal.Application;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Setups.Startups;
    using Xunit;

    public class ServicesTests
    {
        [Fact]
        public void DefaultConfigurationShouldSetMockedTempDataProvider()
        {
            MyMvc.IsUsingDefaultConfiguration();

            var tempDataProvider = TestServiceProvider.GetService<ITempDataProvider>();

            Assert.NotNull(tempDataProvider);
            Assert.IsAssignableFrom<MockedTempDataProvider>(tempDataProvider);
        }

        [Fact]
        public void ExplicitMockedTempDataProviderShouldOverrideIt()
        {
            MyMvc
                .StartsFrom<DataStartup>()
                .WithServices(services =>
                {
                    services.ReplaceTempDataProvider();
                });

            var tempDataProvider = TestServiceProvider.GetService<ITempDataProvider>();

            Assert.NotNull(tempDataProvider);
            Assert.IsAssignableFrom<MockedTempDataProvider>(tempDataProvider);

            MyMvc.IsUsingDefaultConfiguration();
        }
    }
}
