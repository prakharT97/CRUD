using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepositoryPattern.Models;

namespace RepositoryPattern.Repository
{
    public class RepositoryEmployee : Iemployee
    {
        //private DatabaseFirstEFEntities sd = new DatabaseFirstEFEntities();
        private DatabaseFirstEFEntities databaseFirstEFEntities;

        public RepositoryEmployee(DatabaseFirstEFEntities databaseFirstEFEntities)
        {
            this.databaseFirstEFEntities = databaseFirstEFEntities;
        }

        public void deleteStudent(int id)
        {
            student delemp = databaseFirstEFEntities.students.Find(id);
            databaseFirstEFEntities.students.Remove(delemp);
            databaseFirstEFEntities.SaveChanges();
        }

        public IEnumerable<student> getStudent()
        {
            return databaseFirstEFEntities.students.ToList();           
        }

        public student getStudentByID(int id)
        {
            return databaseFirstEFEntities.students.Find(id);
        }

        public void InsertEmpRecord(student emp)
        {
            databaseFirstEFEntities.students.Add(emp);
            databaseFirstEFEntities.SaveChanges();
        }

        public void updateStudent(student emp)
        {
            databaseFirstEFEntities.Entry(emp).State = System.Data.Entity.EntityState.Modified;
            databaseFirstEFEntities.SaveChanges();
        }
    }
}