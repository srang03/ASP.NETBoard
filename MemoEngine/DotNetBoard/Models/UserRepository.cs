using Dapper;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace DotNetBoard.Models
{
    public class UserRepository : IUserRepository
    {
        private SqlConnection _conn;
        private string proc;
        public UserRepository()
        {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            proc = string.Empty;
        }

        public User BrowseUser(int id)
        {
            proc = "dbo.searchUser";
            var parm = new DynamicParameters();
            parm.Add("@ID", id);
            try
            {
                return _conn.Query<User>(proc, parm).SingleOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool CreateUser(User user)
        {
            proc = "dbo.createUser";
            var parm = new DynamicParameters();
            parm.Add("@EMAIL", value: user.Email, dbType: System.Data.DbType.String);
            parm.Add("@NAME", value: user.Name, dbType: System.Data.DbType.String);
            parm.Add("@PASSWORD", value: user.Password, dbType: System.Data.DbType.String);
            parm.Add("@RE_PASSWORD", value: user.Re_Password, dbType: System.Data.DbType.String);
            parm.Add("@CREATED_IP", value: user.Created_IP, dbType: System.Data.DbType.String);

            try
            {
                return _conn.Execute(proc, parm) > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteUser(int id)
        {
            proc = "dbo.deleteBoard";
            var parm = new DynamicParameters();
            parm.Add("@ID", id);
            try
            {
                return _conn.Execute(proc, parm) > 0;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }

        public bool UpdateUser(User user)
        {
            proc = "dbo.updateUser";
            var parm = new DynamicParameters();
            parm.Add("@NAME", value: user.Name, dbType: System.Data.DbType.String);
            parm.Add("@PASSWORD", value: user.Password, dbType: System.Data.DbType.String);
            parm.Add("@RE_PASSWORD", value: user.Re_Password, dbType: System.Data.DbType.String);
            parm.Add("@MODIFIED_IP", value: user.Modified_IP, dbType: System.Data.DbType.String);
            parm.Add("@MODIFIED_DATE", value: user.Modified_Date, dbType: System.Data.DbType.DateTime);
            try
            {
                return _conn.Execute(proc, parm) > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
    }
}