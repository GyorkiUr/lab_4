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

        private ObservableObject toBeRepairedSelected;

        public ObservableObject ToBeReapiredSelected
        {
            get { return toBeRepairedSelected; }
            set { toBeRepairedSelected = value; }
        }

        private ObservableObject repairingSelected;

        public ObservableObject RepairingSelected
        {
            get { return repairingSelected; }
            set { repairingSelected = value; }
        }


        public RelayCommand Add { get; set; }
        public RelayCommand SendToRepair { get; set; }
        public RelayCommand CallBackFromRepair { get; set; }

        public MainWindowViewModel()
        {
            Add = new RelayCommand(AddCar, CanAddCar);
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
                    Name = "Apache" + rnd.Next(1000).ToString(),
                    Failure =  "Error"+ rnd.Next(7),
                    RepairCost = rnd.Next(100)*rnd.NextDouble(),
                    Condition = rnd.Next(3),
                });
            }
        }

        public ObservableCollection<PlaneViewModel> ToBeRepaired { get; set; } = new ObservableCollection<PlaneViewModel>();
	
		public ObservableCollection<PlaneViewModel> Repairing { get; set; } = new ObservableCollection<PlaneViewModel>();



    }
}
