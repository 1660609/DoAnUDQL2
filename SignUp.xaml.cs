using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace TabMenu
{

    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        private int _errors = 0;
        private Employee _employee = new Employee();
        
        public SignUp()
        {
            InitializeComponent();
            grid_EmployeeData.DataContext = _employee;
            
        }

        private void Confirm_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _errors == 0;
            e.Handled = true;
        }

        private void Confirm_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _employee = new Employee();
            grid_EmployeeData.DataContext = _employee;
            e.Handled = true;
        }

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _errors++;
            else
                _errors--;
        }

        public class Employee : IDataErrorInfo
        {
            private Regex emailRegex = new Regex(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$");
            public string password { get; set; }

            public string username { get; set; }
           

            public string Email { get; set; }
           

            private bool IsValidEmailAddress
            {
                get { return emailRegex.IsMatch(Email); }
            }



            public string Error
            {
                get { throw new NotImplementedException(); }
            }

            public string this[string columnName]
            {
                get
                {
                    string result = null;
                    if (columnName == "Email")
                    {
                        if (string.IsNullOrWhiteSpace(Email) || !IsValidEmailAddress)
                            result = "Vui lòng nhập đúng thông tin Email, ví dụ:tung1998@gmail.com";
                    }
                    if (columnName == "password")
                    {
                        if (string.IsNullOrEmpty(password) || password.Length < 5)
                            result = "Vui lòng nhập mật khẩu từ 5 kí tự trở lên";
                    }
                    if (columnName == "username")
                    {
                        if (string.IsNullOrEmpty(username) || username.Length < 3)
                            result = "Vui lòng nhập tên người dùng từ 5 kí tự trở lên";
                    }
                    return result;
                }
            }

        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Login LoginWindow = new Login();
            LoginWindow.Show();
            Close();
        }

        private void btnHome(object sender, RoutedEventArgs e)
        {
            MainWindow HOME = new MainWindow();
            HOME.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txb1.Text = string.Empty;
            pwb1.Text = string.Empty;
            txb2.Text = string.Empty;
        }

        private void ButtonSignup_Click(object sender, RoutedEventArgs e)
        {
            if(txb1.Text.Length == 0)
            {
                //MessageBox.Show("Vui lòng nhập Email !");
                txb1.Focus();
            }
            else if (!Regex.IsMatch(txb1.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                //MessageBox.Show("Email không hợp lệ!");
              
                txb1.Select(0, txb1.Text.Length);
                txb1.Focus();
            }
            else
            {
                string email = txb1.Text;
                string password = pwb1.Text;
                string username = txb2.Text;
                if (pwb1.Text.Length == 0)
                {
                    //MessageBox.Show("Vui lòng nhập mật khẩu!");
                    pwb1.Focus();
                }
                else
                {
                    SqlConnection con= new SqlConnection("Data Source=DESKTOP-PGNO1ME\\SQLEXPRESS;Initial Catalog=QLVD;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into USER_(EMAIL,USERNAME,PASS,COIN,LOAI) values('" + email + "','" + username + "', '" + password + "',100,2)", con);
                    cmd.CommandType=CommandType.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Bạn đã tạo tài khoản thành công");
                    Login LoginWindow = new Login();
                    LoginWindow.Show();
                    Close();
                }
            }
        }


    }




    public static class PasswordHelper
    {
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached("Password",
            typeof(string), typeof(PasswordHelper),
            new FrameworkPropertyMetadata(string.Empty, OnPasswordPropertyChanged));

        public static readonly DependencyProperty AttachProperty =
            DependencyProperty.RegisterAttached("Attach",
            typeof(bool), typeof(PasswordHelper), new PropertyMetadata(false, Attach));

        private static readonly DependencyProperty IsUpdatingProperty =
           DependencyProperty.RegisterAttached("IsUpdating", typeof(bool),
           typeof(PasswordHelper));


        public static void SetAttach(DependencyObject dp, bool value)
        {
            dp.SetValue(AttachProperty, value);
        }

        public static bool GetAttach(DependencyObject dp)
        {
            return (bool)dp.GetValue(AttachProperty);
        }

        public static string GetPassword(DependencyObject dp)
        {
            return (string)dp.GetValue(PasswordProperty);
        }

        public static void SetPassword(DependencyObject dp, string value)
        {
            dp.SetValue(PasswordProperty, value);
        }

        private static bool GetIsUpdating(DependencyObject dp)
        {
            return (bool)dp.GetValue(IsUpdatingProperty);
        }

        private static void SetIsUpdating(DependencyObject dp, bool value)
        {
            dp.SetValue(IsUpdatingProperty, value);
        }

        private static void OnPasswordPropertyChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            passwordBox.PasswordChanged -= PasswordChanged;

            if (!(bool)GetIsUpdating(passwordBox))
            {
                passwordBox.Password = (string)e.NewValue;
            }
            passwordBox.PasswordChanged += PasswordChanged;
        }

        private static void Attach(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;

            if (passwordBox == null)
                return;

            if ((bool)e.OldValue)
            {
                passwordBox.PasswordChanged -= PasswordChanged;
            }

            if ((bool)e.NewValue)
            {
                passwordBox.PasswordChanged += PasswordChanged;
            }
        }

        private static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            SetIsUpdating(passwordBox, true);
            SetPassword(passwordBox, passwordBox.Password);
            SetIsUpdating(passwordBox, false);
        }
    }
}
