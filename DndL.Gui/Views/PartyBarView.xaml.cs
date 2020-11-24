﻿using DndL.Core.Events;
using DndL.Game._5e;
using DndL.Gui.Commands;
using DndL.Gui.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DndL.Gui.Views
{
    /// <summary>
    /// Interaction logic for PartyBarControl.xaml
    /// </summary>
    public partial class PartyBarView : UserControl
    {
        public event EventHandler<GenericEventArgs<NPlayerCharacter>> PlayerSelectedEvent;

        private readonly PartyBarViewModel viewModel;

        public PartyBarView()
        {
            InitializeComponent();

            DataContext = viewModel = new PartyBarViewModel();

            viewModel.PlayerSelectedEvent += (s, e) =>
            {
                PlayerSelectedEvent?.Invoke(s, e);
            };
        }
    }

    class PartyBarViewModel
        : BaseViewModel
    {
        public event EventHandler<GenericEventArgs<NPlayerCharacter>> PlayerSelectedEvent;

        public PartyBarViewModel()
        {
            Characters = base.partyCharacters.Values.ToList();


            MouseLeftButtonDownCommand = new Command(x =>
            {
                PlayerSelectedEvent?.Invoke(this, new GenericEventArgs<NPlayerCharacter>((NPlayerCharacter)x));
            });
        }

        public List<NPlayerCharacter> Characters { get; init; }
        public ICommand MouseLeftButtonDownCommand { get; }
    }
}
