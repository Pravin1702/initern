using FirstAPI.Models;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace FirstAPI.Services
{
    public class EmployeeRepo : IRepo<int, Employee>
    {
        SqlConnection conn;
        public EmployeeRepo(IConfiguration configuration)
        {
            string strCon = configuration.GetConnectionString("conn");
            conn = new SqlConnection(strCon);
        }
        public Employee Add(Employee item)
        {
            SqlCommand cmd = new SqlCommand("proc_InsertEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ename", item.Name);
            cmd.Parameters.AddWithValue("@eage", item.Age);
            cmd.Parameters.AddWithValue("@esal", item.Salary);
            if (conn.State == ConnectionState.Open)
                conn.Close();
            try
            {
                conn.Open();
                int Result = cmd.ExecuteNonQuery();
                if (Result > 0)
                    return item;
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }


        public Employee Get(int key)
        {
            Employee employee = GetAll().FirstOrDefault(emp => emp.Id == key);
            return employee;
        }

        public ICollection<Employee> GetAll()
        {
            SqlDataAdapter da = new SqlDataAdapter("proc_GetAllEmployees", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            List<Employee> employees = new List<Employee>();
            DataSet ds = new DataSet();
            da.Fill(ds, "Employees");
            foreach (DataRow dataRow in ds.Tables["Employees"].Rows)
            {
                Employee employee = new Employee();
                employee.Id = Convert.ToInt32(dataRow[0].ToString());
                employee.Name = dataRow[1].ToString();
                employee.Age = Convert.ToInt32(dataRow[2].ToString());
                employee.Salary = float.Parse(dataRow[3].ToString());
                employees.Add(employee);
            }
            return employees;
        }

        public Employee Update(Employee item)
        {
            Employee employee = Get(item.Id);
            if (employee == null)
                return null;
            SqlCommand cmd = new SqlCommand("proc_UpdateSalary", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eid", item.Id);
            cmd.Parameters.AddWithValue("@esal", item.Salary);
            if (conn.State == ConnectionState.Open)
                conn.Close();
            try
            {
                conn.Open();
                int Result = cmd.ExecuteNonQuery();
                if (Result > 0)
                    return employee;
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }
        public Employee Delete(int key)
        {
            Employee employee = Get(key);
            if (employee == null)
                return null;
            SqlCommand cmd = new SqlCommand("proc_DeleteEmployeeById", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eid", key);
            if (conn.State == ConnectionState.Open)
                conn.Close();
            try
            {
                conn.Open();
                int Result = cmd.ExecuteNonQuery();
                if (Result > 0)
                    return employee;
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }
    }
}
