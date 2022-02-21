using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPattern.Models;

namespace RepositoryPattern.Repository
{
    public interface Iemployee
    {

        void InsertEmpRecord(student emp);
        IEnumerable<student> getStudent();
        void updateStudent(student emp);
        void deleteStudent(int id);
        student getStudentByID(int id);
    }
}
