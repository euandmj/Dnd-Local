using Autofac;
using DndL.Game.Base;

namespace DndL.Game.Modules
{
    public class GameInstanceModule
        : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<_5e._5eGame>().As<IGame>();
        }
    }
}
