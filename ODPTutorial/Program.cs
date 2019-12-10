using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
//using System.Data.OleDb;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace ODPTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            //OleDbConnection con = new OleDbConnection("Provider=MSDAORA; Data Provider=XE; User ID=rizvi; Password=123; Unicode=True");
            //con.Open();
            //OleDbDataAdapter adp = new OleDbDataAdapter("select * from student", con);
            //DataTable dt = new DataTable();
            //adp.Fill(dt);
            //con.Close();

//            OracleConnection con = new OracleConnection(@"Data Source=(DESCRIPTION =
//    (ADDRESS = (PROTOCOL = TCP)(HOST = Rizvi)(PORT = 1521))
//    (CONNECT_DATA =
//      (SERVER = DEDICATED)
//      (SERVICE_NAME = XE)
//    )
//  );
//User Id=rizvi;Password=123;");
            
            string conStr = "User Id=rizvi; Password=123; Data Source=localhost:1521/xe;";
            OracleConnection con = new OracleConnection();
            con.ConnectionString = conStr;
            con.Open();

            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "select studentName from student";

            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add()            

            DataTable dts = new DataTable();
            OracleDataAdapter adp = new OracleDataAdapter(cmd);
            adp.Fill(dts);
            con.Close();
            foreach (DataRow dr in dts.Rows)
            {
                Console.WriteLine("Student Name: " + dr[0].ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();
        }
    }
}
