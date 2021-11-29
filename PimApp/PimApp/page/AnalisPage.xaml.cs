using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PimApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnalisPage : ContentPage
    {
        private int iterator = 0;
        private readonly ObservableCollection<float> data;
        private readonly Label label;
        private readonly Label labelNumber;
        private readonly Entry entry;
        private readonly ListView listView;
        private readonly Button enterButton;
        private int index;
        private bool flag = true;
        public AnalisPage()
        {
            InitializeComponent();
            ObservableCollection<float> observableCollections = new ObservableCollection<float>();
            this.data = observableCollections;
            StackLayout stackLayout = new StackLayout();
            this.BindingContext = this;
            label = new Label
            {
                Text = GetInputMessage(),
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 15,
                BackgroundColor = Color.LightBlue,
            };

            entry = new Entry
            {
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 15,
                TextColor = Color.LightBlue,
                MaxLength = 10,
                Keyboard = Keyboard.Numeric,
                ClearButtonVisibility = ClearButtonVisibility.WhileEditing,
                ReturnType = ReturnType.Done
            };

            labelNumber = new Label
            {
                Text = Resource.Vvod1 + iterator + Resource.Vvod2,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 15,
                BackgroundColor = Color.LightBlue,
            };

            enterButton = new Button()
            {
                Text = Resource.EnterButton,
                FontSize = 15
            };

            listView = new ListView
            {
                ItemsSource = data
            };

            Button okButton = new Button()
            {
                Text = Resource.OkButton,
                BackgroundColor = Color.Green,
                FontSize = 15
            };

            Button ResetButton = new Button()
            {
                Text = Resource.ResetButton,
                BackgroundColor = Color.Red,
                FontSize = 15
            };

            enterButton.Clicked += OnEnterButtonClicked;
            okButton.Clicked += OnButtonClicked;
            ResetButton.Clicked += ResetButtonClicked;
            listView.ItemTapped += ListPogr_itemTapped;

            stackLayout.Children.Add(label);
            stackLayout.Children.Add(entry);
            stackLayout.Children.Add(enterButton);
            stackLayout.Children.Add(labelNumber);
            stackLayout.Children.Add(listView);
            stackLayout.Children.Add(okButton);
            stackLayout.Children.Add(ResetButton);
            stackLayout.Spacing = 8;
            this.Content = stackLayout;
        }

        private void OnEnterButtonClicked(object sender, System.EventArgs e)
        {
            if (String.IsNullOrEmpty(entry.Text))
            {
                DisplayAlert(Resource.DisplayAlertHeader, Resource.NoData, "ОK");
                if (iterator < 7) entry.Focus();
            }
            else
            {
                float value = float.Parse(entry.Text);
                if (value >= 100)
                {
                    DisplayAlert(Resource.DisplayAlertHeader, Resource.Bag, "ОK");
                    if (iterator < 7) entry.Focus();
                }
                else
                {
                    this.data.Add(value);
                    iterator += 1;
                    entry.Text = String.Empty;
                    label.Text = GetInputMessage();
                    labelNumber.Text = Resource.Vvod1 + iterator + Resource.Vvod2;
                    if (iterator < 7) entry.Focus();
                }
            }
        }

        private void ResetButtonClicked(object sender, System.EventArgs e)
        {
            data.Clear();
            iterator = 0;
            label.Text = GetInputMessage();
            labelNumber.Text = Resource.Vvod1 + iterator + Resource.Vvod2;
            entry.Text = null;
            entry.Focus();
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            if (iterator < 3)
            {
                await DisplayAlert(Resource.DisplayAlertHeader, Resource.NonPayment, "ОK");
                entry.Focus();
            }
            else
            {
                if ((3 <= iterator) && (iterator < 7))
                {
                    await DisplayAlert(Resource.Attention, Resource.MinValue, "ОK");
                }
                Calculator calculator = new Calculator(new CalculatorProcessor());
                calculator.Calculate(data);
                await Navigation.PushAsync(new ResultPage(calculator.Data));
            }
        }

        private void ListPogr_itemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item !=null)
            {
                this.index = e.ItemIndex;
                entry.Text = data[index].ToString();
                label.Text = Resource.Edit1 + (index + 1) + Resource.Edit2;
                if (flag)
                {
                    enterButton.Text = Resource.Save;
                    enterButton.Clicked += OnEditButtonClicked;
                    enterButton.Clicked -= OnEnterButtonClicked;
                    flag = false;
                }
                entry.Focus();
            }
        }

        private void OnEditButtonClicked(object sender, System.EventArgs e)
        {
            if (String.IsNullOrEmpty(entry.Text))
            {
                DisplayAlert(Resource.DisplayAlertHeader, Resource.NoData, "ОK");
                entry.Focus();
            }
            else
            {
                float value = float.Parse(entry.Text);
                if (value >= 100)
                {
                    DisplayAlert(Resource.DisplayAlertHeader, Resource.Bag, "ОK");
                    entry.Focus();
                }
                else
                {
                    data[index] = value;
                    entry.Text = null;
                    label.Text = GetInputMessage();
                    enterButton.Text = Resource.Enter;
                    if (flag == false)
                    {
                        enterButton.Clicked -= OnEditButtonClicked;
                        enterButton.Clicked += OnEnterButtonClicked;
                        flag = true;
                    }
                    if (iterator < 7) entry.Focus();
                }
            }
        }

        private string GetInputMessage()
        {
            return Resource.Enter1 + (iterator + 1) + Resource.Enter2;
        }
    }
}
