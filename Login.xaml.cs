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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        public Login()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SignUp SignUpWindow = new SignUp();
            SignUpWindow.Show();
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
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            if(txb1.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập Email!");
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
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-PGNO1ME\\SQLEXPRESS;Initial Catalog=QLVD;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from USER_ where EMAIL='"+ email +"' and PASS='"+ password +"'",con);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                if(dataset.Tables[0].Rows.Count >0)
                {
                    if (dataset.Tables[0].Rows[0]["LOAI"].ToString().Equals("1")) {
                        MessageBox.Show("Đăng nhập thành công");
                        Admin wd = new Admin();
                        wd.TextBlockName.Header = dataset.Tables[0].Rows[0]["USERNAME"].ToString();
                        wd.Show();
                        Close();
                    }
                    else  {
                        MessageBox.Show("Đăng nhập thành công");
                        Customer wd = new Customer();
                        wd.TextBlockName.Text = dataset.Tables[0].Rows[0]["USERNAME"].ToString(); ;
                        wd.Show();
                        Close();
                    }
                }
                else {
                    MessageBox.Show("Tài Khoản hoặc Mật khẩu không đúng!");
                    pwb1.Password = string.Empty;
                }
            }
        }
    }
}
