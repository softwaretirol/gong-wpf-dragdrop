using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Showcase.WPF.DragDrop.Models
{
    public class DragItemModel : INotifyPropertyChanged
    {
        private string _caption;

        public DragItemModel(int index, string caption)
        {
            this.Index = index;
            this._caption = caption;
        }

        public int Index { get; set; }

        public string Caption
        {
            get => this._caption;
            set
            {
                if (value == this._caption) return;
                this._caption = value;
                this.OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return this.Caption;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
