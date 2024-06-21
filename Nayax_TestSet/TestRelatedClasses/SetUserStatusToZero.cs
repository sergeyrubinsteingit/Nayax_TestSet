using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Nayax_TestSet.TestRelatedClasses
{
    class SetUserStatusToZero
    {
        static string ConnectionToDBA = "Server=qa2ilsql01;Database=DCS;Integrated Security=True";

        static string QueryToRun = "use dcs update TBL_ACTOR_AGREEMENT_USER_STATE set TBL_ACTOR_AGREEMENT_USER_STATE.state = 0 where user_id=83950145 select * from TBL_ACTOR_AGREEMENT_USER_STATE where user_id LIKE '%0145'";

        public static void UpdateUserStatusToZero()
        {

            //create instanace of database connection
            SqlConnection SqlConnection_ = new SqlConnection(ConnectionToDBA);

            //Query arrangement
            SqlCommand Query_ = new SqlCommand(QueryToRun, SqlConnection_);

            // open connection
            SqlConnection_.Open();

            // initilate Reader
            SqlDataReader DataReader = Query_.ExecuteReader();

            try
            {
                // reading data
                while (DataReader.Read())
                {
                    for (int sqlCol = 0; sqlCol < DataReader.FieldCount; sqlCol++) {

                        Console.WriteLine(" | " + DataReader.GetName(sqlCol).ToString() + ": " + DataReader.GetValue(sqlCol).ToString() + " | ");

                    }

                }
            }
            finally
            {
                DataReader.Close();
            }

        }//UpdateUserStatusToZero

    }
}
