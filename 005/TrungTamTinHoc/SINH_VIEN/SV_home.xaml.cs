using MaterialDesignThemes.Wpf;
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
using System.Windows.Shapes;

namespace TrungTamTinHoc.SINH_VIEN
{
    /// <summary>
    /// Interaction logic for SV_home.xaml
    /// </summary>
    public partial class SV_home : Window
    {
        public SV_home()
        {
            InitializeComponent();
            filldata();
        }

        private void filldata()
        {
            txtTest.Text = GlobalVariables.UserName;
        }

        //Giao diện
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
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

        private StackPanel currentStackPanel = null;

        private void StackPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            var stackPanel = sender as StackPanel;
            if (stackPanel != currentStackPanel)
            {
                stackPanel.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0000FF"));
                var icon = stackPanel.Children.OfType<PackIcon>().FirstOrDefault();
                var text = stackPanel.Children.OfType<TextBlock>().FirstOrDefault();
                if (icon != null)
                    icon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF00"));
                if (text != null)
                    text.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF00"));
            }
        }

        private void StackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            var stackPanel = sender as StackPanel;
            if (stackPanel != currentStackPanel)
            {
                stackPanel.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0DC5FF"));
                var icon = stackPanel.Children.OfType<PackIcon>().FirstOrDefault();
                var text = stackPanel.Children.OfType<TextBlock>().FirstOrDefault();
                if (icon != null)
                    icon.Foreground = new SolidColorBrush(Colors.White);
                if (text != null)
                    text.Foreground = new SolidColorBrush(Colors.White);
            }
        }

        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var stackPanel = sender as StackPanel;
            if (currentStackPanel != null)
            {
                // Đặt màu sắc của StackPanel hiện tại về mặc định
                currentStackPanel.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0DC5FF"));
                var currentIcon = currentStackPanel.Children.OfType<PackIcon>().FirstOrDefault();
                var currentText = currentStackPanel.Children.OfType<TextBlock>().FirstOrDefault();
                if (currentIcon != null)
                    currentIcon.Foreground = new SolidColorBrush(Colors.White);
                if (currentText != null)
                    currentText.Foreground = new SolidColorBrush(Colors.White);
            }
            // Cập nhật StackPanel hiện tại và thay đổi màu sắc của nó
            currentStackPanel = stackPanel;
            currentStackPanel.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0000FF"));
            var icon = currentStackPanel.Children.OfType<PackIcon>().FirstOrDefault();
            var text = currentStackPanel.Children.OfType<TextBlock>().FirstOrDefault();
            if (icon != null)
                icon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF00"));
            if (text != null)
                text.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF00"));

            var stackName = sender as StackPanel;
            var stackspace = sender as StackPanel;
            switch (stackName.Name)
            {
                case "Stack_home":
                    if (stackspace != null)
                    {
                        space.Children.Remove(stackspace);
                        stackspace = null;

                        homeSV_child homeSV = new homeSV_child();
                        space.Children.Add(homeSV);
                    }
                    break;

                case "Stack_id":
                    if (stackspace != null)
                    {
                        space.Children.Remove(stackspace);
                        stackspace = null;

                        infoSV_child infoSV = new infoSV_child();
                        space.Children.Add(infoSV);
                    }
                    break;

                case "Stack_regi":
                    if (stackspace != null)
                    {
                        space.Children.Remove(stackspace);
                        stackspace = null;

                        regiSV_child register = new regiSV_child();
                        space.Children.Add(register);
                    }
                    break;

                case "Stack_study":
                    if (stackspace != null)
                    {
                        space.Children.Remove(stackspace);
                        stackspace = null;

                        studySV_child study = new studySV_child();
                        space.Children.Add(study);
                    }
                    break;

                case "Stack_calender":
                    if (stackspace != null)
                    {
                        space.Children.Remove(stackspace);
                        stackspace = null;

                        celendarSV_child celendar = new celendarSV_child();
                        space.Children.Add(celendar);
                    }
                    break;

                case "Stack_order":
                    if (stackspace != null)
                    {
                        space.Children.Remove(stackspace);
                        stackspace = null;

                        orderSV_child order = new orderSV_child();
                        space.Children.Add(order);
                    }
                    break;

                default:
                    MessageBox.Show("Chức năng đang phát triển, vui lòng đợi");
                    break;
            }
        }
    }
}