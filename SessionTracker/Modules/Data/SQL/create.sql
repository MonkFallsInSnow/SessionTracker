BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "Session" (
	"ID"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	"Timestamp"	TEXT NOT NULL,
	"StudentID"	TEXT NOT NULL,
	"CourseID"	INTEGER NOT NULL,
	"CampusID"	INTEGER NOT NULL,
	"CenterID"	INTEGER NOT NULL,
	"TutorID"	INTEGER NOT NULL,
	"Notes"	TEXT,
	"IsWorkshop"	INTEGER NOT NULL DEFAULT 0,
	FOREIGN KEY("StudentID") REFERENCES "Student"("StudentID"),
	FOREIGN KEY("CourseID") REFERENCES "Course"("ID"),
	FOREIGN KEY("CampusID") REFERENCES "Campus"("ID"),
	FOREIGN KEY("CenterID") REFERENCES "Center"("ID"),
	FOREIGN KEY("TutorID") REFERENCES "Tutor"("ID")
);
CREATE TABLE IF NOT EXISTS "Course" (
	"ID"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	"Name"	TEXT NOT NULL UNIQUE
);
CREATE TABLE IF NOT EXISTS "Tutor" (
	"ID"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	"FName"	TEXT NOT NULL,
	"LName"	TEXT NOT NULL,
	"IsActive"	INTEGER NOT NULL DEFAULT 1
);
CREATE TABLE IF NOT EXISTS "Center" (
	"ID"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	"Name"	TEXT NOT NULL UNIQUE
);
CREATE TABLE IF NOT EXISTS "SessionTopic" (
	"SessionID"	INTEGER NOT NULL,
	"TopicID"	INTEGER NOT NULL,
	PRIMARY KEY("SessionID","TopicID"),
	FOREIGN KEY("SessionID") REFERENCES "Session"("ID"),
	FOREIGN KEY("TopicID") REFERENCES "Topic"("ID")
);
CREATE TABLE IF NOT EXISTS "TutorCampus" (
	"TutorID"	INTEGER NOT NULL,
	"CampusID"	INTEGER NOT NULL,
	PRIMARY KEY("TutorID","CampusID"),
	FOREIGN KEY("TutorID") REFERENCES "Tutor"("ID"),
	FOREIGN KEY("CampusID") REFERENCES "Campus"("ID")
);
CREATE TABLE IF NOT EXISTS "Campus" (
	"ID"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	"Name"	TEXT NOT NULL UNIQUE
);
CREATE TABLE IF NOT EXISTS "Student" (
	"StudentID"	TEXT NOT NULL UNIQUE,
	"FName"	TEXT NOT NULL,
	"LName"	TEXT NOT NULL,
	PRIMARY KEY("StudentID")
);
CREATE TABLE IF NOT EXISTS "CourseTopic" (
	"CourseID"	INTEGER NOT NULL,
	"TopicID"	INTEGER NOT NULL,
	PRIMARY KEY("CourseID","TopicID"),
	FOREIGN KEY("CourseID") REFERENCES "Course"("ID"),
	FOREIGN KEY("TopicID") REFERENCES "Topic"("ID")
);
CREATE TABLE IF NOT EXISTS "Topic" (
	"ID"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	"Name"	TEXT NOT NULL UNIQUE
);
INSERT INTO "Course" ("ID","Name") VALUES (1,'DBA 120'),
 (2,'ACA 090'),
 (3,'ACA 122'),
 (4,'BUS 110'),
 (5,'COM 120'),
 (6,'COM 231'),
 (7,'ENG 002'),
 (8,'ENG 011'),
 (9,'ENG 111'),
 (10,'ENG 112'),
 (11,'ENG 114'),
 (12,'HIS 131'),
 (13,'HUM 115'),
 (14,'PHI 215'),
 (15,'PHI 240'),
 (16,'PSY 150'),
 (17,'PSY 241'),
 (18,'SOC 210'),
 (19,'MAT 171'),
 (20,'MAT 172'),
 (21,'Wrk-Independent');
INSERT INTO "Tutor" ("ID","FName","LName","IsActive") VALUES (1,'Conrad','Lewin',1),
 (2,'James','Strickland',1),
 (3,'Aaron','Donaldson',1);
INSERT INTO "Center" ("ID","Name") VALUES (1,'Computer Center'),
 (2,'Writing Center'),
 (3,'Math Center');
INSERT INTO "TutorCampus" ("TutorID","CampusID") VALUES (1,1),
 (2,1),
 (3,1),
 (1,2),
 (1,3);
INSERT INTO "Campus" ("ID","Name") VALUES (1,'RTP Campus'),
 (2,'North Campus'),
 (3,'South Campus');
INSERT INTO "CourseTopic" ("CourseID","TopicID") VALUES (2,2),
 (2,3),
 (2,4),
 (2,5),
 (2,6),
 (21,7);
INSERT INTO "Topic" ("ID","Name") VALUES (1,'Views'),
 (2,'Documentation'),
 (3,'Style'),
 (4,'Grammar'),
 (5,'Organization'),
 (6,'Development'),
 (7,'N/A');
CREATE INDEX IF NOT EXISTS "SessionIndex" ON "Session" (
	"Timestamp"	DESC
);
COMMIT;
