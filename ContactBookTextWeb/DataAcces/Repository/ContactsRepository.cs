using System;
using System.IO;
using System.Collections.Generic;
using DataAccess.Entity;

namespace DataAccess.Repository
{
    public class ContactsRepository
    {
        private readonly string filePath;
    
        internal ContactsRepository(string filePath)
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
                    Contact contact = new Contact();
                    contact.Id = Convert.ToInt32(sr.ReadLine());
                    contact.ParentUserId = Convert.ToInt32(sr.ReadLine());
                    contact.FullName = sr.ReadLine();
                    contact.Email = sr.ReadLine();                 
                    contact.Address = sr.ReadLine();
                    contact.Company = sr.ReadLine();

                    if (id <= contact.Id)
                    {
                        id = contact.Id + 1;
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

        private void Insert(Contact item)
        {
            item.Id = GetNextId();

            FileStream fs = new FileStream(this.filePath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            try
            {
                sw.WriteLine(item.Id);
                sw.WriteLine(item.ParentUserId);
                sw.WriteLine(item.FullName);
                sw.WriteLine(item.Email);
                sw.WriteLine(item.Address);
                sw.WriteLine(item.Company);
            }
            finally
            {
                sw.Close();
                fs.Close();
            }
        }

        private void Update(Contact item)
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
                    Contact contact = new Contact();
                    contact.Id = Convert.ToInt32(sr.ReadLine());
                    contact.ParentUserId = Convert.ToInt32(sr.ReadLine());
                    contact.FullName = sr.ReadLine();
                    contact.Email = sr.ReadLine();
                    contact.Address = sr.ReadLine();
                    contact.Company = sr.ReadLine();

                    if (contact.Id != item.Id)
                    {
                        sw.WriteLine(contact.Id);
                        sw.WriteLine(contact.ParentUserId);
                        sw.WriteLine(contact.FullName);
                        sw.WriteLine(contact.Email);
                        sw.WriteLine(contact.Address);
                        sw.WriteLine(contact.Company);
                    }
                    else
                    {
                        sw.WriteLine(item.Id);
                        sw.WriteLine(item.ParentUserId);
                        sw.WriteLine(item.FullName);
                        sw.WriteLine(item.Email);
                        sw.WriteLine(item.Address);
                        sw.WriteLine(item.Company);
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

        public Contact GetById(int id)
        {
            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);

            try
            {
                while (!sr.EndOfStream)
                {
                    Contact contact = new Contact();
                    contact.Id = Convert.ToInt32(sr.ReadLine());
                    contact.ParentUserId = Convert.ToInt32(sr.ReadLine());
                    contact.FullName = sr.ReadLine();
                    contact.Email = sr.ReadLine();
                    contact.Address = sr.ReadLine();
                    contact.Company = sr.ReadLine();
                
                    if (contact.Id == id)
                    {
                        return contact;
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

        public List<Contact> GetAll()
        {
            List<Contact> result = new List<Contact>();

            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);

            try
            {
                while (!sr.EndOfStream)
                {
                    Contact contact = new Contact();
                    contact.Id = Convert.ToInt32(sr.ReadLine());
                    contact.ParentUserId = Convert.ToInt32(sr.ReadLine());
                    contact.FullName = sr.ReadLine();
                    contact.Email = sr.ReadLine();
                    contact.Address = sr.ReadLine();
                    contact.Company = sr.ReadLine();

                    result.Add(contact);
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

            return result;
        }

        public List<Contact> GetAll(int parentUserId)
        {
            List<Contact> result = new List<Contact>();

            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);

            try
            {
                while (!sr.EndOfStream)
                {   
                    Contact contact = new Contact();
                    contact.Id = Convert.ToInt32(sr.ReadLine());
                    contact.ParentUserId = Convert.ToInt32(sr.ReadLine());
                    contact.FullName = sr.ReadLine();
                    contact.Email = sr.ReadLine();
                    contact.Address = sr.ReadLine();
                    contact.Company = sr.ReadLine();

                    if (contact.ParentUserId == parentUserId)
                    {
                        result.Add(contact);
                    }
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

            return result;
        }

        public void Delete(Contact item)
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
                    Contact contact = new Contact();
                    contact.Id = Convert.ToInt32(sr.ReadLine());
                    contact.ParentUserId = Convert.ToInt32(sr.ReadLine());
                    contact.FullName = sr.ReadLine();
                    contact.Email = sr.ReadLine();
                    contact.Address = sr.ReadLine();
                    contact.Company = sr.ReadLine();

                    if (contact.Id != item.Id)
                    {
                        sw.WriteLine(contact.Id);
                        sw.WriteLine(contact.ParentUserId);
                        sw.WriteLine(contact.FullName);
                        sw.WriteLine(contact.Email);
                        sw.WriteLine(contact.Address);
                        sw.WriteLine(contact.Company);
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

        public void Save(Contact item)
        {
            if (item.Id > 0)
            {
                Update(item);
            }
            else
            {
                Insert(item);
            }
        }
    }
}
