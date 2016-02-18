using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Models.Domain.UserModels;
using DemoMobile.Pages;
using Xamarin.Forms;

namespace DemoMobile.Behaviors
{
    public class UserProfileBehavior : Behavior<Entry>
    {
        static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(UserProfileBehavior), false);

        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        public bool IsValid
        {
            get { return (bool)base.GetValue(IsValidProperty); }
            private set { base.SetValue(IsValidPropertyKey, value); }
        }

        public UserProfileBehavior()
        {

        }
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            

            
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            
            base.OnDetachingFrom(bindable);
        }
    }
}
