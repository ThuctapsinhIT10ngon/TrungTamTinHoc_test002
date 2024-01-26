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
            fillloaddata();
        }

        private void fillloaddata()
        {
            var connector_CGV = new MongoDBConnector(GlobalVariables.ConnectionMongo, GlobalVariables.NameDatabaseMongo, "GIANG_VIEN");
            var connector_CSV = new MongoDBConnector(GlobalVariables.ConnectionMongo, GlobalVariables.NameDatabaseMongo, "SINH_VIEN");

            var filter = Builders<BsonDocument>.Filter.Empty;

            var document_1 = connector_CGV.FindAllDocument(filter);
            var document_2 = connector_CSV.FindAllDocument(filter);

            var doc_all = document_1.Concat(document_2).ToList();

            List<User> users = new List<User>();
            foreach (var doc in doc_all)
            {
                var u_name = doc["tai_khoan"]["user_name"].AsString;
                var u_role = doc["tai_khoan"]["role"].AsString;
                var name = doc["thong_tin"]["ho_ten"].AsString;
                var note = doc["ghi_chu"].AsString;
                var mand = doc["thong_tin"]["ma"].AsString;
                users.Add(new User() { User_name = u_name, Role = u_role, Name = name, Ghi_chu = note, MSND = mand });
            }
            dgUsers.ItemsSource = users;
        }

        public class User
        {
            public string User_name { get; set; }
            public string Role { get; set; }
            public string Name { get; set; }
            public string Ghi_chu { get; set; }

            public string MSND { get; set; }
        }

        private void cboChose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboChose.SelectedIndex == 0)
            {
                fill_withGV();
            }
            else
            {
                fill_withSV();
            }
        }

        private void fill_withSV()
        {
            var connector_CSV = new MongoDBConnector(GlobalVariables.ConnectionMongo, GlobalVariables.NameDatabaseMongo, "SINH_VIEN");
            var filter = Builders<BsonDocument>.Filter.Empty;
            var document_1 = connector_CSV.FindAllDocument(filter);

            List<User> users = new List<User>();
            foreach (var doc in document_1)
            {
                var u_name = doc["tai_khoan"]["user_name"].AsString;
                var u_role = doc["tai_khoan"]["role"].AsString;
                var name = doc["thong_tin"]["ho_ten"].AsString;
                var note = doc["ghi_chu"].AsString;
                var mand = doc["thong_tin"]["ma"].AsString;
                users.Add(new User() { User_name = u_name, Role = u_role, Name = name, Ghi_chu = note, MSND = mand });
            }
            dgUsers.ItemsSource = users;
        }

        private void fill_withGV()
        {
            var connector_CGV = new MongoDBConnector(GlobalVariables.ConnectionMongo, GlobalVariables.NameDatabaseMongo, "GIANG_VIEN");
            var filter = Builders<BsonDocument>.Filter.Empty;
            var document_1 = connector_CGV.FindAllDocument(filter);

            List<User> users = new List<User>();
            foreach (var doc in document_1)
            {
                var u_name = doc["tai_khoan"]["user_name"].AsString;
                var u_role = doc["tai_khoan"]["role"].AsString;
                var name = doc["thong_tin"]["ho_ten"].AsString;
                var note = doc["ghi_chu"].AsString;
                var mand = doc["thong_tin"]["ma"].AsString;
                users.Add(new User() { User_name = u_name, Role = u_role, Name = name, Ghi_chu = note, MSND = mand });
            }
            dgUsers.ItemsSource = users;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var connector_CGV = new MongoDBConnector(GlobalVariables.ConnectionMongo, GlobalVariables.NameDatabaseMongo, "GIANG_VIEN");
            var connector_CSV = new MongoDBConnector(GlobalVariables.ConnectionMongo, GlobalVariables.NameDatabaseMongo, "SINH_VIEN");

            string use_name = txtTimuser.Text;
            var filter = Builders<BsonDocument>.Filter.Eq("tai_khoan.user_name", use_name);

            var document_1 = connector_CGV.FindAllDocument(filter);
            var document_2 = connector_CSV.FindAllDocument(filter);

            var doc_all = document_1.Concat(document_2).ToList();

            List<User> users = new List<User>();
            foreach (var doc in doc_all)
            {
                var u_name = doc["tai_khoan"]["user_name"].AsString;
                var u_role = doc["tai_khoan"]["role"].AsString;
                var name = doc["thong_tin"]["ho_ten"].AsString;
                var note = doc["ghi_chu"].AsString;
                var mand = doc["thong_tin"]["ma"].AsString;
                users.Add(new User() { User_name = u_name, Role = u_role, Name = name, Ghi_chu = note, MSND = mand });
            }
            dgUsers.ItemsSource = users;
        }
    }
}