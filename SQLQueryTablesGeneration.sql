CREATE TABLE UserData
(
  First_Name VARCHAR(250) NOT NULL,
  Last_Name VARCHAR(250) NOT NULL,
  User_ID INT NOT NULL,
  Email VARCHAR(250) NOT NULL UNIQUE,
  UserPassword VARCHAR(250) NOT NULL,
  PRIMARY KEY (User_ID)
);

CREATE TABLE AdminData
(
  Admin_ID INT NOT NULL,
  Authentication_code INT NOT NULL UNIQUE,
  PRIMARY KEY (Admin_ID),
  FOREIGN KEY (Admin_ID) REFERENCES UserData(User_ID)
);

CREATE TABLE PlayerData
(
  Rank INT NOT NULL,
  Player_ID INT NOT NULL,
  PRIMARY KEY (Player_ID),
  FOREIGN KEY (Player_ID) REFERENCES UserData(User_ID)
);



CREATE TABLE Category
(
  Name VARCHAR(250) NOT NULL,
  Category_ID INT NOT NULL,
  PRIMARY KEY (Category_ID)
);

CREATE TABLE Post_Type
(
  Type_ID INT NOT NULL,
  Name VARCHAR(250) NOT NULL,
  PRIMARY KEY (Type_ID)
);

CREATE TABLE Leaderboard
(
  Leaderboard_ID INT NOT NULL,
  Top_Player_ID INT NOT NULL,
  PRIMARY KEY (Leaderboard_ID),
  FOREIGN KEY (Top_Player_ID) REFERENCES PlayerData(Player_ID)
);

CREATE TABLE Is_Friend
(
  Player_ID INT NOT NULL,
  Frien_Player_ID INT NOT NULL,
  PRIMARY KEY (Player_ID, Frien_Player_ID),
  FOREIGN KEY (Player_ID) REFERENCES PlayerData(Player_ID),
  FOREIGN KEY (Frien_Player_ID) REFERENCES PlayerData(Player_ID)
);

CREATE TABLE Permissions
(
  Per_ID INT NOT NULL,
  Permission VARCHAR(100) NOT NULL,
  PRIMARY KEY (Per_ID)
);

CREATE TABLE Leaderboard_Players
(
  Player_ID INT NOT NULL,
  Leaderboard_ID INT NOT NULL,
  PRIMARY KEY (Player_ID, Leaderboard_ID),
  FOREIGN KEY (Player_ID) REFERENCES PlayerData(Player_ID),
  FOREIGN KEY (Leaderboard_ID) REFERENCES Leaderboard(Leaderboard_ID)
);

CREATE TABLE Quiz_Author
(
  Quizzes# INT NOT NULL,
  Feedback INT NOT NULL,
  Author_ID INT NOT NULL,
  Category_ID INT NOT NULL,
  PRIMARY KEY (Author_ID),
  FOREIGN KEY (Author_ID) REFERENCES UserData(User_ID),
  FOREIGN KEY (Category_ID) REFERENCES Category(Category_ID)
);
CREATE TABLE Quiz
(
  Quiz_ID INT NOT NULL,
  Title VARCHAR(250) NOT NULL,
  AVG_Rate INT NOT NULL,
  
  Quiz_Descreption VARCHAR(500) NOT NULL,
  Creation_Date VARCHAR(15) NOT NULL,
  Time_Limit INT NOT NULL,
  
  Author_ID INT NOT NULL,
  PRIMARY KEY (Quiz_ID),
  FOREIGN KEY (Author_ID) REFERENCES Quiz_Author(Author_ID)
);
Create table quiz_participants(
PQuiz_ID int not null,
Participant_id int not null,
FOREIGN KEY (Participant_id) REFERENCES PlayerData(Player_ID),
FOREIGN KEY (PQuiz_ID) REFERENCES Quiz(Quiz_ID),
PRIMARY KEY(pQUIZ_ID,Participant_id)
);
create table Score_history(
Splayer_id int ,
score int ,
SQuiz_id int ,
Date_time DATETIME,
 foreign key (Splayer_id) REFERENCES PlayerData(Player_ID),
foreign key (SQuiz_id) REFERENCES Quiz(Quiz_ID),
Primary key(Splayer_id,SQuiz_id)

);

