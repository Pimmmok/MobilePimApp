using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text;

namespace PimApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultPage : ContentPage
    {
        private readonly CalculatorData data;

        public ResultPage(CalculatorData data)
        {
            InitializeComponent();
            this.Title = Resource.Analis;
            this.data = data;
            Label header = new Label
            {
                Text = Resource.EnteredValue,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 15,
                BackgroundColor = Color.LightBlue,
            };
            StackLayout stackLayout = new StackLayout();
            ListView listView = new ListView
            {
                ItemsSource = this.data.Result
            };
            listView.ItemSelected += DeselectItem;

            Label label1 = new Label
            {
                Text = Resource.Count + this.data.Result.Length + "",
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 15,
                BackgroundColor = Color.LightBlue,
            };

            Label label2 = new Label
            {
                Text = Resource.Avg + this.data.Avg + "",
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 15,
                BackgroundColor = Color.LightBlue,
            };

            Label label3 = new Label
            {
                Text = Resource.Avg2 + this.data.Sredneeqvadro + " %",
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 15,
                BackgroundColor = Color.LightBlue,
            };

            Label label4 = new Label
            {
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 15,
                Text = Resource.True,
                BackgroundColor = Color.Green
            };

            Button saveButton = new Button
            {
                Text = Resource.Save,
                FontSize = 15
            };

            Button backButton = new Button
            {
                Text = Resource.Back,
                FontSize = 15
            };

            if (data.Sredneeqvadro > 0.5)
            {
                label4.Text = Resource.False;
                label4.BackgroundColor = Color.Red;
            }

            backButton.Clicked += BackButton_Click;
            saveButton.Clicked += CreateAkt;
            this.Content = new StackLayout { Children = { header, listView, label1, label2, label3, label4, saveButton, backButton } };
        }

        private async void BackButton_Click(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void CreateAkt(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder();
            foreach (float i in data.Result)
            {
                result.Append(String.Concat(i.ToString(), ";"));
            }

            Akt akt = new Akt
            {
                Results = result.ToString(),
                Number_of_measurements = data.Result.Length,
                Average = data.Avg.ToString(),
                Qvadro_Average = data.Sredneeqvadro.ToString(),
                Date_Akt = DateTime.Today.ToString("dd.MM.yyyy")
            };

            SavePage SaveForm = new SavePage
            {
                BindingContext = akt
            };
            await Navigation.PushAsync(SaveForm);
        }

        private void DeselectItem(object sender, EventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}
