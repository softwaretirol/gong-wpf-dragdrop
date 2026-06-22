using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace Showcase.WPF.DragDrop.Models
{
    public static class DedicatedThreadWindow
    {
        public static void Open(Func<Window> windowFactory)
        {
            var thread = new Thread(() =>
            {
                SynchronizationContext.SetSynchronizationContext(
                    new DispatcherSynchronizationContext(Dispatcher.CurrentDispatcher));

                var window = windowFactory();

                window.Closed += (sender, args) => Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.Background);

                window.Show();

                Dispatcher.Run();
            })
            {
                IsBackground = true,
                Name = "Showcase dedicated UI thread"
            };

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }
}
