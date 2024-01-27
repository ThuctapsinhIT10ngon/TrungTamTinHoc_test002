using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
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

namespace TrungTamTinHoc.SINH_VIEN
{
    /// <summary>
    /// Interaction logic for infoSV_child.xaml
    /// </summary>
    public partial class infoSV_child : UserControl
    {
        public infoSV_child()
        {
            InitializeComponent();
            filldatato();
        }

        private void filldatato()
        {
            var connector_CSV = new MongoDBConnector(GlobalVariables.ConnectionMongo, GlobalVariables.NameDatabaseMongo, "SINH_VIEN");

            var filter = Builders<BsonDocument>.Filter.Eq("tai_khoan.user_name", GlobalVariables.UserName);
            var doc = connector_CSV.FindDocument(filter);

            txtHoten.Text = doc["thong_tin"]["ho_ten"].AsString;
            txtMasv.Text = doc["thong_tin"]["ma"].AsString;
            txtkhoa.Text = doc["thong_tin"]["khoa_daotao"].AsString;
            txtHedaotao.Text = doc["thong_tin"]["he_daotao"].AsString;
            txtCnghanh.Text = doc["thong_tin"]["chuyen_nganh"].AsString;
            dtpNgaysinh.SelectedDate = DateTime.ParseExact(doc["thong_tin"]["ngay_sinh"].AsString, "dd/MM/yyyy", CultureInfo.InvariantCulture).Date;
            string check = doc["thong_tin"]["gioi_tinh"].AsString;
            if (check == "Nam")
            {
                rbNam.IsChecked = true;
            }
            else
            {
                rbNu.IsChecked = true;
            }
            txtDiachi.Text = doc["thong_tin"]["dia_chi"].AsString;
            txtQuoctich.Text = doc["thong_tin"]["quoc_tich"].AsString;
            txtGmail.Text = doc["thong_tin"]["gmail"].AsString;
            txtSDT.Text = doc["thong_tin"]["sdt"].AsString;
        }

        private void Shape_MouseUp(object sender, MouseButtonEventArgs e)
        {
        }

        public string _gioitinh;

        private async void SuaThongTin_Click(object sender, RoutedEventArgs e)
        {
            pgbLoad.Visibility = Visibility.Visible;

            string _hoten = txtHoten.Text;
            string _khoa = txtkhoa.Text;
            string _hedaotao = txtHedaotao.Text;
            string _chuyennganh = txtCnghanh.Text;
            string _ngaysinh = dtpNgaysinh.SelectedDate.ToString();
            if (rbNam.IsChecked == true)
            {
                _gioitinh = "Nam";
            }
            else if (rbNu.IsChecked == true)
            {
                _gioitinh = "Nữ";
            }
            string _diachi = txtDiachi.Text; 
            string _quoctich = txtQuoctich.Text;
            string _gmail = txtGmail.Text;
            string _sdt = txtSDT.Text;

            await Task.Delay(1000);
            await Task.Run(() =>
                    {
                        var connector_CSV = new MongoDBConnector_1(GlobalVariables.ConnectionMongo, GlobalVariables.NameDatabaseMongo, "SINH_VIEN");

                        var filter = Builders<dynamic>.Filter.Eq("tai_khoan.user_name", GlobalVariables.UserName);

                        var update = Builders<dynamic>.Update
                            .Set("thong_tin.ho_ten", _hoten)
                            .Set("thong_tin.khoa_daotao", _khoa)
                            .Set("thong_tin.he_daotao", _hedaotao)
                            .Set("thong_tin.chuyen_nganh", _chuyennganh)
                            //.Set("thong_tin.ngay_sinh", _ngaysinh)
                            .Set("thong_tin.gioi_tinh", _gioitinh)
                            .Set("thong_tin.dia_chi", _diachi)
                            .Set("thong_tin.quoc_tich", _quoctich)
                            .Set("thong_tin.gmail", _gmail)
                            .Set("thong_tin.sdt", _sdt);
                        connector_CSV.Collection.UpdateOne(filter, update);
                        // Cập nhật UI từ UI thread
                        Dispatcher.Invoke(() =>
                                {
                                });
                    });
            pgbLoad.Visibility = Visibility.Collapsed;
        }

        private Button newButton;

        private void tglEditinfo_Click(object sender, RoutedEventArgs e)
        {
            if (tglEditinfo.IsChecked == true)
            {
                //tạo count = 0  cho phép nó chỉnh sửa 1 lân duy nhất rôi hỏi nó chắc chắn không nếu chắc thì đổi 
                //lấn sau sửa thi phải lên trường sửa
                MessageBoxResult dr = MessageBox.Show("Bạn muốn sửa thông tin cá nhân?", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (dr == MessageBoxResult.OK)
                {
                    if (newButton == null)
                    {
                        newButton = new Button();
                        newButton.Content = "Đồng ý";
                        newButton.FontSize = 11;
                        newButton.FontWeight = FontWeights.Bold;
                        newButton.Foreground = new SolidColorBrush(Colors.White);
                        VerticalAlignment = VerticalAlignment.Center;
                        newButton.Click += SuaThongTin_Click;
                        btnEdit_OK.Children.Add(newButton);
                    }

                    txtHoten.IsReadOnly = false;
                    txtHedaotao.IsReadOnly = false;
                    txtGmail.IsReadOnly = false;
                    txtDiachi.IsReadOnly = false;
                    txtCnghanh.IsReadOnly = false;
                    txtkhoa.IsReadOnly = false;
                    txtQuoctich.IsReadOnly = false;
                    txtSDT.IsReadOnly = false;

                    rbNam.IsEnabled = true;
                    rbNu.IsEnabled = true;
                    dtpNgaysinh.IsEnabled = true;
                }
            }
            else
            {
                if (newButton != null)
                {
                    btnEdit_OK.Children.Remove(newButton);
                    newButton = null;
                }

                txtHoten.IsReadOnly = true;
                txtHedaotao.IsReadOnly = true;
                txtGmail.IsReadOnly = true;
                txtDiachi.IsReadOnly = true;
                txtCnghanh.IsReadOnly = true;
                txtkhoa.IsReadOnly = true;
                txtQuoctich.IsReadOnly = true;
                txtSDT.IsReadOnly = true;

                rbNam.IsEnabled = false;
                rbNu.IsEnabled = false;
                dtpNgaysinh.IsEnabled = false;
            }
        }

        private void txtHoten_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}