namespace WiredBrainCoffee.CustomersApp.Model
{
    public static class CustomerConverter
    {
        public static Customer CreateCustomerFromString(string inputString)
        {
            string[] values = inputString.Split(',');
            return new Customer
            {
                FirstName = values[0].Trim(),
                LastName = values[1].Trim(),
                IsDeveloper = bool.Parse(values[2].Trim())
            };
        }
    }
}
