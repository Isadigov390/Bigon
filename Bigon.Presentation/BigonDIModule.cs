using Autofac;
using Bigon.DataAccessLayer;
using Bigon.Repository;
using Microsoft.EntityFrameworkCore;

class AppModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);
        builder.RegisterAssemblyTypes(typeof(IRepositoryReference).Assembly).AsImplementedInterfaces();
        var type = typeof(IDataAccessLayerReference).Assembly.GetType("Bigon.DataAccessLayer.Contexts.DataContext");
        builder.RegisterType(type).As<DbContext>();
    }
}