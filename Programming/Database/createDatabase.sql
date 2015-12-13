use poca_local

create table User_tb (id int primary key, first_name varchar(255) NOT NULL, last_name varchar(255) NOT NULL, email varchar(255) NOT NULL unique, username varchar(255) NOT NULL unique, password varchar(255) NOT NULL, birthdate date NOT NULL, imageURL varchar(255) )
create table Appointment (id int primary key, date_of date NOT NULL, hour_of time NOT NULL, is_reserved bit NOT NULL)
create table Service (id int primary key, name varchar(255) NOT NULL, description_of varchar(255) NOT NULL, price float NOT NULL, is_available bit NOT NULL)
create table Passion (id int primary key, name varchar(255) NOT NULL UNIQUE, description_of varchar(255) NOT NULL)