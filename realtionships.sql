use tedrisprosesi;

CREATE TABLE SubjectTecher(
	SubjectId INT,
    TecherId INT,
    FOREIGN KEY (SubjectId) REFERENCES Subject(Id),
    FOREIGN KEY (TecherId) REFERENCES Teacher(Id)
);

