using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StudentsWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceStudents" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceStudents.svc or ServiceStudents.svc.cs at the Solution Explorer and start debugging.
    public class ServiceStudents : IServiceStudents
    {
        StudentClassesDataContext l = new StudentClassesDataContext();




        public List<student> GetAllStudents()
        {
            return l.students.ToList();
        }
        public void DeleteStudent(student stu)
        {
            l.students.DeleteOnSubmit(stu);
            l.SubmitChanges();

        }

        public void addStudent(student s)
        {
            l.students.InsertOnSubmit(s);
            l.SubmitChanges();
        }

        public student getStudent(int ids)
        {
            var item = l.students.FirstOrDefault(i => i.id == ids);
            return item;
        }
        public void UpdateStudent(student s)
        {
            student ss = new student();
            ss.id = s.id;
            ss.cne = s.cne;
            ss.firstname = s.firstname;
            ss.lastname = s.lastname;
            ss.email = s.email;
            ss.level = s.level;
            ss.phone = s.phone;

            l.students.DeleteOnSubmit(this.getStudent(s.id));
            l.students.InsertOnSubmit(ss);
            l.SubmitChanges();
        }
        public student GetStudentByCNE(string i)
        {
            var list = from k in l.students where k.cne == i select k;
            student e = new student();
            foreach (var item in list)
            {
                e.id = item.id;
                e.cne = item.cne;
                e.firstname = item.firstname;
                e.lastname = item.lastname;
                e.level = item.level;
                e.email = item.email;
                e.phone = item.phone;
            }
            return e;
        }
    }
}

