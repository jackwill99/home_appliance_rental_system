using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem
{
    class User
    {
        private String _id, _name, _userName, _password, _phone, _address, _gender, _photo;


        // Encapsulation
        public String id
        {
            get { return _id; }
            set { _id = value; }
        }

        public String name
        {
            get { return _name; }
            set { _name = value; }
        }

        public String userName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public String password
        {
            get { return _password; }
            set { _password = value; }
        }

        public String phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public String address
        {
            get { return _address; }
            set { _address = value; }
        }

        public String gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public String photo
        {
            get { return _photo; }
            set { _photo = value; }
        }

        // add user
        public static User addDataToUser(String id, String name, String userName, String password, String phone, String address, String image, String gender)
        {
            User user = new User();
            user.id = id;
            user.name = name;
            user.userName = userName;
            user.password = password;
            user.phone = phone;
            user.address = address;

            if (image.ToLower() != "null")
            {
                user.photo = image.ToString();
            }
            else
            {
                user.photo = null;
            }
            if (gender == "Male")
            {
                user.gender = "Male";
            }
            else
            {
                user.gender = "Female";
            }
            return user;
        }

    }
}

