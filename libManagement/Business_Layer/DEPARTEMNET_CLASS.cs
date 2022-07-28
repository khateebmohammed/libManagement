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

        // Bring lib Shilf with department 
        public DataTable Bring_Shilf()
        {
            //DAL.open(); we dont need it because SQL DATA Adabter open and close the connection

            /* Now we will excute the stored procedure by calling the function SelectData
            and save its values in DataTable*/

            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("SP_Bring_Shilf", null);

            // Now we must close the connection

            DAL.close();
            // Now we will return the DataTable to the form which check the user information 
            return Dt;
        }

        // This is to bring the shelf's department
        public DataTable Bring_Depts_by_shelf_ID(int ID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("SP_Bring_Depts_by_shelf_ID", param);
            DAL.close();
            return Dt;
        }

        // This is for delete a Shelf
        public void DELETE_Shelf(int ID)
        {
            DAL.open();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;
            DAL.ExecuteCommand("DELETE_Shelf", param);

            DAL.close();
        }


        // This is for Edit Shelf
        public void EDIT_Shelf(int Shelf_ID, string Shelf_Code, string Shelf_Descrip,int Dept_ID)
        {
            DAL.open();
            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@Shelf_ID", SqlDbType.Int);
            param[0].Value = Shelf_ID;

            param[1] = new SqlParameter("@Shelf_Code", SqlDbType.NVarChar, 50);
            param[1].Value = Shelf_Code;

            param[2] = new SqlParameter("@Shelf_Descrip", SqlDbType.NVarChar, 300);
            param[2].Value = Shelf_Descrip;

            param[3] = new SqlParameter("@Dept_ID", SqlDbType.Int);
            param[3].Value = Dept_ID;

            DAL.ExecuteCommand("EDIT_Shelf", param);

            DAL.close();
        }
        // This is for ADD Dept
        public void ADD_Shelf(string Shelf_Code, string Shelf_Descrip, int Dept_ID)
        {
            DAL.open();
            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@Shelf_Code", SqlDbType.NVarChar, 50);
            param[0].Value = Shelf_Code;

            param[1] = new SqlParameter("@Shelf_Descrip", SqlDbType.NVarChar, 300);
            param[1].Value = Shelf_Descrip;

            param[2] = new SqlParameter("@Dept_ID", SqlDbType.Int);
            param[2].Value = Dept_ID;

            DAL.ExecuteCommand("ADD_Shelf", param);

            DAL.close();
        }

        // Bring lib department for shilf use
        public DataTable Bring_Depts_for_shelfs()
        {
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("SP_Bring_Depts_for_shelfs", null);
            DAL.close();
            return Dt;
        }
    }
}
