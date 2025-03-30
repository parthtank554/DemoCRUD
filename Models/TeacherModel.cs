using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Security.Cryptography.Pkcs;

namespace DemoCRUD.Models
{
    public class TeacherModel
    {
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Demo;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Teacher name")]
        public string T_Name { get; set; }

        [Required(ErrorMessage = "Please Enter Subject")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "please enter Semester")]
        [Range(1, 6, ErrorMessage = "Value should be between 1 to 6")]
        public int sem { get; set; }

        [Required(ErrorMessage = "Please Enter Experience")]
        public int Exp { get; set; }

        [Required(ErrorMessage = "please enter salary")]
        [Range(5000, 50000, ErrorMessage = "Value should be between 5k to 50k")]
        public int Salary { get; set; }

        public List<TeacherModel> getData()
        {
            List<TeacherModel> lsttech = new List<TeacherModel>();
            SqlDataAdapter sdap = new SqlDataAdapter("select * from Teacher", con);
            DataSet ds = new DataSet();
            sdap.Fill(ds);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lsttech.Add(new TeacherModel
                {
                    Id = Convert.ToInt32(dr["Id"].ToString()),
                    T_Name = dr["T_Name"].ToString(),
                    Subject = dr["Subject"].ToString(),
                    sem = Convert.ToInt32(dr["Sem"].ToString()),
                    Exp = Convert.ToInt32(dr["Experience"].ToString()),
                    Salary = Convert.ToInt32(dr["Salary"].ToString()),
                });
            }
            return lsttech;
        }

        //public TeacherModel getData(string Id)
        //{
        //    TeacherModel model = new TeacherModel();
        //    SqlCommand cmd = new SqlCommand("select * from Teacher where Id = '"+Id+"'", con);
        //    con.Open();
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    if (dr.HasRows)
        //    {
        //        while (dr.Read())
        //        {
        //            model.Id = Convert.ToInt32(dr["Id"].ToString());
        //            model.T_Name = dr["T_Name"].ToString();
        //            model.Subject = dr["Subject"].ToString();
        //            model.sem = Convert.ToInt32(dr["Sem"].ToString());
        //            model.Exp = Convert.ToInt32(dr["Experience"].ToString());
        //            model.Salary = Convert.ToInt32(dr["Salary"].ToString());
        //        }
        //        con.Close();
        //        return model;
        //    }
        //}

        public bool Insert(TeacherModel tech)
        {
            SqlCommand cmd = new SqlCommand("insert into Teacher values (@T_name, @sub, @sem, @exp, @sal)", con);
            cmd.Parameters.AddWithValue("@T_name", tech.T_Name);
            cmd.Parameters.AddWithValue("@sub", tech.Subject);
            cmd.Parameters.AddWithValue("@sem", tech.sem);
            cmd.Parameters.AddWithValue("@exp", tech.Exp);
            cmd.Parameters.AddWithValue("@sal", tech.Salary);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;

        }
    }
}
