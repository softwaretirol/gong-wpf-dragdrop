using System.Windows;
using System.Windows.Controls;
using Showcase.WPF.DragDrop.Models;

namespace Showcase.WPF.DragDrop.Views
{
    public partial class SeparateThreadSamples : UserControl
    {
        public SeparateThreadSamples()
        {
            this.InitializeComponent();
        }

        private void ButtonOpenWindowsOnClick(object sender, RoutedEventArgs e)
        {
            DedicatedThreadWindow.Open(() => new SeparateThreadDragWindow("Window A", left: 200, top: 200));
            DedicatedThreadWindow.Open(() => new SeparateThreadDragWindow("Window B", left: 540, top: 200));
        }
    }
}
