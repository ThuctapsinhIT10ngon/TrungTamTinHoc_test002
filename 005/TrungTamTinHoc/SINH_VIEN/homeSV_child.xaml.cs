using Microsoft.Win32;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
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
    /// Interaction logic for homeSV_child.xaml
    /// </summary>
    public partial class homeSV_child : UserControl
    {
        public homeSV_child()
        {
            InitializeComponent();
            filldata();
            DrawChart();
        }

        private void DrawChart()
        {
        }

        private void filldata()
        {
            var connector_CSV = new MongoDBConnector(GlobalVariables.ConnectionMongo, GlobalVariables.NameDatabaseMongo, "SINH_VIEN");

            var filter = Builders<BsonDocument>.Filter.Eq("tai_khoan.user_name", GlobalVariables.UserName);

            var document = connector_CSV.FindDocument(filter);

            txtHoTen.Text = document["thong_tin"]["ho_ten"].AsString;
            txtMssv.Text = document["thong_tin"]["ma"].AsString;
            txtKhoadt.Text = document["thong_tin"]["khoa_daotao"].AsString;
            txtHedaotao.Text = document["thong_tin"]["he_daotao"].AsString;
            txtCNganh.Text = document["thong_tin"]["chuyen_nganh"].AsString;
            txtNgaysinh.Text = document["thong_tin"]["ngay_sinh"].AsString;
            txtGtinh.Text = document["thong_tin"]["gioi_tinh"].AsString;
            txtDiachi.Text = document["thong_tin"]["dia_chi"].AsString;
            txtQuoctich.Text = document["thong_tin"]["quoc_tich"].AsString;
            txtGmail.Text = document["thong_tin"]["gmail"].AsString;
            txtSdt.Text = document["thong_tin"]["sdt"].AsString;
        }

        private void fload_imagge()
        {
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        }
    }
}