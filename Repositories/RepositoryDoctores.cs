using MvcMascotas.Models;
using System.Data.SqlClient;
using System.Data;

namespace MvcMascotas.Repositories
{
    public class RepositoryDoctores
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public RepositoryDoctores()
        {
            string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITALES;Persist Security Info=True;User ID=SA;Password=MCSD2023";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = cn;

        }

        public List<Doctor> GetDoctores()
        {

            string sql = "select * from DOCTOR";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            List<Doctor> doctoresList = new List<Doctor>();
            while (this.reader.Read())

            {

                Doctor doctor = new Doctor();

                doctor.IdHospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                doctor.IdDoctor = int.Parse(this.reader["DOCTOR_NO"].ToString());
                doctor.Apellido = this.reader["APELLIDO"].ToString();
                doctor.Especialidad = this.reader["ESPECIALIDAD"].ToString();
                doctor.Salario = int.Parse(this.reader["SALARIO"].ToString());

                doctoresList.Add(doctor);

            }

            this.reader.Close();
            this.cn.Close();
            return doctoresList;

        }

        public List<Doctor> FindDoctoresByEspecialidad(string especialidad)
        {

            string sql = "select * from DOCTOR where ESPECIALIDAD=@especialidad";

            SqlParameter pamEspecialidad = new SqlParameter("@especialidad", especialidad);
            this.com.Parameters.Add(pamEspecialidad);

            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();


            List<Doctor> doctoresList = new List<Doctor>();
            while (this.reader.Read())

            {

                Doctor doctor = new Doctor();

                doctor.IdHospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                doctor.IdDoctor = int.Parse(this.reader["DOCTOR_NO"].ToString());
                doctor.Apellido = this.reader["APELLIDO"].ToString();
                doctor.Especialidad = this.reader["ESPECIALIDAD"].ToString();
                doctor.Salario = int.Parse(this.reader["SALARIO"].ToString());

                doctoresList.Add(doctor);

            }
            this.reader.Close();
            this.com.Parameters.Clear();
            this.cn.Close();

            return doctoresList;

        }


    }
}
