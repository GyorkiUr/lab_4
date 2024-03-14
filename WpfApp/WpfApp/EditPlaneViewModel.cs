using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    public class EditPlaneViewModel : ObservableRecipient
    {
		private PlaneViewModel newPlane;

		public PlaneViewModel NewPlane
		{
			get { return newPlane; }
			set { SetProperty(ref newPlane, value);
				OnPropertyChanged();
			}
		}

        public EditPlaneViewModel(PlaneViewModel newPlane)
        {
            NewPlane = newPlane;
        }

        public EditPlaneViewModel()
        {
        }
    }
}
