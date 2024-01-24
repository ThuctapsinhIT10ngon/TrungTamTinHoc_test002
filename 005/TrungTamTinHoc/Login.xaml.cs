using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TrungTamTinHoc.GIANG_VIEN;
using TrungTamTinHoc.SINH_VIEN;

namespace TrungTamTinHoc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void hplkPass_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("http://www.google.com");
        }

        private void Grid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dr = MessageBox.Show("Thoát?", "Thông báo", MessageBoxButton.OKCancel);
            if (dr == MessageBoxResult.OK)
            {
                Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text == "sinhvien" && txtUserpass.Password == "123")
            {
                SV_home homeSV = new SV_home();
                this.Hide();
                homeSV.Show();
            }
            else if (txtUsername.Text == "giangvien" && txtUserpass.Password == "123")
            {
                if (cbGiangvien.IsChecked == true)
                {
                    GV_home homeGV = new GV_home();
                    this.Hide();
                    homeGV.Show();
                }
            }
        }
    }
}