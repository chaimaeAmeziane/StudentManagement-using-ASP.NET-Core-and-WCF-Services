using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StudentsWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceStudents" in both code and config file together.
    [ServiceContract]
    public interface IServiceStudents
    {
        [OperationContract]
        List<student> GetAllStudents();
        [OperationContract]
        void DeleteStudent(student s);
        [OperationContract]
        student getStudent(int ids);
        [OperationContract]
        void UpdateStudent(student s);
        [OperationContract]
        void addStudent(student s);
        [OperationContract]
        student GetStudentByCNE(string i);
    }
}
