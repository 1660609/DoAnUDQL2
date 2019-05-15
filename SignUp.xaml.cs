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

namespace TabMenu
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
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
            pwb1.Password = string.Empty;
            txb2.Text = string.Empty;
        }

        private void ButtonSignup_Click(object sender, RoutedEventArgs e)
        {
            if(txb1.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập Email !");
                txb1.Focus();
            }
            else if (!Regex.IsMatch(txb1.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                MessageBox.Show("Email không hợp lệ!");
                txb1.Select(0, txb1.Text.Length);
                txb1.Focus();
            }
            else
            {
                string email = txb1.Text;
                string password = pwb1.Password;
                string username = txb2.Text;
                if(pwb1.Password.Length==0)
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu!");
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
}
