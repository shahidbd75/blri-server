using System;
using System.Collections.Generic;
using System.Text;

namespace BLRI.ViewModel.Core
{
    public abstract class BaseViewModel<T>
    {
        public T Id { get; set; }
        public string Name { get; set; }
    }
}
