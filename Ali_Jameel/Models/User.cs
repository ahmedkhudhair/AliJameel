using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ali_Jameel.Models
{
    public class User
    {
        private int Id { get; set; }

        public string FullName { get; set; }

        private string _Email;

        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {

                //if (!IsEmailExist(value))
                //{
                    _Email = value;
                //}
                //else
                //{
                //    throw new Exception("Email Already Exist");
                //}
            }
        }

        public DateTime DateOfBirth { get; set; } = DateTime.Today;

        private string _UserName;

        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {

                //if (!IsUserNameExist(value))
                //{
                    _UserName = value;
                //}
                //else
                //{
                //    throw new Exception("UserName Already Exist");
                //}
            }

        }

        public string Password { get; set; }

        //public List<Post> Posts { get; set; } = new List<Post>();

        //private bool IsEmailExist(string email)
        //{

        //    var table = db.ExecuteSelectQuery($"select email from user where email = '{email}' ");
        //    if (table.Rows.Count > 0)
        //    {
        //        return true;
        //    }
        //    return false;

        //}

        //private bool IsUserNameExist(string username)
        //{
        //    var table = db.ExecuteSelectQuery($"select username from user where username = '{username}' ");
        //    if (table.Rows.Count > 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        DBMS db = new DBMS();

        public bool SignIn()
        {
            bool Ok = false;
            try
            {
                var table = db.ExecuteSelectQuery($"select userid from user where email = '{Email}' and password = '{Password}' ");
                if (table.Rows.Count > 0)
                {
                    Ok = true;
                    //Posts.AddRange()
                }
                return Ok;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool SignUp()
        {
            try
            {
                bool Ok = false;
                Ok = db.ExecuteInsertQuery($"insert into user (`fullname`, `email`, `date_of_birth`, `username`, `password`)  VALUES ('{FullName}','{Email}','{DateOfBirth}','{UserName}' ,'{Password}' ) ");
                return Ok;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public List<Post> Posts(string username)
        //{

        //}
    }
}