using DBLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SZUUP.Repozitoris
{
    public class RepozitorijZaposlenik
    {
        string sql = $"SELECT * FROM zaposlenik WHERE Kor_ime = '{Kor_ime}'";
 return FetchZaposlenik(sql);
    }
    public static Zaposlenik GetZaposlenik(int id)
    {
        string sql = $"SELECT * FROM zaposlenik WHERE Id_zaposlenika = {id}";
        return FetchTeacher(sql);
    }
    private static Teacher FetchTeacher(string sql)
    {
        DB.OpenConnection();
        var reader = DB.GetDataReader(sql);
        Teacher teacher = null;
        if (reader.HasRows == true)
        {
            reader.Read();
            teacher = CreateObject(reader);
            reader.Close();
        }
        DB.CloseConnection();
        return teacher;
    }
    private static Teacher CreateObject(SqlDataReader reader)
    {
        int id = int.Parse(reader["Id"].ToString());
        string firstName = reader["FirstName"].ToString();
        string lastName = reader["LastName"].ToString();
        string username = reader["Username"].ToString();
        string password = reader["Password"].ToString();
        var teacher = new Teacher
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName,
            Username = username,
            Password = password
        };
        return teacher;
    }

}
