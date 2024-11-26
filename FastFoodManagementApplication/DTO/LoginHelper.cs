using System;
using System.Collections.Generic;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DTO
{
    public class LoginHelper
    {
        public static DataTable GetServerName()
        {
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            DataTable table = instance.GetDataSources();
            return table;
        }

        public static int Check_Config()
        {
            if (Properties.Settings.Default.FastFoodManagementDBConnectionString == string.Empty)
                return 1;// Chuỗi cấu hình không tồn tại
            SqlConnection _Sqlconn = new
            SqlConnection(Properties.Settings.Default.FastFoodManagementDBConnectionString);
            try
            {
                if (_Sqlconn.State == ConnectionState.Closed)
                    _Sqlconn.Open();
                return 0;// Kết nối thành công chuỗi cấu hình hợp lệ
            }
            catch (Exception)
            {
                return 2;// Chuỗi cấu hình không phù hợp.
            }
        }

        public static List<string> GetDatabaseName(string pServerName, string pUser, string pPass)
        {
            List<string> _list = new List<string>();
            DataTable dt = new DataTable();
            SqlConnection _sqlcnn = new SqlConnection("Data Source=" + pServerName + ";Initial Catalog=" + "master" +
           ";User ID=" + pUser + ";pwd = " + pPass + "");
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT name FROM sys.databases", _sqlcnn);
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        _list.Add(row[col].ToString());
                    }
                }
            }
            catch
            {
                return null;
            }
            return _list;
        }

        public static void ChangeConnectionString(string pServerName, string pDataBase, string pUser, string pPass)
        {
            string newConnectionString = "Data Source=" + pServerName
            + ";Initial Catalog=" + pDataBase + ";User ID=" + pUser + ";pwd = " + pPass + ";TrustServerCertificate=True";
            
            // Mở tệp cấu hình hiện tại
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Kiểm tra connection string đã tồn tại chưa
            ConnectionStringsSection section = config.ConnectionStrings;
            if (section.ConnectionStrings["FastFoodManagementDBConnectionString"] != null)
            {
                // Cập nhật connection string
                section.ConnectionStrings["FastFoodManagementDBConnectionString"].ConnectionString = newConnectionString;
            }
            else
            {
                // Thêm connection string mới
                section.ConnectionStrings.Add(new ConnectionStringSettings(
                    "FastFoodManagementDBConnectionString",
                    newConnectionString,
                    "System.Data.SqlClient"));
            }

            // Lưu thay đổi và làm mới cấu hình
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
        }
    }
}
