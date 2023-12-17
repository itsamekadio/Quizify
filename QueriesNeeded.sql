-- Sign-Up Page
-- Add a new user to the UserData table.
INSERT INTO UserData (First_Name, Last_Name, User_ID, Email, UserPassword)
VALUES ('John', 'Doe', 1, 'john.doe@example.com', 'hashed_password');

-- Check if the provided email already exists in the UserData table.
SELECT COUNT(*) FROM UserData WHERE Email = 'john.doe@example.com';

-- Sign-In Page
-- Authenticate a user based on provided email and hashed password.
SELECT * FROM UserData WHERE Email = 'john.doe@example.com' AND UserPassword = 'hashed_password';

-- Room Page (View All Users)
-- Get all users in a specific room.
SELECT PlayerData.Player_ID, UserData.First_Name, UserData.Last_Name
FROM PlayerData
JOIN UserData ON PlayerData.Player_ID = UserData.User_ID
WHERE PlayerData.Room_ID = 1;

-- Remove a user from a room based on user ID and room ID.
DELETE FROM PlayerData WHERE Player_ID = 1 AND Room_ID = 1;

-- Leaderboard Page
-- Get top players.
SELECT PlayerData.Player_ID, UserData.First_Name, UserData.Last_Name, PlayerData.Rank
FROM PlayerData
JOIN Leaderboard_Players ON PlayerData.Player_ID = Leaderboard_Players.Player_ID
WHERE Leaderboard_Players.Leaderboard_ID = 1
ORDER BY PlayerData.Rank ASC;

-- User Profile Page
-- Get user profile information.
SELECT UserData.First_Name, UserData.Last_Name, UserData.Email, PlayerData.Rank
FROM UserData
LEFT JOIN PlayerData ON UserData.User_ID = PlayerData.Player_ID
WHERE UserData.User_ID = 1;

-- Friends List Page
-- Get a user's friends.
SELECT UserData.First_Name, UserData.Last_Name, PlayerData.Rank
FROM Is_Friend
JOIN UserData ON Is_Friend.Frien_Player_ID = UserData.User_ID
JOIN PlayerData ON Is_Friend.Frien_Player_ID = PlayerData.Player_ID
WHERE Is_Friend.Player_ID = 1;

-- Quiz Score History Page
-- Get quiz score history.
SELECT Quiz.Title, Score_history.score, Score_history.Date_time
FROM Score_history
JOIN Quiz ON Score_history.SQuiz_id = Quiz.Quiz_ID
WHERE Score_history.Splayer_id = 1
ORDER BY Score_history.Date_time DESC;

-- Report Page
-- Insert a new report.
INSERT INTO Report (Date, Report_Content, Reporter_ID)
VALUES ('2023-01-01', 'Inappropriate content', 1);

-- Admin Reports Page
-- Get admin's assigned reports.
SELECT Report.Report_ID, Report.Date, Report.Report_Content, UserData.First_Name, UserData.Last_Name
FROM Admin_Reports_Assigned
JOIN Report ON Admin_Reports_Assigned.Report_ID = Report.Report_ID
JOIN UserData ON Report.User_ID = UserData.User_ID
WHERE Admin_Reports_Assigned.Admin_ID = 1;

-- Update report resolution.
UPDATE Report SET Resolution = 'Resolved' WHERE Report_ID = 1;

-- Permissions Page
-- Get admin permissions.
SELECT Permissions.Permission
FROM Admin_Permissions
JOIN Permissions ON Admin_Permissions.Per_ID = Permissions.Per_ID
WHERE Admin_Permissions.Admin_ID = 1;

-- Stream Page
-- Get posts in a room.
SELECT Post.Post_ID, Post.Date_Time, Post.Content, UserData.First_Name, UserData.Last_Name
FROM Post
JOIN UserData ON Post.User_ID = UserData.User_ID
WHERE Post.Room_ID = 1
ORDER BY Post.Date_Time DESC;

-- Add a new post.
INSERT INTO Post (Date_Time, Content, Type_ID, User_ID, Room_ID)
VALUES ('2023-01-01', 'New post content', 1, 1, 1);

-- Get comments for a post.
SELECT Comment.Comment_ID, Comment.Content, UserData.First_Name, UserData.Last_Name
FROM Comment
JOIN UserData ON Comment.User_ID = UserData.User_ID
WHERE Comment.Post_ID = 1
ORDER BY Comment.Date_Time DESC;

-- Add a new comment.
INSERT INTO Comment (Content, User_ID, Post_ID)
VALUES ('New comment content', 1, 1);

-- Quiz Page
-- Get quiz details.
SELECT * FROM Quiz WHERE Quiz_ID = 1;

-- Get quiz questions.
SELECT * FROM Questions WHERE Quiz_ID = 1 ORDER BY Questions_order;

-- Get quiz participants.
SELECT PlayerData.Player_ID, UserData.First_Name, UserData.Last_Name
FROM quiz_participants
JOIN PlayerData ON quiz_participants.Participant_id = PlayerData.Player_ID
JOIN UserData ON PlayerData.Player_ID = UserData.User_ID
WHERE quiz_participants.PQuiz_ID = 1;

-- Insert quiz participant.
INSERT INTO quiz_participants (PQuiz_ID, Participant_id)
VALUES (1, 1);

-- Get quiz scores.
SELECT PlayerData.Player_ID, UserData.First_Name, UserData.Last_Name, Score_history.score, Score_history.Date_time
FROM Score_history
JOIN PlayerData ON Score_history.Splayer_id = PlayerData.Player_ID
JOIN UserData ON PlayerData.Player_ID = UserData.User_ID
WHERE Score_history.SQuiz_id = 1
ORDER BY Score_history.score DESC;

-- Insert quiz score.
INSERT INTO Score_history (Splayer_id, score, SQuiz_id, Date_time)
VALUES (1, 80, 1, '2023-01-01 12:00:00');
