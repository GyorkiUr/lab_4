using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

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

		private double repairCost;

		public double RepairCost
		{
			get { return repairCost; }
			set {
                SetProperty(ref repairCost, value);
                OnPropertyChanged();
            }
		}

		private int condition;

		public int Condition
		{
			get { return condition; }
			set {
                SetProperty(ref condition, value);
                OnPropertyChanged();
				OnPropertyChanged(nameof(conditionColor));
            }
		}

		private SolidColorBrush conditionColor;

        public PlaneViewModel(string name, string failure, double repairCost, int condition)
        {
            Name = name;
            Failure = failure;
            RepairCost = repairCost;
            Condition = condition;
        }

        public PlaneViewModel()
        {
            
        }

        public SolidColorBrush ConditionColor
		{
			get { 
				switch (condition)
				{
					case 0:
						return Brushes.Green;
						case 1:
							return Brushes.Yellow;
						case 2:
						return Brushes.Red;
					default:
						return Brushes.Transparent;
						break;
				}; }
			set {
                SetProperty(ref conditionColor, value);
                OnPropertyChanged();
            }
		}

        public override string ToString()
        {
			return $"{Name} {Failure} {RepairCost} {Condition}";
        }







    }
}
