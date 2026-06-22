using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;
using Showcase.WPF.DragDrop.Models;

namespace Showcase.WPF.DragDrop.Views
{
    public partial class SeparateThreadDragWindow : Window
    {
        public SeparateThreadDragWindow(string label, double left, double top)
        {
            this.Items = new ObservableCollection<DragItemModel>();
            for (var i = 1; i <= 8; i++)
            {
                this.Items.Add(new DragItemModel(i, $"{label} item {i}"));
            }

            this.InitializeComponent();

            this.Title = $"{label} — UI Thread {Thread.CurrentThread.ManagedThreadId}";
            this.Left = left;
            this.Top = top;
            this.WindowStartupLocation = WindowStartupLocation.Manual;
            this.DataContext = this;
        }

        public ObservableCollection<DragItemModel> Items { get; }
    }
}
