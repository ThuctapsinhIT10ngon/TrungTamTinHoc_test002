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

namespace TrungTamTinHoc.GIANG_VIEN
{
    /// <summary>
    /// Interaction logic for infoGV_child.xaml
    /// </summary>
    public partial class infoGV_child : UserControl
    {
        public infoGV_child()
        {
            InitializeComponent();
        }

        private void Shape_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("AAa");
        }

        private void SuaThongTin_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You clicked the new button!");
        }

        private Button newButton;

        private void tglEditinfo_Click(object sender, RoutedEventArgs e)
        {
            if (tglEditinfo.IsChecked == true)
            {
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
    }
}