CREATE TABLE Questions
( Questions_order INT NOT NULL,
  Question_ID INT NOT NULL,
  Type VARCHAR(250) NOT NULL,
  Points INT NOT NULL,
  Correct_Answer CHAR(1) NOT NULL,
  Quiz_ID INT NOT NULL,
  Question_Content VARCHAR(500) NOT NULL,
  PRIMARY KEY (Question_ID),
  FOREIGN KEY (Quiz_ID) REFERENCES Quiz(Quiz_ID)
);
CREATE TABLE Room
(
  Room_ID INT NOT NULL ,
  Name VARCHAR(250) NOT NULL,
  Capacity INT NOT NULL,
  
  Privacy VARCHAR(50) NOT NULL,
  Description VARCHAR(50) NOT NULL,
  Leaderboard_ID INT NOT NULL,
  Category_ID INT NOT NULL,
  Admin_ID INT NOT NULL,
  PRIMARY KEY (Room_ID),
  FOREIGN KEY (Leaderboard_ID) REFERENCES Leaderboard(Leaderboard_ID),
  FOREIGN KEY (Category_ID) REFERENCES Category(Category_ID),
  FOREIGN KEY (Admin_ID) REFERENCES AdminData(Admin_ID)
);

CREATE TABLE Post
(
  Post_ID INT NOT NULL,
  Date_Time VARCHAR(30) NOT NULL,
  Likes# INT NOT NULL,
  Dislikes# INT NOT NULL,
  Content VARCHAR(1500) NOT NULL,
  Type_ID INT NOT NULL,
  User_ID INT NOT NULL,
  Room_ID INT NOT NULL,
  PRIMARY KEY (Post_ID),
  FOREIGN KEY (Type_ID) REFERENCES Post_Type(Type_ID),
  FOREIGN KEY (User_ID) REFERENCES UserData(User_ID),
  FOREIGN KEY (Room_ID) REFERENCES Room(Room_ID)
);

CREATE TABLE Comment
(
  Comment_ID INT NOT NULL,
  Content Varchar(500) NOT NULL,
  Like# INT NOT NULL,
  Dislike# INT NOT NULL,
  Date_Time VARCHAR(30) NOT NULL,
  User_ID INT,
  Post_ID INT NOT NULL,
  PRIMARY KEY (Comment_ID, User_ID),
  FOREIGN KEY (User_ID) REFERENCES UserData(User_ID),
  FOREIGN KEY (Post_ID) REFERENCES Post(Post_ID)
);



CREATE TABLE Report
(
  Report_ID INT NOT NULL,
  Date varchar(30) NOT NULL,
  Report_Content VARCHAR(250) NOT NULL,
  User_ID INT ,
  Post_ID INT,
  Comment_ID INT,
  
  Quiz_ID INT ,
  Reporter_ID INT NOT NULL,
  PRIMARY KEY (Report_ID),
  FOREIGN KEY (User_ID) REFERENCES UserData(User_ID),
  FOREIGN KEY (Post_ID) REFERENCES Post(Post_ID),
  FOREIGN KEY (Comment_ID, User_ID) REFERENCES Comment(Comment_ID, User_ID),
  FOREIGN KEY (Quiz_ID) REFERENCES Quiz(Quiz_ID),
  FOREIGN KEY (Reporter_ID) REFERENCES UserData(User_ID)
);

CREATE TABLE Admin_Permissions
(
  Admin_ID INT NOT NULL,
  Per_ID INT NOT NULL,
  FOREIGN KEY (Admin_ID) REFERENCES AdminData(Admin_ID),
  FOREIGN KEY (Per_ID) REFERENCES Permissions(Per_ID)
);

