using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DemoMobile.Annotations;
using Xamarin.Forms;

namespace DemoMobile.Elements
{
    public interface IValidatableControl
    {
        string Identifier { get; set; }

        Entry Entry { get; set; }

        Label Message { get; set; }

        void SetMessage(string message);

        void SetMessageColor(Color color);

        void Clear();

        bool HasError { get; set; }
    }

    public class ValidatableControl : ContentView, IValidatableControl
    {
        public string Identifier { get; set; }

        public Entry Entry { get; set; }

        public Label Message { get; set; }

        public bool HasError { get; set; }

        public ValidatableControl(string propertyName)
        {

            Identifier = propertyName;

            Entry = new Entry();

            Message = new Label { IsVisible = false };


            var stackLayout = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    Entry,
                    Message
                }
            };


            this.Content = stackLayout;
        }

        public void SetEntryTextBinding(string propertyName)
        {
            Entry.SetBinding(Entry.TextProperty, propertyName);
        }

        public void SetMessage(string message)
        {
            Message.Text = message;

            HasError = true;

            Message.IsVisible = true;
        }

        public void SetMessageColor(Color color)
        {
            Message.TextColor = color;
        }

        public void Clear()
        {
            HasError = false;

            Message.Text = "";

            Message.TextColor = Color.Default;
        }
    }
}
