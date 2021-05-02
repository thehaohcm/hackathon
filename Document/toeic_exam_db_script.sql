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
    question varchar(500) not null,
    option_1 varchar(50) not null,
    option_2 varchar(50) not null,
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