using Autofac;
using DndL.Game.Base;

namespace DndL.Game.Modules
{
    internal sealed class GameInstanceModule
        : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<_5e._5eGame>()
                .As<IGame>()
                .InstancePerLifetimeScope()
                .OnActivated((x) => x.Instance.Init());
            builder
                .RegisterType<_5e._5eGameServer>()
                .As<IGameServer>()
                .InstancePerLifetimeScope();
        }
    }
}
