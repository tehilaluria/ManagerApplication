using System;


namespace ConnectToDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hi, How are you?");
            string connectionString = "Data Source=SRV2\\PUPILS;Initial Catalog=Library214773780;Integrated Security=True";
            string IqueryString = "insert into books (BookName,CategoryId,Auther,NumOfPages,Image,Price) values (@BookName,@CategoryId,@Auther,@NumOfPages,@Image,@Price)";
            string RqueryString = "select BookId,BookName from Books";
            DataAccess Da = new DataAccess();
            Da.InsertDate(IqueryString, connectionString);
            
            Da.ReadData(RqueryString, connectionString);


        }
    }
}