CREATE TABLE Admin_Reports_Assigned
(
  Admin_ID INT NOT NULL,
  Report_ID INT NOT NULL,
  PRIMARY KEY (Admin_ID),
  FOREIGN KEY (Admin_ID) REFERENCES AdminData(Admin_ID),
  FOREIGN KEY (Report_ID) REFERENCES Report(Report_ID)
);

CREATE TABLE Questions_option
(

  options VARCHAR(250) NOT NULL,
  Question_ID INT NOT NULL,
  PRIMARY KEY (options, Question_ID),
  FOREIGN KEY (Question_ID) REFERENCES Questions(Question_ID)
);


INSERT INTO UserData (First_Name, Last_Name, User_ID, Email, UserPassword)
VALUES
('John', 'Doe', 1, 'john.doe@example.com', 'password1'),
('Jane', 'Smith', 2, 'jane.smith@example.com', 'password2'),
('Alice', 'Johnson', 3, 'alice.johnson@example.com', 'password3'),
('Bob', 'Williams', 4, 'bob.williams@example.com', 'password4'),
('Charlie', 'Brown', 5, 'charlie.brown@example.com', 'password5'),
('David', 'Miller', 6, 'david.miller@example.com', 'password6'),
('Eva', 'White', 7, 'eva.white@example.com', 'password7'),
('Frank', 'Anderson', 8, 'frank.anderson@example.com', 'password8'),
('Grace', 'Martinez', 9, 'grace.martinez@example.com', 'password9'),
('Henry', 'Taylor', 10, 'henry.taylor@example.com', 'password10'),
('Isabel', 'Lee', 11, 'isabel.lee@example.com', 'password11'),
('Jack', 'Gonzalez', 12, 'jack.gonzalez@example.com', 'password12'),
('Katie', 'Wright', 13, 'katie.wright@example.com', 'password13'),
('Leo', 'Scott', 14, 'leo.scott@example.com', 'password14'),
('Mia', 'Lopez', 15, 'mia.lopez@example.com', 'password15'),
('Noah', 'Hill', 16, 'noah.hill@example.com', 'password16'),
('Olivia', 'Young', 17, 'olivia.young@example.com', 'password17'),
('Peter', 'Allen', 18, 'peter.allen@example.com', 'password18'),
('Quinn', 'Baker', 19, 'quinn.baker@example.com', 'password19'),
('Rachel', 'Fisher', 20, 'rachel.fisher@example.com', 'password20'),
('Samuel', 'Evans', 21, 'samuel.evans@example.com', 'password21'),
('Tina', 'Cooper', 22, 'tina.cooper@example.com', 'password22'),
('Ulysses', 'Morgan', 23, 'ulysses.morgan@example.com', 'password23'),
('Vera', 'Reed', 24, 'vera.reed@example.com', 'password24'),
('William', 'King', 25, 'william.king@example.com', 'password25'),
('Xander', 'Thompson', 26, 'xander.thompson@example.com', 'password26'),
('Yasmine', 'Lowe', 27, 'yasmine.lowe@example.com', 'password27'),
('Zane', 'Harrison', 28, 'zane.harrison@example.com', 'password28'),
('Abigail', 'Palmer', 29, 'abigail.palmer@example.com', 'password29'),
('Benjamin', 'Bryant', 30, 'benjamin.bryant@example.com', 'password30'),
('Catherine', 'Rogers', 31, 'catherine.rogers@example.com', 'password31'),
('Daniel', 'Adams', 32, 'daniel.adams@example.com', 'password32'),
('Emma', 'Hernandez', 33, 'emma.hernandez@example.com', 'password33'),
('Felix', 'Perry', 34, 'felix.perry@example.com', 'password34'),
('Gabrielle', 'Cox', 35, 'gabrielle.cox@example.com', 'password35'),
('Henry', 'Stewart', 36, 'henry.stewart@example.com', 'password36'),
('Isabella', 'Dixon', 37, 'isabella.dixon@example.com', 'password37'),
('James', 'McCarthy', 38, 'james.mccarthy@example.com', 'password38'),
('Katherine', 'Grant', 39, 'katherine.grant@example.com', 'password39'),
('Liam', 'Warren', 40, 'liam.warren@example.com', 'password40'),
('Megan', 'Dunn', 41, 'megan.dunn@example.com', 'password41'),
('Nathan', 'Fletcher', 42, 'nathan.fletcher@example.com', 'password42'),
('Oliver', 'Hudson', 43, 'oliver.hudson@example.com', 'password43'),
('Penelope', 'Simmons', 44, 'penelope.simmons@example.com', 'password44'),
('Quincy', 'Owens', 45, 'quincy.owens@example.com', 'password45'),
('Riley', 'Spencer', 46, 'riley.spencer@example.com', 'password46'),
('Sophia', 'Neal', 47, 'sophia.neal@example.com', 'password47'),
('Thomas', 'Hayes', 48, 'thomas.hayes@example.com', 'password48'),
('Ursula', 'Ferguson', 49, 'ursula.ferguson@example.com', 'password49'),
('Vincent', 'Howard', 50, 'vincent.howard@example.com', 'password50');



