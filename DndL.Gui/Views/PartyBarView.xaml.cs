using DndL.Core.Events;
using DndL.Game.Base;
using DndL.Gui.ViewModels;
using System;
using System.Windows.Controls;

namespace DndL.Gui.Views
{
    /// <summary>
    /// Interaction logic for PartyBarControl.xaml
    /// </summary>
    public partial class PartyBarView : UserControl
    {
        public event EventHandler<GenericEventArgs<IBaseCharacter>> PlayerSelectedEvent;

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

        private void UserControl_DragLeave(object sender, System.Windows.DragEventArgs e)
        {

        }
    }
    
}
