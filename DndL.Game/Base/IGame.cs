﻿using Autofac;
using System;
using System.Collections.Generic;

namespace DndL.Game.Base
{
    public interface IGame
    {
        IBaseCharacter Player { get; set; }
        IDictionary<Guid, IBaseCharacter> Party { get; set; }

        void SetPlayer(Guid id);

        void Init(params object[] args);
    }

    public static class GameContainer
    {
        private static readonly Lazy<IContainer> Container 
            = new Lazy<IContainer>(() =>
            {
                var builder = new ContainerBuilder();
                builder.RegisterModule<Modules.GameInstanceModule>();
                return builder.Build();
            });

        public static IGame GetGame()
        {
            var x = Container.Value.Resolve<IGame>();
            return x;
        }

        public static IGameServer GetGameServer()
            => Container.Value.Resolve<IGameServer>();

    }
}