INSERT INTO PlayerData (Rank, Player_ID)
VALUES
(0, 1), (100, 2), (300, 3), (500, 4), (700, 5),
(900, 6), (1100, 7), (1300, 8), (1500, 9), (1200, 10),
(1000, 11), (800, 12), (600, 13), (400, 14), (200, 15),
(300, 16), (500, 17), (700, 18), (900, 19), (1100, 20);


INSERT INTO AdminData (Admin_ID, Authentication_code)
VALUES
    (21, ABS(CHECKSUM(NEWID())) % 1000000),
    (22, ABS(CHECKSUM(NEWID())) % 1000000),
    (23, ABS(CHECKSUM(NEWID())) % 1000000),
    (24, ABS(CHECKSUM(NEWID())) % 1000000),
    (25, ABS(CHECKSUM(NEWID())) % 1000000),
    (26, ABS(CHECKSUM(NEWID())) % 1000000),
    (27, ABS(CHECKSUM(NEWID())) % 1000000),
    (28, ABS(CHECKSUM(NEWID())) % 1000000),
    (29, ABS(CHECKSUM(NEWID())) % 1000000),
    (30, ABS(CHECKSUM(NEWID())) % 1000000),
    (31, ABS(CHECKSUM(NEWID())) % 1000000),
    (32, ABS(CHECKSUM(NEWID())) % 1000000),
    (33, ABS(CHECKSUM(NEWID())) % 1000000),
    (34, ABS(CHECKSUM(NEWID())) % 1000000),
    (35, ABS(CHECKSUM(NEWID())) % 1000000),
    (36, ABS(CHECKSUM(NEWID())) % 1000000),
    (37, ABS(CHECKSUM(NEWID())) % 1000000),
    (38, ABS(CHECKSUM(NEWID())) % 1000000),
    (39, ABS(CHECKSUM(NEWID())) % 1000000),
    (40, ABS(CHECKSUM(NEWID())) % 1000000);

INSERT INTO Category (Name, Category_ID)
VALUES
    ('History', 1),
    ('Music', 2),
    ('Literature', 3),
    ('Physics', 4),
    ('Game Development', 5),
    ('Mathematics', 6),
    ('Biology', 7),
    ('Chemistry', 8),
    ('Space Exploration', 9),
    ('Programming', 10),
    ('Artificial Intelligence', 11),
    ('Robotics', 12),
    ('Electronics', 13),
    ('Cybersecurity', 14),
    ('Virtual Reality', 15);

