using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace libManagement.Business_Layer
{
    class LOGIN_CLASS
    {
        // We will create an object from the data access layer class
        Data_Access_Layer.DataAccessLayer DAL = new Data_Access_Layer.DataAccessLayer();
        public DataTable LOGIN(string ID, string PWD)
        {

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@ID", SqlDbType.NVarChar, 50);
            param[0].Value = ID;
            param[1] = new SqlParameter("@PWD", SqlDbType.NVarChar, 50);
            param[1].Value = PWD;

            // Now we will open the connection

            //DAL.open(); we dont need it because SQL DATA Adabter open and close the connection           

            /* Now we will excute the stored procedure by calling the function SelectData
            and save its values in DataTable*/

            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("SP_LOGIN", param);

            // Now we must close the connection

            DAL.close();
            // Now we will return the DataTable to the form which check the user information 
            return Dt;
        }
        // This is for add a new system user
        public void ADD_System_User(string User_ID, string User_PWD,string User_Type)
        {
            DAL.open();
            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@ID", SqlDbType.NVarChar, 50);
            param[0].Value = User_ID;

            param[1] = new SqlParameter("@PWD", SqlDbType.NVarChar, 50);
            param[1].Value = User_PWD;

            param[2] = new SqlParameter("@Type", SqlDbType.NVarChar, 50);
            param[2].Value = User_Type;

            DAL.ExecuteCommand("ADD_System_User", param);

            DAL.close();
        }
    }
}
