using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    internal class PlaneViewModel : ObservableObject
    {
		private string name;

		public string Name
		{
			get { return name; }
			set {
				SetProperty(ref name, value);
				OnPropertyChanged();
				}
		}

		private string failure;

		public string Failure
		{
			get { return failure; }
			set {
                SetProperty(ref failure, value);
                OnPropertyChanged();
            }
		}




	}
}
