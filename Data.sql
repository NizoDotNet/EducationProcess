use tedrisprosesi;

INSERT INTO faculty(Name, Adress)
VALUES("Muhendislik", "Ozon");

insert into cafedra(Name, FacultyId)
VALUES("IT", 1);

insert into specialization(Name, CafedraId)
VALUES("IT", 1);

insert into student(PIN, Firstname, Lastname, SpecializationId)
VALUES("1234567", "Nizami", "Mamedov", 1);

insert into subject(Name, CafedraId)
values("Programing", 1);

insert into teacher(PIN, Firstname, Lastname, CafedraId)
VALUES("1234567", "Emil", "Nagiyev", 1);

insert into subjecttecher(SubjectId, TecherId)
values(1, 1);