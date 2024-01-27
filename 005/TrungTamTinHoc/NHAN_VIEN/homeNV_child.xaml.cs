using MongoDB.Bson;
using MongoDB.Driver;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TrungTamTinHoc.NHAN_VIEN
{
    /// <summary>
    /// Interaction logic for homeNV_child.xaml
    /// </summary>
    public partial class homeNV_child : UserControl
    {
        public homeNV_child()
        {
            InitializeComponent();
            filldata();
            //DrawChart();
        }

        private void DrawChart()
        {
            
        }

        private void filldata()
        {
            //txtNgaySinh.Text = document["thongtin"]["ngay_sinh"].AsString;
            //txtGioiTinh.Text = document["thongtin"]["gioi_tinh"].AsString;
            //txtGmail.Text = document["thongtin"]["gmail"].AsString;
            //txtDiaChi.Text = document["thongtin"]["dia_chi"].AsString;
            //txtQuocTich.Text = document["thongtin"]["quoc_tich"].AsString;
            //txtSDT.Text = document["thongtin"]["sdt"].AsString;
        }
    }

}
