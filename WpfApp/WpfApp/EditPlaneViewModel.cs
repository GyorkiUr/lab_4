using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    public class EditPlaneViewModel : ObservableRecipient
    {
        public RelayCommand close { get; set; }



        public EditPlaneViewModel()
        {

        }
    }
}
