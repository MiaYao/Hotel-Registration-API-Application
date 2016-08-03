--populate the database with the information for the individual rooms in the area hotels
create procedure PopulateHotelRooms
(@hid CHAR(4), @noFloors INT, @noFRooms INT )
as 
	declare @Floor INT;
	declare @Room INT;
	declare @RoomNo CHAR(4);

begin 
		if @noFloors not between 1 and 99 return;	
		if @noFRooms not between 1 and 99 return;
		
		set @Floor = 1;
		set @Room = 1;

		while @Floor <= @noFloors
		begin
			set @Room = 1; 
			while @Room <= @noFRooms
			begin
				if @Floor<10 
					set @RoomNo = concat('0',cast(@Floor*100+@Room as CHAR(3)));
				else
					set @RoomNo = cast(@Floor*100+@Room as CHAR(4));
			set @Room = @Room +1;
			insert into Room values(@hid,@RoomNo,'50.00','Double')
			end
		set @Floor = @Floor +1;
		end
end;
exec PopulateHotelRooms '4848',2,2;


create trigger BookingConfliction_Insert on Booking instead of insert 
as
	declare @hotelID CHAR(4);
	declare @roomNo CHAR(4);
	declare @guestID CHAR(4);
	declare @startDate DATE;
	declare @endDate DATE;
	declare @error VARCHAR(10);

begin
	set @error='You cannot execute this operation!';
	select @hotelID=hotelID, @roomNo=roomNo, @guestID=guestID, @startDate=startDate,@endDate=endDate
	from inserted

	if  ( exists(
				select hotelID,roomNo
				from Booking
				where Booking.hotelID = @hotelID 
					and Booking.roomNo = @roomNo
					and (
							
						 
								hotelID in (
										select hotelID
										from Booking
										where (startDate < @startDate and endDate > @endDate)
											or((Booking.startDate >= @startDate and Booking.startDate < @endDate)) 
											or ((Booking.endDate > @startDate and Booking.endDate <= @endDate))
											)				
							and 
								roomNo in (
										select roomNo
										from Booking
										where (startDate < @startDate and endDate > @endDate)
											or((Booking.startDate >= @startDate and Booking.startDate < @endDate)) 
											or ((Booking.endDate > @startDate and Booking.endDate <= @endDate))
									 	 )
				   	     	
						)
				)
		)
	begin
		raiserror ('Your booking is conflicting with our database!',8,1,@error);
		rollback transaction;
		return
	end;
	
	else
	begin
		insert into Booking(hotelID, roomNo, guestID, startDate, endDate) values (@hotelID,@roomNo,@guestID,@startDate,@endDate)
	end;
end;


--DROP TRIGGER BookingConfliction_Insert


create trigger BookingConfliction_Update on Booking instead of update
as
	declare @hotelID char(4);
	declare @roomNo char(4);
	declare @guestID char(4);
	declare @startDate date;
	declare @endDate date;
	declare @oldstartDate date;
	declare @oldendDate date;
	declare @error varchar(10);

begin
	set @error='This is error';
	select @hotelID=hotelID, @roomNo=roomNo, @guestID=guestID, @startDate=startDate,@endDate=endDate
	from inserted
	select @oldstartDate=startDate,@oldendDate=endDate
	from DELETED

	delete from Booking where hotelID=@hotelID and roomNo=@roomNo and guestID =@guestID and startDate=@oldstartDate and endDate=@oldendDate
	if  (
			(
			exists(
				select hotelID,roomNo
				from Booking
				where Booking.hotelID = @hotelID 
					and Booking.roomNo = @roomNo
					and (
							
							hotelID in (
									select hotelID
									from Booking
									where (startDate < @startDate and endDate > @endDate)
										or ((Booking.startDate >= @startDate AND Booking.startDate < @endDate)) 
										or ((Booking.endDate > @startDate AND Booking.endDate <= @endDate))
											)				
						and 
							roomNo in (
									select roomNo
									from Booking
									where (startDate < @startDate and endDate > @endDate)
										or ((Booking.startDate >= @startDate AND Booking.startDate < @endDate)) 
										or ((Booking.endDate > @startDate AND Booking.endDate <= @endDate))
											)
							
						)
					)
			)
		)
	begin
		raiserror ('Your booking is conflicting with our database!',5,1,@error);
		rollback transaction;
		return
	end;
	
	else
	begin
		insert into Booking(hotelID, roomNo,guestID, startDate,endDate) values (@hotelID,@roomNo,@guestID,@startDate,@endDate)
	end;
end;


--DROP TRIGGER BookingConfliction_Update
