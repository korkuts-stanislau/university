namespace SubjectLib
{
    internal enum ControlType
    {
        Зачёт,
        Экзамен,
        ЗачётЭкзамен,
        Тест
    }
    /// <summary>
    /// Структура, описывающая дисциплинуы
    /// </summary>
    internal struct Subject
    {
        public string Name { get; }
        public int LectureHours { get; }
        public int LabHours { get; }
        public ControlType SubControlType { get; }
        public Educator Educator { get; }
        /// <summary>
        /// Конструктор структуры дисциплина
        /// </summary>
        /// <param name="name">Название дисциплины</param>
        /// <param name="lecHours">Количество лекционных часов</param>
        /// <param name="labHours">Количество лабораторных часов</param>
        /// <param name="cType">Тип контроля знаний</param>
        /// <param name="educator">Преподаватель этой дисциплины</param>
        public Subject(string name, int lecHours, int labHours, ControlType cType, Educator educator)
        {
            Name = name;
            LectureHours = lecHours;
            LabHours = labHours;
            SubControlType = cType;
            Educator = educator;
        }
        public override string ToString()
        {
            return $"Дисциплина {Name}, часы {LectureHours}/{LabHours}, " +
                $"тип контроля {SubControlType.ToString()}, преподаватель: {Educator.ToString()}";
        }
        public string[] GetAttributes()
        {
            return new string[] {Name, LectureHours.ToString(), LabHours.ToString(),
                SubControlType.ToString("G"), Educator.FirstName, Educator.LastName, Educator.MiddleName };
        }
    }
    /// <summary>
    /// Структура, содержащая ФИО преподавателя
    /// </summary>
    internal struct Educator
    {
        public string FirstName { get; } // имя
        public string LastName { get; } // фамилия
        public string MiddleName { get; } // отчество
                                          /// <summary>
                                          /// Конструктор структуры преподаватель
                                          /// </summary>
                                          /// <param name="fName">Имя преподавателя</param>
                                          /// <param name="lName">Фамилия преподавателя</param>
                                          /// <param name="mName">Отчество преподавателя</param>
        public Educator(string fName, string lName, string mName)
        {
            FirstName = fName;
            LastName = lName;
            MiddleName = mName;
        }
        public override string ToString()
        {
            return $"{LastName} {FirstName} {MiddleName}";
        }
    }
}
