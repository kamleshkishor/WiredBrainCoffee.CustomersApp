﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WiredBrainCoffee.CustomersApp.DataProvider;
using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private CustomerDataProvider _customerDataProvider;

        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
            App.Current.Suspending += App_Suspending;
            _customerDataProvider = new CustomerDataProvider();
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            customerListView.Items.Clear();
            var customers = await _customerDataProvider.LoadCustomersAsync();
            foreach (var customer in customers)
            {
                customerListView.Items.Add(customer);
            }
        }

        private async void App_Suspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            await _customerDataProvider.SaveCustomerAsync(
                customerListView.Items.OfType<Customer>());
            deferral.Complete();
        }

        private void ButtonAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            var customer = new Customer { FirstName = "New" };
            customerListView.Items.Add(customer);
            customerListView.SelectedItem = customer;
        }

        private void ButtonDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            var customer = customerListView.SelectedItem as Customer;
            if (customer!=null)
                customerListView.Items.Remove(customer);
        } 

        private void ButtonMove_Click(object sender, RoutedEventArgs e)
        {
            //int column = (int)customerListGrid.GetValue(Grid.ColumnProperty);
            int column = Grid.GetColumn(customerListGrid);
            int newColumn = column == 0 ? 2 : 0;
            //customerListGrid.SetValue(Grid.ColumnProperty, newColumn);
            Grid.SetColumn(customerListGrid, newColumn);
            moveSymbolIcon.Symbol = newColumn == 0 ? Symbol.Forward : Symbol.Back;
        }

        private void customerListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var customer = customerListView.SelectedItem as Customer;
            customerDetailControl.Customer = customer;
        }
    }
}