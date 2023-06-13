using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.ViewModel
{
    public class ViewModelParams : ViewModelBase
    {
        public Dictionary<string, object> Params { get; set; }

        ViewModelParams(Dictionary<string, object> @params)
        {
            Params = @params;
        }
    }
}
