drop schema if exists toeic_exam_db;
create schema toeic_exam_db;
use toeic_exam_db;

drop table if exists TOPIC;
create table TOPIC (
	id int not null primary key auto_increment,
	`name` nvarchar(25) not null,
    `description` nvarchar(75)
);

drop table if exists DIFFICULTY_LEVEL;
create table DIFFICULTY_LEVEL (
	id int not null primary key auto_increment,
	`name` nvarchar(25) not null,
    `description` nvarchar(75)
);

drop table if exists EXAM;
create table EXAM (
	`code` nvarchar(5) not null primary key,
    `description` nvarchar(75)
);

drop table if exists QUESTION;
create table QUESTION (
	id int not null primary key auto_increment,
    topic_id int not null,
    difficulty_level_id int not null,
    question varchar(500),
    option_1 varchar(50),
    option_2 varchar(50),
    option_3 varchar(50),
    option_4 varchar(50),
    correct_answer varchar(50) not null,
    multipart blob,
    is_active bool not null default 1,
    foreign key (topic_id) references TOPIC(id),
    foreign key (difficulty_level_id) references DIFFICULTY_LEVEL(id)
);

drop table if exists EXAM_QUESTION;
create table EXAM_QUESTION (
	exam_code nvarchar(5) not null,
    question_id int not null,
    primary key(exam_code,question_id),
    foreign key (exam_code) references EXAM(`code`),
    foreign key (question_id) references QUESTION(id)
);

drop table if exists `USER`;
create table `USER`(
	email nvarchar(50) not null primary key,
    `name` nvarchar(50) not null,
    is_active boolean default 1,
    current_report int
);

drop table if exists REPORT;
create table REPORT (
	id int not null primary key,
    email nvarchar(50) not null,
    score int not null default 0,
    exam_code nvarchar(5) not null,
    started_time timestamp,
    expired_time timestamp,
    reported_date timestamp default CURRENT_TIMESTAMP,
    answer_list json,
    foreign key (exam_code) references EXAM(`code`),
    foreign key(email) references `USER`(email)
);

alter table `USER` add foreign key(current_report) references REPORT(id);

INSERT INTO `toeic_exam_db`.`DIFFICULTY_LEVEL` (`id`, `name`, `description`) VALUES (1, 'Easy', NULL);
INSERT INTO `toeic_exam_db`.`DIFFICULTY_LEVEL` (`id`, `name`, `description`) VALUES (2, 'Normal', NULL);
INSERT INTO `toeic_exam_db`.`DIFFICULTY_LEVEL` (`id`, `name`, `description`) VALUES (3, 'Hard', NULL);
INSERT INTO `toeic_exam_db`.`DIFFICULTY_LEVEL` (`id`, `name`, `description`) VALUES (4, 'Very Hard', NULL);

INSERT INTO `toeic_exam_db`.`TOPIC` (`id`, `name`, `description`) VALUES (1, 'Picture Description', NULL);
INSERT INTO `toeic_exam_db`.`TOPIC` (`id`, `name`, `description`) VALUES (2, 'Question - Response', NULL);
INSERT INTO `toeic_exam_db`.`TOPIC` (`id`, `name`, `description`) VALUES (3, 'Short Conversations', NULL);
INSERT INTO `toeic_exam_db`.`TOPIC` (`id`, `name`, `description`) VALUES (4, 'Short Talks', NULL);
INSERT INTO `toeic_exam_db`.`TOPIC` (`id`, `name`, `description`) VALUES (5, 'Incomplete Sentences', NULL);
INSERT INTO `toeic_exam_db`.`TOPIC` (`id`, `name`, `description`) VALUES (4, 'Text Completion', NULL);
INSERT INTO `toeic_exam_db`.`TOPIC` (`id`, `name`, `description`) VALUES (6, 'Reading Comprehension', NULL);

INSERT INTO `toeic_exam_db`.`QUESTION` (`id`, `topic_id`, `difficulty_level_id`, `question`, `option_1`, `option_2`, `option_3`, `option_4`, `correct_answer`, `multipart`, `is_active`) VALUES (1, 5, 2, 'Departmental restructing will be discussed at the ___ monthly meeting', 'next', 'always', 'soon', 'like', 'next', NULL, 1);
INSERT INTO `toeic_exam_db`.`QUESTION` (`id`, `topic_id`, `difficulty_level_id`, `question`, `option_1`, `option_2`, `option_3`, `option_4`, `correct_answer`, `multipart`, `is_active`) VALUES (2, 5, 2, 'To keep ___ park beautiful, please place your nonrecyclables in the available trash cans', 'our', 'we', 'us', 'ours', 'our', NULL, 1);
INSERT INTO `toeic_exam_db`.`QUESTION` (`id`, `topic_id`, `difficulty_level_id`, `question`, `option_1`, `option_2`, `option_3`, `option_4`, `correct_answer`, `multipart`, `is_active`) VALUES (3, 5, 2, 'Mr. Hardin ___ additional images of the office building he is interested in leasing', 'informed', 'asked', 'advised', 'requested', 'asked', NULL, DEFAULT);
