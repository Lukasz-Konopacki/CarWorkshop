using CarWorkshop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.ViewModel
{
    public class CarViewModel : ViewModelBase
    {
        private readonly Car _car;


        public CarViewModel(Car car)
        {
            _car = car;
        }
    }
}
