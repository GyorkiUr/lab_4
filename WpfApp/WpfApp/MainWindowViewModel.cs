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
        private ObservableObject repairingSelected;
        public ObservableObject ToBeReapiredSelected
        {
            get => toBeRepairedSelected;
            set
            {
                if (Equals(value, toBeRepairedSelected)) return;
                toBeRepairedSelected = value;
                OnPropertyChanged();
                SendToRepair.NotifyCanExecuteChanged();               
            }
        }

        public ObservableObject RepairingSelected
        {
            get => repairingSelected;
            set
            {
                if (Equals(value, repairingSelected)) return;
                repairingSelected = value;
                OnPropertyChanged();
                CallBackFromRepair.NotifyCanExecuteChanged();
            }
        }

        public ObservableCollection<PlaneViewModel> ToBeRepaired { get; set; } = new ObservableCollection<PlaneViewModel>();
        public ObservableCollection<PlaneViewModel> Repairing { get; set; } = new ObservableCollection<PlaneViewModel>();

        public RelayCommand Add { get; set; }
        public RelayCommand SendToRepair { get; set; }
        public RelayCommand CallBackFromRepair { get; set; }

        public MainWindowViewModel()
        {
            Add = new RelayCommand(AddPlane, CanAddPlane);
            SendToRepair = new RelayCommand(RepairPlane, CanRepairPlane);
            CallBackFromRepair = new RelayCommand(RemovePlane, CanRemovePlane);           

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

      

        public void AddPlane()
        {
            throw new NotImplementedException();
        }
        public bool CanAddPlane()
        {
            throw new NotImplementedException();
        }
        public void RepairPlane()
        {
            if (!CanRepairPlane())
            {
                return;
            }

            var planeToMove = ToBeReapiredSelected;

            if (planeToMove == null)
            {
                return;
            }

            ToBeRepaired.Remove((PlaneViewModel)planeToMove);
            Repairing.Add((PlaneViewModel)planeToMove);
        }
        public bool CanRepairPlane()
        {
            return ToBeReapiredSelected != null;
        }
        public void RemovePlane()
        {
            if (!CanRemovePlane())
            {
                return;
            }

            var planeToMove = RepairingSelected;

            if (planeToMove == null)
            {
                return;
            }
            Repairing.Remove((PlaneViewModel)planeToMove);
            ToBeRepaired.Add((PlaneViewModel)planeToMove);
        }
        public bool CanRemovePlane()
        {
            return RepairingSelected != null;
        }
       
        public double SumOfList
        {
            get
            {
                return Repairing.Sum(_ => _.RepairCost);
            }
        }

        


    }
}
