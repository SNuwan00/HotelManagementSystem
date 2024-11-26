# HotelManagementSystem
This Hotel Management System, built in C#, demonstrates the use of the Decorator Pattern along with the Singleton Pattern for specific functionalities. Focused on learning design patterns, it strictly adheres to Decorator principles. Though limited in scope, it serves as a valuable resource for developers exploring design patterns in C#.


Open ssms Server and create "hotel_management_system_database" Database.
then create Tables. Use belove Queries to do that.


create database hotel_management_system_database;

use hotel_management_system_database;

create table customers(name varchar(45),nic char(12) primary key);

create table billing_data(nic char(12),date date, string, time time,room_type varchar(15), parking bit, luggage bit, cleaning bit, room_service bit, bar bit, pool bit, spa  bit, wellness bit,FOREIGN KEY (nic) REFERENCES customers(nic));

You have to replace "Server Name" with your SSMS Server Name.
Changes are Needed in 30th line in EnterUserInformation.cs File and 25th,63rd and 100th lines in HistoryForm.cs File. 
