using DataModel;
using LinqToDB;
using Microsoft.Win32;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace CourseApp
{
    /// <summary>
    /// Логика взаимодействия для WorkWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window
    {
        private string roleKey = "";
        private int userId;
        private StockDB stockContext = null;
        public WorkWindow(string roleKey, int userId)
        {
            InitializeComponent();
            this.roleKey = roleKey;
            this.userId = userId;
            confidantility();
            stockContext = new StockDB();
        }

        /// <summary>
        /// Видимость элементов на интерфейса по ролям (конфиденциальность)
        /// </summary>
        private void confidantility()
        {
            idCustomer.Visibility = roleKey.Equals("admin") ? Visibility.Visible : Visibility.Hidden;
            idUser.Visibility = roleKey.Equals("admin") ? Visibility.Visible : Visibility.Hidden;
            idProduct.Visibility = roleKey.Equals("admin") ? Visibility.Visible : Visibility.Hidden;
            idStock.Visibility = roleKey.Equals("admin") ? Visibility.Visible : Visibility.Hidden;
            labelExpenditureReceiptDate.Visibility = !roleKey.Equals("manager") ? Visibility.Visible : Visibility.Hidden;
            datePickerExpenditureReceiptDate.Visibility = !roleKey.Equals("manager") ? Visibility.Visible : Visibility.Hidden;
            labelExpenditureReceiptProduct.Visibility = !roleKey.Equals("manager") ? Visibility.Visible : Visibility.Hidden;
            comboBoxExpenditureReceiptProduct.Visibility = !roleKey.Equals("manager") ? Visibility.Visible : Visibility.Hidden;
            labelExpenditureReceiptStock.Visibility = !roleKey.Equals("manager") ? Visibility.Visible : Visibility.Hidden;
            labelExpenditureReceiptCompany.Visibility = !roleKey.Equals("manager") ? Visibility.Visible : Visibility.Hidden;
            comboBoxExpenditureReceiptCompany.Visibility = !roleKey.Equals("manager") ? Visibility.Visible : Visibility.Hidden;
            comboBoxExpenditureReceiptStock.Visibility = !roleKey.Equals("manager") ? Visibility.Visible : Visibility.Hidden;
            labelExpenditureReceiptCount.Visibility = !roleKey.Equals("manager") ? Visibility.Visible : Visibility.Hidden;
            textBoxExpenditureReceiptCount.Visibility = !roleKey.Equals("manager") ? Visibility.Visible : Visibility.Hidden;
            labelExpenditureReceiptPrice.Visibility = !roleKey.Equals("manager") ? Visibility.Visible : Visibility.Hidden;
            textBoxExpenditureReceiptPrice.Visibility = !roleKey.Equals("manager") ? Visibility.Visible : Visibility.Hidden;
            labelExpenditureReceiptOperation.Visibility = !roleKey.Equals("manager") ? Visibility.Visible : Visibility.Hidden;
            comboBoxExpenditureReceiptOperation.Visibility = !roleKey.Equals("manager") ? Visibility.Visible : Visibility.Hidden;
            buttonExpenditureReceiptSave.Visibility = !roleKey.Equals("manager") ? Visibility.Visible : Visibility.Hidden;
        }

        private List<Customer> customers = null;
        private Customer selectedCustomer = null;

        private List<User> users = null;
        private User selectedUser = null;
        private List<Role> roles = null;

        private List<Product> products = null;
        private Product selectedProduct = null;

        private List<Stock> stocks = null;
        private Stock selectedStock = null;

        private List<ReceiptInvoice> receiptInvoices = null;
     
        private List<ExpenditureInvoice> expenditureInvoices = null;

        private void IdCustomer_MouseEnter(object sender, MouseEventArgs e)
        {
            loadCustomerData();
        }

        private void ButtonCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCustomer != null)
            {
                stockContext.Customers
                    .Where(p => p.CustomerId == selectedCustomer.CustomerId)
                    .Set(p => p.CustomerName, textBoxCustomerName.Text)
                    .Set(p => p.Description, textBoxCustomerDescription.Text)
                    .Update();
                selectedCustomer = null;
                textBoxCustomerName.Text = "";
                textBoxCustomerDescription.Text = "";
            }
            else
            {
                stockContext.Customers
                   .Value(p => p.CustomerName, textBoxCustomerName.Text)
                   .Value(p => p.Description, textBoxCustomerDescription.Text)
                   .Insert();
                textBoxCustomerName.Text = "";
                textBoxCustomerDescription.Text = "";
            }
            loadCustomerData();
        }

        private void DataGridCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridCustomer.SelectedItem != null)
            {
                selectedCustomer = (Customer)dataGridCustomer.SelectedItem;
                textBoxCustomerName.Text = selectedCustomer.CustomerName;
                textBoxCustomerDescription.Text = selectedCustomer.Description;
            }
        }

        private void ButtonCustomerClear_Click(object sender, RoutedEventArgs e)
        {
            selectedCustomer = null;
            textBoxCustomerName.Text = "";
            textBoxCustomerDescription.Text = "";
        }

        private void loadCustomerData()
        {
            var customerObj =
               from customers in stockContext.Customers
               orderby customers.CustomerId
               select customers;
            customers = customerObj.ToList();
            dataGridCustomer.ItemsSource = customers;
        }

        private void IdUser_MouseEnter(object sender, MouseEventArgs e)
        {
            loadUserData();
        }

        private void loadUserData()
        {
            var userObj =
               from users in stockContext.Users
               orderby users.UserId
               select users;
            users = userObj.ToList();
            dataGridUser.ItemsSource = users;
            listBoxUserRole.ItemsSource = from keys in loadRoleData()
                select keys.RoleKey;
        }

        private List<Role> loadRoleData()
        {
            var roleObj =
               from roles in stockContext.Roles
               select roles;
            roles = roleObj.ToList();
            return roles;
        }

        private void ButtonUser_Click(object sender, RoutedEventArgs e)
        {
            if (selectedUser != null)
            {
                stockContext.Users
                    .Where(p => p.UserId == selectedUser.UserId)
                    .Set(p => p.UserName, textBoxUserName.Text)
                    .Set(p => p.FullName, textBoxUserFullName.Text)
                    .Set(p => p.UserPass, passwordBoxUser.Password)
                    .Set(p => p.RoleKey, listBoxUserRole.SelectedItem)
                    .Update();
                selectedUser = null;
                textBoxUserName.Text = "";
                textBoxUserFullName.Text = "";
                passwordBoxUser.Password = "";
            }
            else
            {
                stockContext.Users
                   .Value(p => p.UserName, textBoxUserName.Text)
                   .Value(p => p.FullName, textBoxUserFullName.Text)
                   .Value(p => p.UserPass, passwordBoxUser.Password)
                   .Value(p => p.RoleKey, listBoxUserRole.SelectedItem)
                   .Insert();
                selectedUser = null;
                textBoxUserName.Text = "";
                textBoxUserFullName.Text = "";
                passwordBoxUser.Password = "";
            }
            loadUserData();
        }

        private void DataGridUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridUser.SelectedItem != null)
            {
                selectedUser = (User)dataGridUser.SelectedItem;
                textBoxUserName.Text = selectedUser.UserName;
                textBoxUserFullName.Text = selectedUser.FullName;
                passwordBoxUser.Password = selectedUser.UserPass;
                listBoxUserRole.SelectedItem = selectedUser.RoleKey;
            }
        }

        private void ButtonUserClear_Click(object sender, RoutedEventArgs e)
        {
            selectedUser = null;
            textBoxUserName.Text = "";
            textBoxUserFullName.Text = "";
            passwordBoxUser.Password = "";
        }

        private void loadProductData()
        {
            var productObj =
               from products in stockContext.Products
               orderby products.ProductId
               select products;
            products = productObj.ToList();
            dataGridProduct.ItemsSource = products;
        }

        private void ButtonProductClear_Click(object sender, RoutedEventArgs e)
        {
            selectedProduct = null;
            textBoxProductName.Text = "";
        }

        private void ButtonProduct_Click(object sender, RoutedEventArgs e)
        {
            if (selectedProduct != null)
            {
                stockContext.Products
                    .Where(p => p.ProductId == selectedProduct.ProductId)
                    .Set(p => p.ProductName, textBoxProductName.Text)
                    .Update();
                selectedProduct = null;
                textBoxProductName.Text = "";
            }
            else
            {
                stockContext.Products
                   .Value(p => p.ProductName, textBoxProductName.Text)
                   .Insert();
                selectedProduct = null;
                textBoxProductName.Text = "";
            }
            loadProductData();
        }

        private void DataGridProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridProduct.SelectedItem != null)
            {
                selectedProduct = (Product)dataGridProduct.SelectedItem;
                textBoxProductName.Text = selectedProduct.ProductName;
            }
        }

        private void IdProduct_MouseEnter(object sender, MouseEventArgs e)
        {
            loadProductData();
        }

        private void IdStock_MouseEnter(object sender, MouseEventArgs e)
        {
            loadStockData();
            loadStokerUserData();
            listBoxUserId.ItemsSource = from user in users
                select user.UserName;
        }

        private void loadStockData()
        {
            var stockObj =
               from stocks in stockContext.Stocks
               orderby stocks.StockId
               select stocks;
            stocks = stockObj.ToList();
            dataGridStock.ItemsSource = stocks;
        }

        private void loadStokerUserData()
        {
            var userObj =
               from users in stockContext.Users
               orderby users.UserId
               where users.RoleKey == "stoker"
               select users;
            users = userObj.ToList();
        }

        private void DataGridStock_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridStock.SelectedItem != null)
            {
                selectedStock = (Stock)dataGridStock.SelectedItem;
                textBoxStockName.Text = selectedStock.StockName;
                textBoxStockDescription.Text = selectedStock.Description;
                textBoxStockMarkup.Text = selectedStock.Markup.ToString();
                listBoxUserId.SelectedItem = (from user in users
                    where user.UserId == selectedStock.UserId
                    select user.UserName).ToList()[0];
            }
        }

        private void ButtonStockClear_Click(object sender, RoutedEventArgs e)
        {
            selectedStock = null;
            textBoxStockName.Text = "";
            textBoxStockDescription.Text = "";
            textBoxStockMarkup.Text = "";
        }

        private void ButtonStockSave_Click(object sender, RoutedEventArgs e)
        {
            if (checkMarkup() && listBoxUserId.SelectedItem != null)
            {
                int userID = (from user in users
                              where user.UserName == listBoxUserId.SelectedItem.ToString()
                              select user.UserId).ToList()[0];
                if (selectedStock != null)
                {
                    stockContext.Stocks
                        .Where(p => p.StockId == selectedStock.StockId)
                        .Set(p => p.StockName, textBoxStockName.Text)
                        .Set(p => p.Description, textBoxStockDescription.Text)
                        .Set(p => p.Markup, float.Parse(textBoxStockMarkup.Text))
                        .Set(p => p.UserId, userID)
                        .Update();
                    selectedStock = null;
                    textBoxStockName.Text = "";
                    textBoxStockDescription.Text = "";
                    textBoxStockMarkup.Text = "";
                }
                else
                {
                    stockContext.Stocks
                        .Value(p => p.StockName, textBoxStockName.Text)
                        .Value(p => p.Description, textBoxStockDescription.Text)
                        .Value(p => p.Markup, float.Parse(textBoxStockMarkup.Text))
                        .Value(p => p.UserId, userID)
                        .Insert();
                    selectedStock = null;
                    textBoxStockName.Text = "";
                    textBoxStockDescription.Text = "";
                    textBoxStockMarkup.Text = "";
                }
                loadStockData();
            }
        }

        private void IdReceiptInvoices_MouseEnter(object sender, MouseEventArgs e)
        {
            loadReceiptInvoicesData();
        }

        private void loadReceiptInvoicesData()
        {
            var receiptInvoicesObj =
               from receiptInvoice in stockContext.ReceiptInvoices
               orderby receiptInvoice.ReceiptInvoiceId
               select receiptInvoice;
            receiptInvoices = receiptInvoicesObj.ToList();
            foreach (var item in receiptInvoices)
            {
                
                item.Stock = (from stock in stockContext.Stocks
                              where stock.StockId == item.StockId
                              select stock).ToList()[0];
                item.Customer = (from customer in stockContext.Customers
                                 where customer.CustomerId == item.CustomerId
                              select customer).ToList()[0];
                item.Product = (from product in stockContext.Products
                                where product.ProductId == item.ProductId
                              select product).ToList()[0];
            }
            dataGridReceiptInvoicesk.ItemsSource = receiptInvoices;
        }

        private void IdExpenditureInvoices_MouseEnter(object sender, MouseEventArgs e)
        {
            loadExpenditureInvoicesData();
        }

        private void loadExpenditureInvoicesData()
        {
            var expenditureInvoicesObj =
              from expenditureInvoice in stockContext.ExpenditureInvoices
              orderby expenditureInvoice.ExpenditureInvoiceId
              select expenditureInvoice;
            expenditureInvoices = expenditureInvoicesObj.ToList();
            foreach (var item in expenditureInvoices)
            {

                item.Stock = (from stock in stockContext.Stocks
                              where stock.StockId == item.StockId
                              select stock).ToList()[0];
                item.Customer = (from customer in stockContext.Customers
                                 where customer.CustomerId == item.CustomerId
                                 select customer).ToList()[0];
                item.Product = (from product in stockContext.Products
                                where product.ProductId == item.ProductId
                                select product).ToList()[0];
            }
            dataGridExpenditureInvoices.ItemsSource = expenditureInvoices;
        }

        private void IdExpenditureReceipt_MouseEnter(object sender, MouseEventArgs e)
        {
            initControls();
        }

        private void ButtonExpenditureReceiptSave_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxExpenditureReceiptProduct.SelectedItem == null ||
                    comboBoxExpenditureReceiptStock.SelectedItem == null ||
                    comboBoxExpenditureReceiptCompany.SelectedItem == null ||
                    textBoxExpenditureReceiptCount.Text == "" ||
                    textBoxExpenditureReceiptPrice.Text == "")
            {
                MessageBox.Show("Заполние все поля.");
            }
            else if (comboBoxExpenditureReceiptOperation.SelectedItem == null)
            {
                MessageBox.Show("Выберите операцию!");
            }
            else if (comboBoxExpenditureReceiptOperation.SelectedItem.ToString() == "Приход")
            {
                stockContext.ReceiptInvoices
                     .Value(p => p.ReceiptInvoiceDate, (NpgsqlDate)datePickerExpenditureReceiptDate.DisplayDate)
                     .Value(p => p.ProductId, (from product in stockContext.Products
                                               where product.ProductName == comboBoxExpenditureReceiptProduct.SelectedItem.ToString()
                                               select product.ProductId).ToList()[0])
                     .Value(p => p.StockId, (from stock in stockContext.Stocks
                                             where stock.StockName == comboBoxExpenditureReceiptStock.SelectedItem.ToString()
                                             select stock.StockId).ToList()[0])
                     .Value(p => p.CustomerId, (from customer in stockContext.Customers
                                                where customer.CustomerName == comboBoxExpenditureReceiptCompany.SelectedItem.ToString()
                                                select customer.CustomerId).ToList()[0])
                     .Value(p => p.CountProduct, float.Parse(textBoxExpenditureReceiptCount.Text == "" ? "0" : textBoxExpenditureReceiptCount.Text))
                     .Value(p => p.PriceProduct, float.Parse(textBoxExpenditureReceiptPrice.Text == "" ? "0" : textBoxExpenditureReceiptPrice.Text))
                     .Insert();
                    textBoxExpenditureReceiptCount.Text = "0";
                    textBoxExpenditureReceiptPrice.Text = "0";
                    MessageBox.Show("Приход выполнен успешно.");

            }
            else if (comboBoxExpenditureReceiptOperation.SelectedItem.ToString() == "Отгрузка")
            {
                int productId = (from product in stockContext.Products
                                 where product.ProductName == comboBoxExpenditureReceiptProduct.SelectedItem.ToString()
                                 select product.ProductId).ToList()[0];
                int stockId = (from stock in stockContext.Stocks
                               where stock.StockName == comboBoxExpenditureReceiptStock.SelectedItem.ToString()
                               select stock.StockId).ToList()[0];
                float? countProductR = (from invoice in stockContext.ReceiptInvoices
                                       where invoice.StockId == stockId && invoice.ProductId == productId
                                       select invoice.CountProduct).Sum();
                float? countProductE = (from invoice in stockContext.ExpenditureInvoices
                                        where invoice.StockId == stockId && invoice.ProductId == productId
                                        select invoice.CountProduct).Sum();
                countProductE = countProductE == null ? 0 : countProductE;
                countProductR = countProductR == null ? 0 : countProductR;
                if (countProductR - countProductE - float.Parse(textBoxExpenditureReceiptCount.Text == "" ? "0" : textBoxExpenditureReceiptCount.Text) >= 0)
                {
                    stockContext.ExpenditureInvoices
                        .Value(p => p.ExpenditureInvoiceDate, (NpgsqlDate)datePickerExpenditureReceiptDate.DisplayDate)
                        .Value(p => p.ProductId, productId)
                        .Value(p => p.StockId, stockId)
                        .Value(p => p.CustomerId, (from customer in stockContext.Customers
                                                   where customer.CustomerName == comboBoxExpenditureReceiptCompany.SelectedItem.ToString()
                                                   select customer.CustomerId).ToList()[0])
                        .Value(p => p.CountProduct, float.Parse(textBoxExpenditureReceiptCount.Text == "" ? "0" : textBoxExpenditureReceiptCount.Text))
                        .Value(p => p.PriceProduct, float.Parse(textBoxExpenditureReceiptPrice.Text == "" ? "0" : textBoxExpenditureReceiptPrice.Text))
                        .Insert();
                        textBoxExpenditureReceiptCount.Text = "0";
                        textBoxExpenditureReceiptPrice.Text = "0";
                        MessageBox.Show("Отгрузка выполнена успешно.");
                }
                else
                {
                    MessageBox.Show("Недостаточно материала для отгрузки.");
                }
                initControls();
            }
        }

        private void initControls()
        {
            comboBoxExpenditureReceiptProduct.ItemsSource = (from product in stockContext.Products
                                                            select product.ProductName).ToList();
            if (roleKey.Equals("admin"))
            {
                comboBoxExpenditureReceiptStock.ItemsSource = (from stock in stockContext.Stocks
                                                               select stock.StockName).ToList();
            }
            else
            {
                comboBoxExpenditureReceiptStock.ItemsSource = (from stock in stockContext.Stocks
                                                               where stock.UserId == this.userId
                                                               select stock.StockName).ToList();
            }
            
            comboBoxExpenditureReceiptCompany.ItemsSource = (from customer in stockContext.Customers
                                                            select customer.CustomerName).ToList();
            comboBoxExpenditureReceiptOperation.ItemsSource = new List<string>() { "Приход", "Отгрузка" };
            comboBoxExpenditureReceiptStockC.ItemsSource = comboBoxExpenditureReceiptStock.ItemsSource;
        }

        private void ComboBoxExpenditureReceiptOperation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxExpenditureReceiptOperation.SelectedItem != null &&
                comboBoxExpenditureReceiptOperation.SelectedItem.ToString() == "Отгрузка")
            {
                textBoxExpenditureReceiptPrice.IsEnabled = false;
            } else
            {
                textBoxExpenditureReceiptPrice.IsEnabled = true;
            }
        }

        private void TextBoxExpenditureReceiptCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (comboBoxExpenditureReceiptOperation != null &&
                comboBoxExpenditureReceiptOperation.SelectedItem != null &&
                comboBoxExpenditureReceiptOperation.SelectedItem.ToString() == "Отгрузка" &&
                comboBoxExpenditureReceiptProduct.SelectedItem != null &&
                comboBoxExpenditureReceiptStock.SelectedItem != null)
            {
                int productId = (from product in stockContext.Products
                                 where product.ProductName == comboBoxExpenditureReceiptProduct.SelectedItem.ToString()
                                 select product.ProductId).ToList()[0];
                int stockId = (from stock in stockContext.Stocks
                               where stock.StockName == comboBoxExpenditureReceiptStock.SelectedItem.ToString()
                               select stock.StockId).ToList()[0];
                float? stockMarkup = (from stock in stockContext.Stocks
                                     where stock.StockId == stockId
                                     select stock.Markup).ToList()[0];
                float? avgPrice = (from invoice in stockContext.ReceiptInvoices
                                   where invoice.StockId == stockId && invoice.ProductId == productId
                                   select invoice.PriceProduct).Average();
                textBoxExpenditureReceiptPrice.Text = String.Format("{0:0.0}", (float.Parse(textBoxExpenditureReceiptCount.Text == "" ? "0" : textBoxExpenditureReceiptCount.Text) * (avgPrice + stockMarkup * avgPrice)).ToString());
            }
        }

        private string conn_path = "Host=localhost;Username=postgres;Password=admin;Database=Stock";
        private NpgsqlConnection connection = null;

        private void ButtonReportC_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxExpenditureReceiptStockC == null ||
                comboBoxExpenditureReceiptStockC.SelectedItem == null)
            {
                MessageBox.Show("Выберите склад");
            }
            else
            {
                connection = new NpgsqlConnection(conn_path);
                try
                {
                    connection.Open();
                    int stockId = (from stock in stockContext.Stocks
                                   where stock.StockName == comboBoxExpenditureReceiptStockC.SelectedItem.ToString()
                                   select stock.StockId).ToList()[0];
                    string query = "SELECT stocks.stock_name, products.product_name, sum(receipt_invoices.count_product)" +
                                    " FROM receipt_invoices" +
                                    " JOIN stocks ON stocks.stock_id = receipt_invoices.stock_id" +
                                    " JOIN products ON products.product_id = receipt_invoices.product_id" +
                                    " WHERE receipt_invoices.stock_id = " + stockId +
                                    " GROUP BY stocks.stock_name, products.product_name";

                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    NpgsqlDataReader reader = command.ExecuteReader();

                    XDocument xdoc = new XDocument();
                    XElement stocks = new XElement("Склады");
                   
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            XElement stock = new XElement("Склад"); 
                            XAttribute istockNameAttr = new XAttribute("Наименование", reader["stock_name"].ToString());
                            XElement istockProductElem = new XElement("Продукт", reader["product_name"].ToString());
                            XElement istockSumElem = new XElement("Количество", reader["sum"].ToString());
                            stock.Add(istockNameAttr);
                            stock.Add(istockProductElem);
                            stock.Add(istockSumElem);
                            stocks.Add(stock);
                        }
                        reader.Close();

                    }
                    xdoc.Add(stocks);
                    
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "XML-File | *.xml";
                    if (saveFileDialog.ShowDialog() == true)
                    {
                        xdoc.Save(saveFileDialog.FileName);
                        MessageBox.Show("Файл сохранен");
                    }
                }
                catch (NpgsqlException ex)
                {
                    
                }
            }
        }

        private void ButtonReportCA_Click(object sender, RoutedEventArgs e)
        {
            connection = new NpgsqlConnection(conn_path);
            try
            {
                connection.Open();
                string query = "SELECT stocks.stock_name, products.product_name, sum(receipt_invoices.count_product)" +
                                " FROM receipt_invoices" +
                                " JOIN stocks ON stocks.stock_id = receipt_invoices.stock_id" +
                                " JOIN products ON products.product_id = receipt_invoices.product_id" +
                                " GROUP BY stocks.stock_name, products.product_name";

                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataReader reader = command.ExecuteReader();

                XDocument xdoc = new XDocument();
                XElement stocks = new XElement("Склады");

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        XElement stock = new XElement("Склад");
                        XAttribute istockNameAttr = new XAttribute("Наименование", reader["stock_name"].ToString());
                        XElement istockProductElem = new XElement("Продукт", reader["product_name"].ToString());
                        XElement istockSumElem = new XElement("Количество", reader["sum"].ToString());
                        stock.Add(istockNameAttr);
                        stock.Add(istockProductElem);
                        stock.Add(istockSumElem);
                        stocks.Add(stock);
                    }
                    reader.Close();

                }
                xdoc.Add(stocks);

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "XML-File | *.xml";
                if (saveFileDialog.ShowDialog() == true)
                {
                    xdoc.Save(saveFileDialog.FileName);
                    MessageBox.Show("Файл сохранен");
                }
            }
            catch (NpgsqlException ex)
            {

            }
        }

        private void ButtonReportCK_Click(object sender, RoutedEventArgs e)
        {
            connection = new NpgsqlConnection(conn_path);
            try
            {
                string dataFrom = datePickerExpenditureReceiptDateFrom.DisplayDate.ToString("yyyy-MM-dd");
                string dataTo = datePickerExpenditureReceiptDateTo.DisplayDate.ToString("yyyy-MM-dd");

                connection.Open();
                string query = "SELECT stocks.stock_name, sum(expenditure_invoices.price_product * expenditure_invoices.count_product)" +
                                " FROM expenditure_invoices" +
                                " INNER JOIN stocks ON stocks.stock_id = expenditure_invoices.stock_id" +
                                " WHERE expenditure_invoice_date BETWEEN '" + dataFrom + "' AND '" + dataTo + "'" +
                                " GROUP BY stocks.stock_name";

                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataReader reader = command.ExecuteReader();

                XDocument xdoc = new XDocument();
                XElement stocks = new XElement("Склады");

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        XElement stock = new XElement("Склад");
                        XAttribute istockNameAttr = new XAttribute("Наименование", reader["stock_name"].ToString());
                        XElement istockPriceElem = new XElement("Прибыль", reader["sum"].ToString());
                        stock.Add(istockNameAttr);
                        stock.Add(istockPriceElem);
                        stocks.Add(stock);
                    }
                    reader.Close();

                }
                xdoc.Add(stocks);

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "XML-File | *.xml";
                if (saveFileDialog.ShowDialog() == true)
                {
                    xdoc.Save(saveFileDialog.FileName);
                    MessageBox.Show("Файл сохранен");
                }
            }
            catch (NpgsqlException ex)
            {
                
            }
        }

        private void ButtonReportCL_Click(object sender, RoutedEventArgs e)
        {
            connection = new NpgsqlConnection(conn_path);
            try
            {
                connection.Open();
                string query = "SELECT products.product_name, max(expenditure_invoices.price_product)" +
                                " FROM expenditure_invoices" +
                                " INNER JOIN products ON products.product_id = expenditure_invoices.product_id" +
                                " GROUP BY products.product_name";

                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataReader reader = command.ExecuteReader();

                XDocument xdoc = new XDocument();
                XElement products = new XElement("Прибыльный_Товар");

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        XElement product = new XElement("Товар");
                        XAttribute iproductNameAttr = new XAttribute("Наименование", reader["product_name"].ToString());
                        XElement iproductPriceElem = new XElement("Стоимость", reader["max"].ToString());
                        product.Add(iproductNameAttr);
                        product.Add(iproductPriceElem);
                        products.Add(product);
                    }
                    reader.Close();

                }
                xdoc.Add(products);

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "XML-File | *.xml";
                if (saveFileDialog.ShowDialog() == true)
                {
                    xdoc.Save(saveFileDialog.FileName);
                    MessageBox.Show("Файл сохранен");
                }
            }
            catch (NpgsqlException ex)
            {

            }
        }

        private void textBoxStockMarkup_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private bool checkMarkup()
        {
            int number = int.Parse(textBoxStockMarkup.Text);
            if (number < 10 || number > 25)
            {
                MessageBox.Show("Надбавка введена не верно (>= 10 и <= 25%");
                return false;
            }
            return true;
        }
    }
}
