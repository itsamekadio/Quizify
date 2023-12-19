use yarab1
CREATE TABLE PlayerData
(
  First_Name VARCHAR(250) NOT NULL,
  Last_Name VARCHAR(250) NOT NULL,
  Player_ID INT NOT NULL IDENTITY(1,1),
  Email VARCHAR(250) NOT NULL UNIQUE,
  playerPassword VARCHAR(250) NOT NULL,
  Rank INT  ,

  PRIMARY KEY (Player_ID)
);

CREATE TABLE AdminData
(
  Admin_ID  INT NOT NULL IDENTITY(1,1),
  
  First_Name VARCHAR(250) NOT NULL,
  Last_Name VARCHAR(250) NOT NULL,
   Email VARCHAR(250) NOT NULL UNIQUE,
   AdminPassword VARCHAR(250) NOT NULL,
  PRIMARY KEY (Admin_ID),
 
);INSERT INTO AdminData (First_Name, Last_Name,Email,AdminPassword) VALUES('b','a','d','w' )
;
Create table Authenticationcodes(
code varchar(250) not null unique  ,
)
INSERT INTO Authenticationcodes (code) VALUES('bc' )
select * from Authenticationcodes
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
  Author_ID  INT NOT NULL IDENTITY(1,1),
   First_Name VARCHAR(250) NOT NULL,
  Last_Name VARCHAR(250) NOT NULL,
 AuthorPassword VARCHAR(250) NOT NULL,
  Email VARCHAR(250) NOT NULL UNIQUE,
  Category_ID INT NOT NULL,
  PRIMARY KEY (Author_ID),
 
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
  FOREIGN KEY (User_ID) REFERENCES PlayerData(Player_ID),
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
  FOREIGN KEY (User_ID) REFERENCES PlayerData(Player_ID),
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
  FOREIGN KEY (User_ID) REFERENCES PlayerData(Player_ID),
  FOREIGN KEY (Post_ID) REFERENCES Post(Post_ID),
  FOREIGN KEY (Comment_ID, User_ID) REFERENCES Comment(Comment_ID, User_ID),
  FOREIGN KEY (Quiz_ID) REFERENCES Quiz(Quiz_ID),
  FOREIGN KEY (Reporter_ID) REFERENCES PlayerData(Player_ID)
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
