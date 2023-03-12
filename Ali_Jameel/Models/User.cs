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

        public bool IsAdmin { get; set; }

        DBMS db = new DBMS();

        public bool SignIn()
        {
            bool Ok = false;
            try
            {
                var table = db.ExecuteSelectQuery($"select userid from user where email = '{Email}' and password = '{Password}' or username='{UserName}' and password='{Password}'");
                if (table.Rows.Count > 0)
                {
                    Ok = true;
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
                Ok = db.ExecuteInsertQuery($"insert into user (`fullname`, `email`, `username`, `password`,`Role`)  VALUES ('{FullName}','{Email}','{UserName}' ,'{ Password }' , { IsAdmin }) ");
                return Ok;
            }
            catch (Exception ex)
            {
                string e = ex.Message;
                throw;
            }
        }
        //public static string EncodePasswordToBase64(string password)
        //{
        //    try
        //    {
        //        byte[] encData_byte = new byte[password.Length];
        //        encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
        //        string encodedData = Convert.ToBase64String(encData_byte);
        //        return encodedData;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error in base64Encode" + ex.Message);
        //    }
        //}

        //public string DecodeFrom64(string encodedData)
        //{
        //    System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
        //    System.Text.Decoder utf8Decode = encoder.GetDecoder();
        //    byte[] todecode_byte = Convert.FromBase64String(encodedData);
        //    int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
        //    char[] decoded_char = new char[charCount];
        //    utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
        //    string result = new String(decoded_char);
        //    return result;
        //}

    }
}