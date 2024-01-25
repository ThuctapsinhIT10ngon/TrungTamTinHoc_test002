using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using MongoDB.Bson;
using MongoDB.Driver;
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
            mongodconnet();
        }

        private void mongodconnet()
        {
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

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Hiển thị hiệu ứng loading
            pgrLoading.Visibility = Visibility.Visible;

            string user_name = txtUsername.Text;
            string user_pass = txtUserpass.Password;
            // Thực hiện công việc nặng một cách bất đồng bộ
            await Task.Delay(5000);
            await Task.Run(() =>
            {
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("TrungTamTinHoc");
                var collection = database.GetCollection<BsonDocument>("SINH_VIEN");

                string role = "sinh_vien";
                var filter = Builders<BsonDocument>.Filter.And(
                             Builders<BsonDocument>.Filter.Eq("tai_khoan.user_name", user_name),
                             Builders<BsonDocument>.Filter.Eq("tai_khoan.user_pass", user_pass),
                             Builders<BsonDocument>.Filter.Eq("tai_khoan.role", role)
                );

                string role1 = "nhan_vien";
                var filter1 = Builders<BsonDocument>.Filter.And(
                             Builders<BsonDocument>.Filter.Eq("tai_khoan.user_name", user_name),
                             Builders<BsonDocument>.Filter.Eq("tai_khoan.user_pass", user_pass),
                             Builders<BsonDocument>.Filter.Eq("tai_khoan.role", role1)
                );

                var check_user = collection.Find(filter).FirstOrDefault();
                var check_user1 = collection.Find(filter1).FirstOrDefault();

                // Cập nhật UI từ UI thread
                Dispatcher.Invoke(() =>
                {
                    if (cbGiangvien.IsChecked == true)
                    {
                        MessageBox.Show("Đăng nhập giảng viên thành công");
                    }
                    else
                    {
                        if (check_user != null)
                        {
                            GlobalVariables.UserName = txtUsername.Text;
                            SV_home homeSV = new SV_home();
                            homeSV.Show();
                            this.Close();
                        }
                        else if (check_user1 != null)
                        {
                            MessageBox.Show("Thành công nhân viên");
                        }
                        else
                        {
                            MessageBox.Show("Sai");
                        }
                    }
                });
            });

            // Ẩn hiệu ứng loading
            pgrLoading.Visibility = Visibility.Collapsed;
        }
    }
}