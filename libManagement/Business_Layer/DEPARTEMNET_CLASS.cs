using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace libManagement.Business_Layer
{
    class DEPARTEMNET_CLASS
    {
        // We will create an object from the data access layer class
        Data_Access_Layer.DataAccessLayer DAL = new Data_Access_Layer.DataAccessLayer();
        public DataTable Bring_Lib_Dept()
        {
            //DAL.open(); we dont need it because SQL DATA Adabter open and close the connection

            /* Now we will excute the stored procedure by calling the function SelectData
            and save its values in DataTable*/

            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("SP_Bring_Lib_Dept", null);

            // Now we must close the connection

            DAL.close();
            // Now we will return the DataTable to the form which check the user information 
            return Dt;
        }

        // This is for delete a department
        public void DELETE_Dept(int ID)
        {
            DAL.open();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;
            DAL.ExecuteCommand("DELETE_Dept", param);

            DAL.close();
        }

        // This is for Edit Dept
        public void EDIT_Dept(int Dept_ID, string Dept_Name, string Dept_Descrip)
        {
            DAL.open();
            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@Dept_ID", SqlDbType.Int);
            param[0].Value = Dept_ID;

            param[1] = new SqlParameter("@Dept_Name", SqlDbType.NVarChar, 100);
            param[1].Value = Dept_Name;

            param[2] = new SqlParameter("@Dept_Descrip", SqlDbType.NVarChar, 500);
            param[2].Value = Dept_Descrip;

            DAL.ExecuteCommand("EDIT_Dept", param);

            DAL.close();
        }
        // This is for ADD Dept
        public void ADD_Dept(string Dept_Name, string Dept_Descrip)
        {
            DAL.open();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@Dept_Name", SqlDbType.NVarChar, 100);
            param[0].Value = Dept_Name;

            param[1] = new SqlParameter("@Dept_Descrip", SqlDbType.NVarChar, 500);
            param[1].Value = Dept_Descrip;

            DAL.ExecuteCommand("ADD_Dept", param);

            DAL.close();
        }
    }
}
