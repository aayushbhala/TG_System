SELECT SID,Student.Department,Section,TID,count(*) AS Total FROM Student GROUP BY SID,Student.Department,Section,TID;
SELECT SID,Student.Department AS Department,Section,count(*) AS Total FROM Student FULL OUTER JOIN Teacher ON Student.TID = Teacher.TID GROUP BY SID,Student.Department,Section,Teacher.Name HAVING Teacher.Name IS NULL;
