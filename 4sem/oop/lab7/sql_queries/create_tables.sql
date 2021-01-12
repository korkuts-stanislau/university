use SubjectsDB;
go

create table ControlTypes
(
	ControlTypeId int identity primary key,
	ControlTypeName char(20)
)
go

create table Educators
(
	EducatorId int identity primary key,
	LastName char(20),
	FirstName char(20),
	MiddleName char(20)
)
go

create table Subjects
(
	SubjectId int identity primary key,
	SubjectName char(50),
	LectureHours int,
	LabHours int,
	ControlTypeId int foreign key references ControlTypes(ControlTypeId) on delete cascade on update cascade,
	EducatorId int foreign key references Educators(EducatorId) on delete cascade on update cascade
)