INSERT INTO Quiz_Author (Quizzes#, Feedback, Author_ID, Category_ID)
VALUES
  (0, 0, 41,5), 
  (0, 0, 42,12),
  (0, 0, 43, 2),
  (0, 0, 44, 7),
  (0, 0, 45, 7),
  (0, 0, 46,4),
  (0, 0, 47,9),
  (0, 0, 48, 9),
  (0, 0, 49, 15),
  (0, 0, 50, 8);

INSERT INTO Is_Friend (Player_ID, Frien_Player_ID)
VALUES
  (1, 2), (1, 3), (1, 4), (1, 5), (1, 6),
  (2, 3), (2, 4), (2, 7), (2, 8),
  (3, 4), (3, 5), (3, 9),
  (4, 5), (4, 10),
  (5, 6),
  (6, 7),
  (7, 8),
  (8, 9),
  (9, 10);


INSERT INTO Permissions (Per_ID, Permission)
VALUES
  (1, 'User Management'),
  (2, 'Content Moderation'),
  (3, 'Quiz Management'),
  (4, 'Category Management'),
  (5, 'Report Handling'),
  (6, 'Room Management'),
  (7, 'Post Management'),
  (8, 'Comment Management'),
  (9, 'Admin Management'),
  (10, 'Permission Management');

INSERT INTO Admin_Permissions (Admin_ID, Per_ID)
VALUES
  (21, 1),
  (21, 2),
  (21, 3),
  (21, 4),
  (22, 2),
  (22, 5),
  (22, 7),
  (22, 10),
  (40, 3),
  (40, 6),
  (40, 8),
  (40, 9);

  INSERT INTO Leaderboard (Leaderboard_ID, Top_Player_ID)
VALUES
  (1, 4),
  (2, 6),
  (3, 5)
INSERT INTO Room (Room_ID, Name, Capacity, Privacy, Description, Leaderboard_ID, Category_ID, Admin_ID)
VALUES
  (1, 'Room 1', 10, 'Private', 'Room for casual chat', 1, 1, 21),
  (2, 'Room 2', 15, 'Public', 'Open discussion room', 2, 2, 22),
  (3, 'Room 3', 20, 'Private', 'Programming enthusiasts', 3, 3, 23)

 
 INSERT INTO Leaderboard_Players (Player_ID, Leaderboard_ID)
VALUES
  (1, 1),
  (2, 3),
  (3, 3),
  (8, 2),
  (9, 1),
  (12, 2);

INSERT INTO Post_Type (Type_ID, Name)
VALUES
  (1, 'Normal Post'),
  (2, 'Announcement')

INSERT INTO Post (Post_ID, Date_Time, Likes#, Dislikes#, Content, Type_ID, User_ID, Room_ID)
VALUES
  (1, '2023-12-01 12:03:00', 10, 2, 'This is post 1 content.', 1, 1, 1),
  (2, '2023-12-02 14:30:00', 8, 0, 'This is post 2 content.', 1, 2, 1),
  (3, '2023-12-10 09:45:00', 15, 3, 'This is post 20 content.', 1, 10, 2);

INSERT INTO Comment (Comment_ID, Content, Like#, Dislike#, Date_Time, User_ID, Post_ID)
VALUES
  (1, 'Nice post!', 5, 0, '2023-12-01 12:05:00', 3, 1),
  (2, 'Great content!', 7, 1, '2023-12-02 14:35:00', 4, 1),
  (3, 'Interesting discussion!', 10, 2, '2023-12-10 10:00:00', 8, 2),
  (4, 'Nice content!', 12, 0, '2023-12-02 14:20', 4, 1),
  (5, 'Looking forward to more posts.', 9, 2, '2023-12-03 11:10', 5, 2),  
  (6, 'This is insightful.', 7, 1, '2023-12-03 15:45', 6, 3),
  (7, 'I agree with the author.', 11, 0, '2023-12-04 08:30', 7, 1),
  (8, 'Not sure about this.', 4, 5, '2023-12-05 10:55', 8, 2),
  (9, 'Let me know your thoughts.', 6, 2, '2023-12-05 16:00', 9, 3),
  (10, 'Well written!', 15, 1, '2023-12-06 12:05', 10, 1);


    INSERT INTO Quiz (Quiz_ID, Title, AVG_Rate, Quiz_Descreption, Creation_Date, Time_Limit, Author_ID)
VALUES
(1, 'General Knowledge Quiz', 0, 'Test your knowledge on various topics.', '2023-12-01', 30, 41),
(2, 'Science Trivia', 0, 'Explore the wonders of science.', '2023-12-02', 25, 42)


  INSERT INTO Questions (Questions_order, Question_ID, Type, Points, Correct_Answer, Quiz_ID, Question_Content)
VALUES
(1, 1, 'Multiple Choice', 5, 'A', 1, 'What is the capital of France?'),
(2, 2, 'True/False', 3, 'T', 1, 'The Earth is flat.'),
(3, 3, 'Fill in the Blank', 4, 'C', 1, 'The speed of light is ___ m/s.'),
(1, 4, 'Multiple Choice', 5, 'B', 2, 'Which programming language is known for its simplicity?'),
(2, 5, 'True/False', 3, 'F', 2, 'HTML stands for HyperText Markup Language.'),
(3, 6, 'Fill in the Blank', 4, 'D', 2, 'The main component of the atmosphere is ___ gas.')

INSERT INTO Questions_option (options, Question_ID)
VALUES
  ('Option A', 1),
  ('Option B', 1),
  ('Option C', 1),
  ('Option D', 1),
  ('True', 2),
  ('False', 2),
  ('Choice 1', 4),
  ('Choice 2', 4),
  ('Choice 3', 4),
  ('Choice 4', 4),
  ('Yes', 6),
  ('No', 6),
  ('Agree', 5),
  ('Disagree', 5);
  



INSERT INTO quiz_participants (PQuiz_ID, Participant_id)
VALUES
(1, 1),
(1, 2),
(2, 3),
(2, 4)




INSERT INTO Score_history (Splayer_id, score, SQuiz_id, Date_time)
VALUES
(1, 20, 1, '2023-11-25 15:30:00'),
(2, 18, 1, '2023-11-26 10:45:00'),
(3, 15, 1, '2023-11-27 14:20:00'),
(4, 22, 2, '2023-11-28 12:00:00'),
(5, 25, 2, '2023-11-29 09:15:00'),
(6, 19, 2, '2023-11-30 18:30:00')

INSERT INTO Report (Report_ID, Date, Report_Content, User_ID, Post_ID, Comment_ID, Quiz_ID, Reporter_ID)
VALUES
    (1, '2023-12-01 14:30', 'Inappropriate content.', 1, NULL, NULL, NULL, 2),
    (2, '2023-12-02 09:45', 'Spam detected.', NULL, 2, NULL, NULL, 3),
    (3, '2023-12-03 11:15', 'Offensive language.', NULL, 3, NULL, NULL, 4),
  
    (4, '2023-12-04 15:20', 'False information.', NULL, 1, NULL, NULL, 5),
    (5, '2023-12-05 10:10', 'Harassment reported.', 5, NULL, NULL, NULL, 6),
   
    (6, '2023-12-06 16:45', 'Plagiarism detected.', NULL, 2, NULL, NULL, 7),
    (7, '2023-12-07 08:30', 'Violation of community guidelines.', NULL, NULL, 7, NULL, 8),
   
    (8, '2023-12-08 11:55', 'Cheating reported.', 8, NULL, NULL, NULL, 9),
    (9, '2023-12-09 15:00', 'Inappropriate behavior.', NULL, 2, NULL, NULL, 10),

    (10, '2023-12-10 12:45', 'Bullying reported.', NULL, NULL, 10, NULL, 11);
