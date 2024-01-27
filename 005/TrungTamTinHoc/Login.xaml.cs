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

            GlobalVariables.ConnectionMongo = "mongodb+srv://24nguyenphat00:27072004phatZ@cluster0.7pcqw0h.mongodb.net/";
            GlobalVariables.NameDatabaseMongo = "TrungTamTinHoc";
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
            await Task.Delay(2000);
            await Task.Run(() =>
            {
                var connector = new MongoDBConnector(GlobalVariables.ConnectionMongo, GlobalVariables.NameDatabaseMongo, "GIANG_VIEN");
                var connector1 = new MongoDBConnector(GlobalVariables.ConnectionMongo, GlobalVariables.NameDatabaseMongo, "SINH_VIEN");

                string role = "giang_vien";
                var filter_GV = Builders<BsonDocument>.Filter.And(
                             Builders<BsonDocument>.Filter.Eq("tai_khoan.user_name", user_name),
                             Builders<BsonDocument>.Filter.Eq("tai_khoan.user_pass", user_pass),
                             Builders<BsonDocument>.Filter.Eq("tai_khoan.role", role)
                );

                string role1 = "nhan_vien";
                var filter_NV = Builders<BsonDocument>.Filter.And(
                             Builders<BsonDocument>.Filter.Eq("tai_khoan.user_name", user_name),
                             Builders<BsonDocument>.Filter.Eq("tai_khoan.user_pass", user_pass),
                             Builders<BsonDocument>.Filter.Eq("tai_khoan.role", role1)
                );

                var filter_SV = Builders<BsonDocument>.Filter.And(
                              Builders<BsonDocument>.Filter.Eq("tai_khoan.user_name", user_name),
                              Builders<BsonDocument>.Filter.Eq("tai_khoan.user_pass", user_pass)
                );

                var check_userGV = connector.FindDocument(filter_GV);
                var check_userNV = connector.FindDocument(filter_NV);
                var check_userSV = connector1.FindDocument(filter_SV);

                // Cập nhật UI từ UI thread
                Dispatcher.Invoke(() =>
                {
                    if (cbGiangvien.IsChecked == true)
                    {
                        if (check_userGV != null)
                        {
                            MessageBox.Show("Đăng nhập giảng viên thành công");
                        }
                        else if (check_userNV != null)
                        {
                            GlobalVariables.UserName = txtUsername.Text;
                            NHAN_VIEN.NV_home homeNV = new NHAN_VIEN.NV_home();
                            homeNV.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng kiểm tra lại thông tin đăng nhập");
                        }
                    }
                    else
                    {
                        if (check_userSV != null)
                        {
                            GlobalVariables.UserName = txtUsername.Text;
                            SV_home homeSV = new SV_home();
                            homeSV.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng kiểm tra lại thông tin đăng nhập");
                        }
                    }
                });
            });

            // Ẩn hiệu ứng loading
            pgrLoading.Visibility = Visibility.Collapsed;
        }
    }
}