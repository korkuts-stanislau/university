using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLinq
{
    public static class Database
    {
        static string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=SubjectsDB;Integrated Security=True";
        static DataContext db;
        static Table<dbControlType> dbControlTypes;
        static Table<dbEducator> dbEducators;
        static Table<dbSubject> dbSubjects;
        static Database()
        {
            db = new DataContext(connectionString);
            dbControlTypes = db.GetTable<dbControlType>();
            dbEducators = db.GetTable<dbEducator>();
            dbSubjects = db.GetTable<dbSubject>();
        }
        public static IQueryable GetControlTypes()
        {
            dbControlTypes = db.GetTable<dbControlType>();
            return from cntrl in dbControlTypes
                   select new
                   {
                       cntrl.ControlTypeId,
                       ControlTypeName = cntrl.ControlTypeName.TrimEnd(' ')
                   };
        }
        public static IQueryable GetEducators()
        {
            dbEducators = db.GetTable<dbEducator>();
            return from edu in dbEducators
                   select new
                   {
                       edu.EducatorId,
                       EducatorName = string.Join(" ", new string[] { edu.LastName.TrimEnd(' '), edu.FirstName.TrimEnd(' '), edu.MiddleName.TrimEnd(' ') })
                   };
        }
        public static IQueryable GetSubjects()
        {
            dbSubjects = db.GetTable<dbSubject>();
            IQueryable rows = from subj in dbSubjects
                              join cntrl in dbControlTypes on subj.ControlTypeId equals cntrl.ControlTypeId
                              join edu in dbEducators on subj.EducatorId equals edu.EducatorId
                              select new
                              {
                                  subj.SubjectId,
                                  SubjectName = subj.SubjectName.TrimEnd(' '),
                                  subj.LectureHours,
                                  subj.LabHours,
                                  ControlTypeName = cntrl.ControlTypeName.TrimEnd(' '),
                                  Educator = string.Join(" ", new string[] { edu.LastName.TrimEnd(' '), edu.FirstName.TrimEnd(' '), edu.MiddleName.TrimEnd(' ') })
                              };
            return rows;
        }
        public static void AddSubject(string subjectName, int lecHours, int labHours, int controlTypeId, int educatorId)
        {
            dbSubject subject = new dbSubject();
            subject.SubjectName = subjectName;
            subject.LectureHours = lecHours;
            subject.LabHours = labHours;
            subject.ControlTypeId = controlTypeId;
            subject.EducatorId = educatorId;
            dbSubjects.InsertOnSubmit(subject);
            db.SubmitChanges();
        }
        public static void EditSubject(int id, string subjectName, int lecHours, int labHours, int controlTypeId, int educatorId)
        {
            var subjects = from subj in dbSubjects
                           where subj.SubjectId == id
                           select subj;
            foreach (var subj in subjects)
            {
                subj.SubjectName = subjectName;
                subj.LectureHours = lecHours;
                subj.LabHours = labHours;
                subj.ControlTypeId = controlTypeId;
                subj.EducatorId = educatorId;
            }
            db.SubmitChanges();
        }
        public static void DeleteSubject(int id)
        {
            var subjects = from subj in dbSubjects
                           where subj.SubjectId == id
                           select subj;
            foreach (var subj in subjects)
            {
                dbSubjects.DeleteOnSubmit(subj);
            }
            db.SubmitChanges();
        }
    }
}
