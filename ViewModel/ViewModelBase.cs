﻿using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.ViewModel
{
    public abstract class ViewModelBase :ObservableObject
    {
        public Dictionary<string, object> Params { get; set; }

        public ViewModelBase()
        {
            Params = new Dictionary<string, object>();
        }
    }
}
