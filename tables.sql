use tedrisprosesi;
CREATE TABLE Faculty(
	Id INT PRIMARY KEY AUTO_INCREMENT,
    Name varchar(40),
    Adress TEXT
);
CREATE TABLE Cafedra(
	Id INT PRIMARY KEY AUTO_INCREMENT,
    Name varchar(40),
    FacultyId INT,
    foreign key (FacultyId) references Faculty(Id)
);
CREATE TABLE Specialization(
	Id INT PRIMARY KEY AUTO_INCREMENT,
    Name varchar(40),
    CafedraId INT,
    foreign key (CafedraId) references Cafedra(Id)
);

create table Student(
	Id INT PRIMARY KEY AUTO_INCREMENT,
    PIN varchar(7), 
    Firstname varchar(40),
    Lastname varchar(40),
    SpecializationId INT,
    foreign key (SpecializationId) references Specialization(Id)
);
create table Teacher(
	Id INT PRIMARY KEY AUTO_INCREMENT,
    PIN varchar(7), 
    Firstname varchar(40),
    Lastname varchar(40),
    CafedraId INT,
    foreign key (CafedraId) references Cafedra(Id)
);

CREATE TABLE Subject(
	Id INT PRIMARY KEY AUTO_INCREMENT,
    Name TEXT,
    CafedraId INT,
    foreign key (CafedraId) references Cafedra(Id)
);