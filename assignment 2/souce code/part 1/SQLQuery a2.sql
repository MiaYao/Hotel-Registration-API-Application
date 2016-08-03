create database HotelDB

create table Hotel
(
	hotelID CHAR(4) NOT NULL PRIMARY KEY,
	hotelName VARCHAR(30),
	city CHAR(15) CHECK(city in ('Guelph', 'Kitchener', 'Waterloo'))
)

insert into Hotel
 values('4848', 'shesaier', 'Guelph')
insert into Hotel
 values('4949','shesaier','Waterloo')
insert into Hotel
 values('5050','shesaier','Kitchener')

select *from Hotel
exec sp_columns Hotel



create table Room
(
	hotelID CHAR(4) NOT NULL,
	roomNo CHAR(4) NOT NULL,
	price DECIMAL(10,2) CHECK(price>=50.00 and price<=250.00),
	type CHAR(6) CHECK(type in ('Single','Double', 'Queen', 'King')),

	PRIMARY KEY (hotelID, roomNo),
	FOREIGN KEY (hotelID) 
		REFERENCES Hotel(hotelID)
)

insert into Room values('4848','1001','50.00','Single')
insert into Room values('4848','1002','50.00','Single')
insert into Room values('4848','1003','50.00','Single')
insert into Room values('4848','2001','80.00','Double')
insert into Room values('4848','2002','80.00','Double')
insert into Room values('4848','2003','80.00','Double')
insert into Room values('4848','3001','150.00','Queen')
insert into Room values('4848','3002','150.00','Queen')
insert into Room values('4848','3003','150.00','Queen')
insert into Room values('4848','4001','250.00','King')
insert into Room values('4848','4002','250.00','King')
insert into Room values('4848','4003','250.00','King')
insert into Room values('4949','1001','50.00','Single')
insert into Room values('4949','1002','50.00','Single')
insert into Room values('4949','1003','50.00','Single')
insert into Room values('4949','2001','80.00','Double')
insert into Room values('4949','2002','80.00','Double')
insert into Room values('4949','2003','80.00','Double')
insert into Room values('4949','3001','150.00','Queen')
insert into Room values('4949','3002','150.00','Queen')
insert into Room values('4949','3003','150.00','Queen')
insert into Room values('4949','4001','250.00','King')
insert into Room values('4949','4002','250.00','King')
insert into Room values('4949','4003','250.00','King')
insert into Room values('5050','1001','50.00','Single')
insert into Room values('5050','1002','50.00','Single')
insert into Room values('5050','1003','50.00','Single')
insert into Room values('5050','2001','80.00','Double')
insert into Room values('5050','2002','80.00','Double')
insert into Room values('5050','2003','80.00','Double')
insert into Room values('5050','3001','150.00','Queen')
insert into Room values('5050','3002','150.00','Queen')
insert into Room values('5050','3003','150.00','Queen')
insert into Room values('5050','4001','250.00','King')
insert into Room values('5050','4002','250.00','King')
insert into Room values('5050','4003','250.00','King')
select *from Room
--drop table Room
exec sp_columns Room

create table Guest
(
	guestID CHAR(4) NOT NULL PRIMARY KEY,
	guestName VARCHAR(30),
	guestAddress VARCHAR(50),
	guestAffiliation VARCHAR(30)
)

insert into Guest values('0001','Kassey','10 King Street','WTO')
insert into Guest values('0002','Hannah','5 Union Street','IMF')
insert into Guest values('0003','Zoe','18 Yonge Street','IEEE')
select * from Guest
exec sp_columns Guest 

create table Booking
(
	hotelID CHAR(4) NOT NULL,
	roomNo CHAR(4) NOT NULL,
	guestID CHAR(4) NOT NULL,
	startDate DATE NOT NULL,
	endDate DATE,

	PRIMARY KEY (hotelID, roomNo, guestID, startDate),
	FOREIGN KEY (hotelID) 
		REFERENCES Hotel(hotelID),
	FOREIGN KEY (hotelID, roomNo) 
		REFERENCES Room(hotelID, roomNo),
	FOREIGN KEY (guestID)
		REFERENCES Guest(guestID)
)
insert into Booking values('4848','1003','0001','20150315','20150318')
insert into Booking values('4949','2001','0002','20150310','20150312')
insert into Booking values('5050','3001','0003','20150316','20150416')
select * from Booking
exec sp_columns Booking
