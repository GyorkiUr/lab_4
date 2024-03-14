using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Windows;

namespace WpfApp
{
    public class MainWindowViewModel : ObservableRecipient
    {
		private ObservableCollection<PlaneViewModel> toBeRepaired;
		private ObservableCollection<PlaneViewModel> repairing;

        public MainWindowViewModel()
        {
            Rent = new RelayCommand(AddCar, CanAddCar);
            Edit = new RelayCommand(EditCar, CanEditCar);
            Return = new RelayCommand(RemoveCar, CanRemoveCar);
            SaveClose = new RelayCommand(SaveCar);

            ToBeRepaired.CollectionChanged += (sender, args) =>
            {
                OnPropertyChanged(nameof(AvgOfList));
            };
            Repairing.CollectionChanged += (sender, args) =>
            {
                OnPropertyChanged(nameof(SumOfList));
            };

            Random rnd = new Random();
            for (int i = 0; i < 4; i++)
            {
                ToBeRepaired.Add(new PlaneViewModel()
                {
                    basePrice = rnd.Next(1000),
                    colorCode = rnd.Next(7),
                    plateNumber = "ABC" + rnd.Next(9).ToString() + rnd.Next(9).ToString() + rnd.Next(9).ToString(),
                    speed = rnd.Next(240),
                    degradationFactor = rnd.NextDouble(),
                });
            }
        }

        public ObservableCollection<PlaneViewModel> ToBeRepaired { get; set; } = new ObservableCollection<PlaneViewModel>();
	
		public ObservableCollection<PlaneViewModel> Repairing { get; set; } = new ObservableCollection<PlaneViewModel>();



    }
}
