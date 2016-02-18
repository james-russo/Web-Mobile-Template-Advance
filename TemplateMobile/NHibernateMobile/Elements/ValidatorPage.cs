using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using DemoMobile.Annotations;
using Xamarin.Forms;

namespace DemoMobile.Elements
{
    public abstract class ValidatorPage<T, TValidator> : ContentPage where TValidator : IValidator, new() where T : class, new()
    {
        public IBaseType<T> Model { get; set; }

        private readonly HashSet<IValidatableControl> ValidatableElements = new HashSet<IValidatableControl>();

        public void AddValidatableElement(Layout<View> layout, View control)
        {
            layout.Children.Add(control);

            var item = control as IValidatableControl;

            if (item != null)
            {
                ValidatableElements.Add(item);
            }
        }

        public void Validate()
        {
            var validator = new TValidator();

            var result = validator.Validate(Model.BaseType);

            if (!result.IsValid)
            {
                var controlsHavingValidation = ValidatableElements.Where(a => a.HasError);

                foreach (var control in controlsHavingValidation)
                {
                    control.Clear();
                }

                foreach (var error in result.Errors)
                {
                    var control = ValidatableElements.FirstOrDefault(a => a.Identifier == error.PropertyName);

                    if (control != null)
                    {
                        control.SetMessageColor(Color.Red);

                        control.SetMessage(error.ErrorMessage);
                    }
                }
            }
        }

    }
}
