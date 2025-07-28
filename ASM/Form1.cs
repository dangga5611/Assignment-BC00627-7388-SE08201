using System.Diagnostics.Eventing.Reader;

namespace ASM
{
    public partial class Form1 : Form
    {
        const double ENVIRONMENT_PROTECTION_FEES = 0.1;
        const double VAT = 0.1;
        List<Invoice> invoices = new List<Invoice>();
        public Form1()
        {
            InitializeComponent();
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            string customerName = txtCustomerName.Text.Trim();
            string typeOfCustomer = cbTypeOfCustomer.Text.Trim();
            int numberOfPeople = 0;
            double lastMonth = 0.11111;
            double thisMonth = 0;

            if (customerName == "" || customerName == null)
            {
                MessageBox.Show("Please enter your customer name!!!", "Validation Error!", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else if (customerName == "" || typeOfCustomer == null)
            {
                MessageBox.Show("Please enter your customer name!!!", "Validation Error!", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else if (!double.TryParse(txtLastMonthWater.Text, out lastMonth) || lastMonth < 0)
            {
                MessageBox.Show("Please enter your last month's water meter!!!", "Validation Error!", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else if (!double.TryParse(txtThisMonthWater.Text, out thisMonth) || thisMonth < 0)
            {
                MessageBox.Show("Please enter your this month's water meter!!!", "Validation Error!", MessageBoxButtons.OK, MessageBoxIcon.None);
            }

            if (typeOfCustomer == "Household customer")
            {
                if (!int.TryParse(txtNumberOfPeople.Text, out numberOfPeople) || numberOfPeople < 1)
                {
                    MessageBox.Show("Please enter your number of people!!!", "Validation Error!", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
            }
            double bill = calculate(typeOfCustomer, numberOfPeople, lastMonth, thisMonth);
            double billWithEPF = (bill + bill * ENVIRONMENT_PROTECTION_FEES);
            double totalbill = billWithEPF + billWithEPF * VAT;

            ListViewItem itemBill = new ListViewItem(customerName);
            itemBill.SubItems.Add(typeOfCustomer);
            itemBill.SubItems.Add(numberOfPeople.ToString());
            itemBill.SubItems.Add(thisMonth.ToString());
            itemBill.SubItems.Add(lastMonth.ToString());
            itemBill.SubItems.Add((thisMonth - lastMonth).ToString());
            itemBill.SubItems.Add(totalbill.ToString());

            lvWaterBill.Items.Add(itemBill);
            Invoice invoice = new Invoice(customerName, typeOfCustomer, numberOfPeople, thisMonth, lastMonth, thisMonth - lastMonth, totalbill);
            invoices.Add(invoice);

        }

        private double calculate(string? typeOfCustomer, int numberOfPeople, double lastMonth, double thisMonth)
        {
            double totalMoney = 0;
            double consumption = thisMonth - lastMonth; // so nuoc da su dung trong thang

            switch (typeOfCustomer)
            {
                case "Household customer":
                    double avgConsumption = consumption / numberOfPeople;
                    if (avgConsumption <= 10)
                    {
                        totalMoney = 5973 * avgConsumption * numberOfPeople;
                    }
                    else if (avgConsumption > 10 && avgConsumption <= 20)
                    {
                        totalMoney = 5973 * 10 * numberOfPeople + (avgConsumption - 10) * 7052 * numberOfPeople;
                    }
                    else if (avgConsumption > 20 && avgConsumption <= 30)
                    {
                        totalMoney = 5973 * 10 * numberOfPeople + 7052 * 10 * numberOfPeople + (avgConsumption - 20) * 8699 * numberOfPeople;
                    }
                    else
                    {
                        totalMoney = 5973 * 10 * numberOfPeople + 7052 * 10 * numberOfPeople + 8699 * 10 * numberOfPeople + (avgConsumption - 30) * 15929 * numberOfPeople;
                    }
                    break;
                case "Administrative agency, public services":
                    totalMoney = consumption * 9955;
                    break;
                case "Production units":
                    totalMoney = consumption * 11615;
                    break;
                case "Business services":
                    totalMoney = consumption * 22068;
                    break;
            }
            return totalMoney;
        }

        private void txtTypeOfCustomer_TextChanged(object sender, EventArgs e)
        {
            string typeOfCustomer = cbTypeOfCustomer.Text.Trim();
            if (typeOfCustomer == "Household customer")
            {
                txtNumberOfPeople.Enabled = true;
            }
            else
            {
                txtNumberOfPeople.Enabled = false;
            }

        }


        private void cboSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                string sortBy = cboSort.Text;
                switch (sortBy)
                {
                    case "Total Bill (Small To Large)":
                        for (int i = 0; i < invoices.Count - 1; i++)
                        {
                            for (int j = i + 1; j < invoices.Count; j++)
                            {
                                if (invoices[i].TotalBill > invoices[j].TotalBill)
                                {
                                    Invoice temInvocie = invoices[i];
                                    invoices[i] = invoices[j];
                                    invoices[j] = temInvocie;
                                }
                            }
                        }
                        break;
                    case "Total Bill (Large To Small)":
                        for (int i = 0; i < invoices.Count - 1; i++)
                        {
                            for (int j = i + 1; j < invoices.Count; j++)
                            {
                                if (invoices[i].TotalBill < invoices[j].TotalBill)
                                {
                                    Invoice temInvocie = invoices[i];
                                    invoices[i] = invoices[j];
                                    invoices[j] = temInvocie;
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
                lvWaterBill.Items.Clear();
                foreach (Invoice invoice in invoices)
                {
                    ListViewItem itemBill = new ListViewItem(invoice.CustomerName);
                    itemBill.SubItems.Add(invoice.TypeOfCustomer);
                    itemBill.SubItems.Add(invoice.NumberOfPeople.ToString());
                    itemBill.SubItems.Add(invoice.ThisMonthWaterMeter.ToString());
                    itemBill.SubItems.Add(invoice.LastMonthWaterMeter.ToString());
                    itemBill.SubItems.Add(invoice.Consumption.ToString());
                    itemBill.SubItems.Add(invoice.TotalBill.ToString());
                    lvWaterBill.Items.Add(itemBill);
                }
            }
        }
            

        private void Form1_Load(object sender, EventArgs e)
        {
            lvWaterBill.View = View.Details;
            lvWaterBill.Columns.Add("Customer Name", 200);
            lvWaterBill.Columns.Add("Type Of Customer", 200);
            lvWaterBill.Columns.Add("Number Of People", 50);
            lvWaterBill.Columns.Add("This Month's Water Meter", 200);
            lvWaterBill.Columns.Add("Last Month's Water Meter", 200);
            lvWaterBill.Columns.Add("Consumption", 200);
            lvWaterBill.Columns.Add("Total Bill", 200);
        }

        private void cbTypeOfCustomer_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string typeOfCustomer = cbTypeOfCustomer.Text.Trim();
            if (typeOfCustomer == "Household customer")
            {
                txtNumberOfPeople.Enabled = true;
            }
            else
            {
                txtNumberOfPeople.Enabled = false;

            }
        }
        public class Invoice
        {
            public Invoice(string customerName, string typeOfCustomer, int numberOfPeople, double thisMonth, double lastMonth, double consumption, double totalBill)
            {
                this.CustomerName = customerName;
                this.TypeOfCustomer = typeOfCustomer;
                this.NumberOfPeople = numberOfPeople;
                this.ThisMonthWaterMeter = thisMonth;
                this.LastMonthWaterMeter = lastMonth;
                this.Consumption = consumption;
                this.TotalBill = totalBill;
            }

            public string CustomerName { get; set; }
            public string TypeOfCustomer { get; set; }
            public int NumberOfPeople { get; set; }
            public double ThisMonthWaterMeter { get; set; }
            public double LastMonthWaterMeter { get; set; }
            public double Consumption { get; set; }
            public double TotalBill { get; set; }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();
            lvWaterBill.Items.Clear();
            if (search == "" || search == null)
            {
                foreach (Invoice invoice in invoices)
                {
                    ListViewItem itemBill = new ListViewItem(invoice.CustomerName);
                    itemBill.SubItems.Add(invoice.TypeOfCustomer);
                    itemBill.SubItems.Add(invoice.NumberOfPeople.ToString());
                    itemBill.SubItems.Add(invoice.ThisMonthWaterMeter.ToString());
                    itemBill.SubItems.Add(invoice.LastMonthWaterMeter.ToString());
                    itemBill.SubItems.Add(invoice.Consumption.ToString());
                    itemBill.SubItems.Add(invoice.TotalBill.ToString());

                    lvWaterBill.Items.Add(itemBill);
                }
            }
            else
            {
                foreach (Invoice invoice in invoices)
                {
                    if (invoice.CustomerName.Contains(search))
                    {
                        ListViewItem itemBill = new ListViewItem(invoice.CustomerName);
                        itemBill.SubItems.Add(invoice.TypeOfCustomer);
                        itemBill.SubItems.Add(invoice.NumberOfPeople.ToString());
                        itemBill.SubItems.Add(invoice.ThisMonthWaterMeter.ToString());
                        itemBill.SubItems.Add(invoice.LastMonthWaterMeter.ToString());
                        itemBill.SubItems.Add(invoice.Consumption.ToString());
                        itemBill.SubItems.Add(invoice.TotalBill.ToString());

                        lvWaterBill.Items.Add(itemBill);
                    }
                }
            }
        }
        private void lvWaterBill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            lvWaterBill.View = View.Details;
            lvWaterBill.Columns.Add("Customer Name", 200);
            lvWaterBill.Columns.Add("Type Of Customer", 200);
            lvWaterBill.Columns.Add("Number Of People", 50);
            lvWaterBill.Columns.Add("This Month's Water Meter", 200);
            lvWaterBill.Columns.Add("Last Month's Water Meter", 200);
            lvWaterBill.Columns.Add("Consumption", 200);
            lvWaterBill.Columns.Add("Total Bill", 200);
        }
    }

    public class Invoice
    {
        public Invoice(string CustomerName, string typeOfCustomer, int numberOfPeople, double thisMonth, double lastMonth, double consumption, double totalBill)
        {

        }



        public string CustomerName { get; set; }
        public string TypeOfCustomer { get; set; }
        public int NumberOfPeople { get; set; }
        public double ThisMonthWaterMeter { get; set; }
        public double LastmonthWaterMeter { get; set; }
        public double Consumption { get; set; }
        public double TotalBill { get; set; }

    }
}

       
    


   
