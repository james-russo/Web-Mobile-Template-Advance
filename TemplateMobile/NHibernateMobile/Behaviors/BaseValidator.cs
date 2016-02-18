using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Validation;
using Xamarin.Forms;

namespace DemoMobile.Behaviors
{
    public class BaseValidator<TValidator, TType> : Behavior<TType> where TType : BindableObject
    {
        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.PropertyChanged += BindableOnPropertyChanged;
        }

        private void BindableOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            var validator = new UserProfileValidator();
        }
        

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.PropertyChanged += BindableOnPropertyChanged;
        }
    }
}
