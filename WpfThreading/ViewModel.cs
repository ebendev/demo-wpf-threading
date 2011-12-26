using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Threading;

namespace WpfThreading
{
    class ViewModel
    {
        private Dispatcher dispatcher;

        public ObservableCollection<string> Lines { get; set; }

        public ViewModel(Model model)
        {
            dispatcher = Dispatcher.CurrentDispatcher;
            Lines = new ObservableCollection<string>();
            model.NewLine += model_NewLine;
        }

        private void model_NewLine(string obj)
        {
            dispatcher.BeginInvoke(new ThreadStart(() => Lines.Add(obj)));
        }
    }
}
