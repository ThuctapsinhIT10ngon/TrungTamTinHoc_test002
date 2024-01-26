using System;
using System.IO;
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
using MongoDB.Bson;
using MongoDB.Driver;
using Syncfusion.Data.Extensions;
using Amazon.Runtime.Documents;
using System.Xml.Linq;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.ObjectModel;
using MongoDB.Bson.Serialization;

namespace TrungTamTinHoc.NHAN_VIEN
{
    /// <summary>
    /// Interaction logic for usermanagementNV_child.xaml
    /// </summary>
    public partial class usermanagementNV_child : UserControl
    {
        public usermanagementNV_child()
        {
            InitializeComponent();
            filldata();
        }

        public class User
        {
            public string Name { get; set; }
            public string Role { get; set; }
        }

        private void filldata()
        {
            var connector_CGV = new MongoDBConnector(GlobalVariables.ConnectionMongo, "TrungTamTinHoc", "GIANG_VIEN");
            var connector_CSV = new MongoDBConnector(GlobalVariables.ConnectionMongo, "TrungTamTinHoc", "SINH_VIEN");

            var documents = connector_CGV.Lookup("SINH_VIEN", localField, foreignField, asField);
            //var filter = Builders<BsonDocument>.Filter.Empty;

            //var doc1 = connector_CGV.FindAllDocument(filter);
            //var doc2 = connector_CSV.FindAllDocument(filter);

            //var combinedDocuments = doc1.Concat(doc2.ToList()).ToList();

            //List<User> users = combinedDocuments.Select(doc => BsonSerializer.Deserialize<User>(doc)).ToList();

            //DataGridTextColumn userColumn = new DataGridTextColumn();
            //userColumn.Header = "UserName";
            //userColumn.Binding = new Binding("tai_khoan.user_name");
            //dgvDanhsach.Columns.Add(userColumn);

            //DataGridTextColumn roleColumn = new DataGridTextColumn();
            //roleColumn.Header = "Role";
            //roleColumn.Binding = new Binding("tai_khoan.role");
            //dgvDanhsach.Columns.Add(roleColumn);

            //foreach (var document in combinedDocuments)
            //{
            //    if (document["tai_khoan"].AsBsonDocument.Contains("role"))
            //    {
            //        // Tạo một đối tượng dữ liệu mới
            //        var dataObject = new
            //        {
            //            UserName = document["tai_khoan"]["user_name"].AsString,
            //            Role = document["tai_khoan"]["role"].AsString
            //        };

            //        // Thêm đối tượng dữ liệu vào DataGrid
            //        dgvDanhsach.Items.Add(dataObject);
            //    }
            //    else
            //    {
            //        // Tạo một đối tượng dữ liệu mới chỉ với trường "user_name"
            //        var dataObject = new
            //        {
            //            UserName = document["tai_khoan"]["user_name"].AsString,
            //            Role = "Không có"
            //        };

            //        // Thêm đối tượng dữ liệu vào DataGrid
            //        dgvDanhsach.Items.Add(dataObject);
            //    }
            //}
            // Kết nối đến MongoDB

            // Tạo ObservableCollection trong ViewModel hoặc Code-behind

            // Đặt ItemsSource của DataGrid thành ObservableCollection

            // Khi bạn muốn thêm mục vào DataGrid, chỉ cần thêm mục vào ObservableCollection
        }
    }
}