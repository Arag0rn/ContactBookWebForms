using System;
using System.IO;
using System.Collections.Generic;
using DataAccess.Entity;

namespace DataAccess.Repository
{
    public class UsersRepository
    {
        public readonly string filePath;

        internal UsersRepository(string filePath)
        {
            this.filePath = filePath;
        }

        private int GetNextId()
        {
            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);

            int id = 1;            
            try
            {
                while (!sr.EndOfStream)
                {
                    User user = new User();
                    user.Id = Convert.ToInt32(sr.ReadLine());
                    user.AdminPrivilegeIndex = Convert.ToInt16(sr.ReadLine());
                    user.FirstName = sr.ReadLine();
                    user.LastName = sr.ReadLine();
                    user.Username = sr.ReadLine();
                    user.Password = sr.ReadLine();

                    if (id <= user.Id)
                    {
                        id = user.Id + 1;  
                    }
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

            return id;
        }

        public void Insert(User item)
        {
            item.Id = GetNextId();

            FileStream fs = new FileStream(this.filePath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            try
            {
                sw.WriteLine(item.Id);
                sw.WriteLine(item.AdminPrivilegeIndex);
                sw.WriteLine(item.FirstName);
                sw.WriteLine(item.LastName);
                sw.WriteLine(item.Username);
                sw.WriteLine(item.Password);
            }
            finally
            {
                sw.Close();
                fs.Close();
            }
        }

        public void Update(User item)
        {
            string fileName = filePath.Substring(filePath.LastIndexOf(@"\") + 1);
            string fileFolder = filePath.Substring(0, filePath.LastIndexOf(@"\"));

            string tempFilePath = fileFolder + "temp." + fileName;

            FileStream ifs = new FileStream(this.filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(ifs);

            FileStream ofs = new FileStream(tempFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(ofs);

            try
            {
                while (!sr.EndOfStream)
                {
                    User user = new User();
                    user.Id = Convert.ToInt32(sr.ReadLine());
                    user.AdminPrivilegeIndex = Convert.ToInt16(sr.ReadLine());
                    user.FirstName = sr.ReadLine();
                    user.LastName = sr.ReadLine();
                    user.Username = sr.ReadLine();
                    user.Password = sr.ReadLine();

                    if (user.Id != item.Id)
                    {
                        sw.WriteLine(user.Id);
                        sw.WriteLine(user.AdminPrivilegeIndex);
                        sw.WriteLine(user.FirstName);
                        sw.WriteLine(user.LastName);
                        sw.WriteLine(user.Username);
                        sw.WriteLine(user.Password);
                    }
                    else
                    {
                        sw.WriteLine(item.Id);
                        sw.WriteLine(item.AdminPrivilegeIndex);
                        sw.WriteLine(item.FirstName);
                        sw.WriteLine(item.LastName);
                        sw.WriteLine(item.Username);
                        sw.WriteLine(item.Password);
                    }
                }
            }
            finally
            {
                sw.Close();
                ofs.Close();
                sr.Close();
                ifs.Close();
            }

            File.Delete(filePath);
            File.Move(tempFilePath, filePath);
        }

        public User GetById(int id)
        {
            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);

            try
            {
                while (!sr.EndOfStream)
                {
                    User user = new User();
                    user.Id = Convert.ToInt32(sr.ReadLine());
                    user.AdminPrivilegeIndex = Convert.ToInt16(sr.ReadLine());
                    user.FirstName = sr.ReadLine();
                    user.LastName = sr.ReadLine();
                    user.Username = sr.ReadLine();
                    user.Password = sr.ReadLine();

                    if (user.Id == id)
                    {
                        return user;
                    }
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

            return null;
        }

        public List<User> GetAll()
        {
            List<User> result = new List<User>();

            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);

            try
            {
                while (!sr.EndOfStream)
                {
                    User user = new User();
                    user.Id = Convert.ToInt32(sr.ReadLine());
                    user.AdminPrivilegeIndex = Convert.ToInt16(sr.ReadLine());
                    user.FirstName = sr.ReadLine();
                    user.LastName = sr.ReadLine();
                    user.Username = sr.ReadLine();
                    user.Password = sr.ReadLine();

                    result.Add(user);
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

            return result;
        }

        public void Delete(User item)
        {
            string fileName = filePath.Substring(filePath.LastIndexOf(@"\" + 1));
            string fileFolder = filePath.Substring(0, filePath.LastIndexOf(@"\"));

            string tempFilePath = fileFolder + "temp." + fileName;

            FileStream ifs = new FileStream(this.filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(ifs);

            FileStream ofs = new FileStream(tempFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(ofs);

            try
            {
                while (!sr.EndOfStream)
                {
                    User user = new User();
                    user.Id = Convert.ToInt32(sr.ReadLine());
                    user.AdminPrivilegeIndex = Convert.ToInt16(sr.ReadLine());
                    user.FirstName = sr.ReadLine();
                    user.LastName = sr.ReadLine();
                    user.Username = sr.ReadLine();
                    user.Password = sr.ReadLine();

                    if (user.Id != item.Id)
                    {
                        sw.WriteLine(user.Id);
                        sw.WriteLine(user.AdminPrivilegeIndex);
                        sw.WriteLine(user.FirstName);
                        sw.WriteLine(user.LastName);
                        sw.WriteLine(user.Username);
                        sw.WriteLine(user.Password);
                    }
                }
            }
            finally
            {
                sw.Close();
                ofs.Close();
                sr.Close();
                ifs.Close();
            }

            File.Delete(filePath);
            File.Move(tempFilePath, filePath);
        }       

        public User GetByUsernameAndPassword(string username, string password)
        {
            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);

            try
            {
                while (!sr.EndOfStream)
                {
                    User user = new User();
                    user.Id = Convert.ToInt32(sr.ReadLine());
                    user.AdminPrivilegeIndex = Convert.ToInt16(sr.ReadLine());
                    user.FirstName = sr.ReadLine();
                    user.LastName = sr.ReadLine();
                    user.Username = sr.ReadLine();
                    user.Password = sr.ReadLine();

                    if (user.Username == username && user.Password == password)
                    {
                        return user;
                    }
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

            return null;
        }    
    }
}