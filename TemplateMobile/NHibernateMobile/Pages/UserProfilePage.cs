using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Models.Domain.UserModels;
using Demo.Validation;
using DemoMobile.Annotations;
using DemoMobile.Elements;
using Xamarin.Forms;

namespace DemoMobile.Pages
{
   
    public class UserProfilePage : ValidatorPage<UserProfile, UserProfileValidator>
    {
        
        public ValidatableControl FirstNameEntry = new ValidatableControl("FirstName");

        public UserProfilePage()
        {
            Model = new UserProfileViewModel();

            this.BindingContext = Model;

            FirstNameEntry.SetEntryTextBinding("FirstName");

            var button = new Button()
            {
                Text = "Click Here"
            };

            button.Clicked += (sender, args) => Validate();

            var layout = new StackLayout()
            {
                Orientation = StackOrientation.Vertical
            };

            AddValidatableElement(layout, FirstNameEntry);

            AddValidatableElement(layout, button);

            this.Content = layout;
        }
    }
}
