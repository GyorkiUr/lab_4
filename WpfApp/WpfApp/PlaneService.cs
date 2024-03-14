using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    public class PlaneService : IPlaneService
    {
        public PlaneViewModel plane { get; set; }

        public void Add(MainWindowViewModel vm)
        {
            var window = new PlaneEditor();
            window.Setup(vm);
            window.ShowDialog();
        }
    }
}
