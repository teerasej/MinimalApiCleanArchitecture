﻿using Customer.Infrastructure.Persistence.PropertyHandler;

namespace Customer.Infrastructure.Persistence.Configurations;

public class OrderConfiguration : BaseConfiguration<Core.Entities.Order>
{
    public override void Configure(IServiceCollection services)
    {
        FluentDefinition
            .Table("[Order]")
            .DbType(cus => cus.Id, System.Data.DbType.Int64)
            .DbType(cus => cus.CreatedDate, System.Data.DbType.DateTime)
            .DbType(cus => cus.LastModifiedDate, System.Data.DbType.DateTime);
    }
    public override void ConfigureHandler(IApplicationBuilder app)
    {
        FluentDefinition
            .PropertyHandler(f => f.CreatedDate, app.ApplicationServices.GetRequiredService<DateTimeHandler>())
            .PropertyHandler(f => f.LastModifiedDate, app.ApplicationServices.GetRequiredService<DateTimeHandler>());
    }
}
