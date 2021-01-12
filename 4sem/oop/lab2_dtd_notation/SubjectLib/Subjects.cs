using System;
using System.Collections.Generic;

namespace SubjectLib
{
    public class Subjects
    {
        List<Subject> subjects;
        public int Length
        {
            get => subjects.Count;
        }
        public Subjects()
        {
            subjects = new List<Subject>();
        }
        private ControlType FromStringToControlType(string cType)
        {
            switch(cType)
            {
                case "Экзамен":
                    return ControlType.Экзамен;
                case "Зачёт":
                    return ControlType.Зачёт;
                case "ЗачётЭкзамен":
                    return ControlType.ЗачётЭкзамен;
                case "Тест":
                    return ControlType.Тест;
                default:
                    throw new Exception("Нет такого способа контроля знаний");
            }
        }
        public void AddSubject(string name, int lecHours, int labHours, string cType, 
            string eduFirstName, string eduLastName, string eduMiddleName)
        {
            subjects.Add(new Subject(name, lecHours, labHours, FromStringToControlType(cType), 
                new Educator(eduFirstName, eduLastName, eduMiddleName)));
        }
        public int SearchIndexByName(string name)
        {
            int? ind = null;
            int i = 0;
            foreach (Subject s in subjects)
            {
                if (s.Name == name)
                {
                    ind = i;
                    break;
                }
                i += 1;
            }
            if (ind != null)
                return (int)ind;
            else
                throw new Exception("Нет дисциплины с таким именем");
        }
        public void RemoveSubject(string name)
        {
            subjects.RemoveAt(SearchIndexByName(name));
        }
        public void EditSubject(string name, int lecHours, int labHours, string cType,
            string eduFirstName, string eduLastName, string eduMiddleName)
        {
            subjects[SearchIndexByName(name)] = new Subject(name, lecHours, labHours,
                FromStringToControlType(cType), new Educator(eduFirstName, eduLastName, eduMiddleName));
        }
        public string[] this[int index]
        {
            get
            {
                return subjects[index].GetAttributes();
            }
        }
    }
}
