using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace DemoMobile.Annotations
{
    public interface IBaseType<T> where T : class, new()
    {
        T BaseType { get; set; } 
    }

    public abstract class BaseAnnotation<T> : IBaseType<T>, INotifyPropertyChanged where T : class, new()
    {
        public T BaseType { get; set; }

        protected BaseAnnotation(T model)
        {
            BaseType = model;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        protected bool SetField<Titem>(ref Titem field, Titem value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<Titem>.Default.Equals(field, value))
                return false;

            field = value;

            BaseType.GetType().GetRuntimeProperty(propertyName).SetValue(BaseType, value);

            OnPropertyChanged(propertyName);
            return true;
        }

        public override string ToString()
        {
            return BaseType.ToString();
        }
    }
}
