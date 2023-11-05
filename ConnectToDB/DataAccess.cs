using System;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace ConnectToDB
{
    public class DataAccess
    {

        public void InsertDate(string IqueryString, string connectionString)
        {
            string BookName, Auther, Image;
            int CategoryId, NumOfPages, Price;
            Console.WriteLine("insert BookName: ");
            BookName = Console.ReadLine();
            Console.WriteLine("insert Auther: ");
            Auther = Console.ReadLine();
            Console.WriteLine("insert CategoryId: ");
            CategoryId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("insert NumOfPages: ");
            NumOfPages = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("insert Image: ");
            Image = Console.ReadLine();
            Console.WriteLine("insert Price: ");
            Price = Convert.ToInt32(Console.ReadLine());


            //string s = "insert into Products_tbl (ProductName,Description,CategoryId) values (@ProductName,@Description,@CategoryId)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(IqueryString, connection);
                command.Parameters.Add("@BookName", SqlDbType.VarChar, 20).Value = BookName;
                command.Parameters.Add("@Auther", SqlDbType.VarChar, 10).Value = Auther;
                command.Parameters.Add("@CategoryId", SqlDbType.Int).Value = CategoryId;
                command.Parameters.Add("@NumOfPages", SqlDbType.Int).Value = NumOfPages;
                command.Parameters.Add("@Image", SqlDbType.VarChar, 20).Value = Image;
                command.Parameters.Add("@Price", SqlDbType.Int).Value = Price;
                command.Connection.Open();
                int x = command.ExecuteNonQuery();
                Console.WriteLine(x);
            }
        }
        public  void ReadData(string RqueryString, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(RqueryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));
                    }
                }
                else
                {
                    Console.WriteLine("no data founded");
                }
                reader.Close();
            }

        }
    }

}
