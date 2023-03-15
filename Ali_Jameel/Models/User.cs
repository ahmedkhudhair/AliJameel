using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
                    _Email = value;
            }
        }

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

        private string _Password;

        
        public string Password 
        {
            get
            {
                return _Password;
            }
            set
            {
                
                //_Password = EncodePasswordToBase64(value);
                _Password = value;
            }

        }

        [TempData]
        public string Message { get; set; }


        public bool IsAdmin { get; set; }

        DBMS db = new DBMS();

        public Tuple<bool,string> SignIn()
        {
            
            try
            {
                var table = db.ExecuteSelectQuery($"select username from user where email = '{Email}' and password = '{Password}'");
                if (table.Rows.Count > 0)
                {
                    return Tuple.Create(true, table.Rows[0]["username"].ToString());
                }
                else
                {
                    return Tuple.Create(false, "");

                }
                
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
                Ok = db.ExecuteInsertQuery($"insert into user (`fullname`, `email`, `username`, `password`,`Role`)  VALUES ('{FullName}','{Email}','{UserName}' ,'{ Password }' , { IsAdmin }) ");
                return Ok;
            }
            catch (Exception ex)
            {
                string e = ex.Message;
                throw;
            }
        }

    }
}