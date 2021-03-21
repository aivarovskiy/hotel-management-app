-- create database
create database kursdb;

go

use kursdb;

go

-- create tables
create table payment_types
(
    payment_type_id int primary key not null identity(1,1),
    payment_type_name nvarchar(255) unique not null
);

create table categories
(
    category_id int primary key not null identity(1,1),
    category_name nvarchar(255) unique not null,
    price money not null,
    tv bit
);

create table rooms
(
    room_id int primary key not null identity(1,1),
    room_number int unique not null,
    room_category int,
    number_of_beds int not null,
    foreign key(room_category) references categories(category_id) on delete cascade
);

create table reservations
(
    reservation_id int primary key not null identity(1,1),
    check_in date not null,
    check_out date not null,
    number_of_people int not null,
    payment_type int,
    foreign key (payment_type) references payment_types(payment_type_id) on delete cascade
);

create table clients
(
    client_id int primary key not null identity(1,1),
    client_room int,
    client_reservation int,
    firstname nvarchar(255) not null,
    middlename nvarchar(255) not null,
    lastname nvarchar(255) not null,
    invoice money,
    foreign key (client_room) references rooms(room_id) on delete cascade,
    foreign key (client_reservation) references reservations(reservation_id) on delete cascade
);

go

-- create indexes
create index lastname_index on clients(lastname);
create index room_number_index on rooms(room_number);

go

-- create view
create view view_view
as
    select
        client_id,
        firstname 'Имя',
        middlename 'Среднее имя',
        lastname 'Фамилия',
        room_number 'Комната',
        category_name 'Категория',
        check_in 'Дата Заезда',
        check_out 'Дата Выписки'
    from
        rooms
        inner join clients on client_room=room_id
        inner join reservations on client_reservation=reservation_id
        inner join categories on room_category=category_id;

go

-- create procedures

create procedure categories_insert
    (@name nvarchar(255),
    @price money,
    @tv bit)
as
begin
    insert into categories
        (category_name,price,tv)
    values
        (@name, @price, @tv)
end;

go

create procedure categories_update
    (@id int,
    @name nvarchar(255),
    @price money,
    @tv bit)
as
begin
    update categories set category_name=@name,price=@price,tv=@tv where category_id=@id
end;

go

create procedure categories_delete
    (@id int)
as
begin
    delete from categories where category_id=@id
end;

go

create procedure clients_insert
    (@client_room int,
    @client_reservation int,
    @firstname nvarchar(255),
    @middlename nvarchar(255),
    @lastname nvarchar(255))
as
begin
    insert into clients
        (client_room,client_reservation,firstname,middlename,lastname)
    values
        (@client_room, @client_reservation, @firstname, @middlename, @lastname)
end;

go

create procedure clients_update
    (@id int,
    @client_room int,
    @client_reservation int,
    @firstname nvarchar(255),
    @middlename nvarchar(255),
    @lastname nvarchar(255))
as
begin
    update clients set client_room=@client_room,client_reservation=@client_reservation,firstname=@firstname,middlename=@middlename,lastname=@lastname where client_id=@id
end;

go

create procedure clients_delete
    (@id int)
as
begin
    delete from clients where client_id=@id
end;

go

create procedure pt_insert
    (@name nvarchar(255))
as
begin
    insert into payment_types
        (payment_type_name)
    values
        (@name)
end;

go

create procedure pt_update
    (@id int,
    @name nvarchar(255))
as
begin
    update payment_types set payment_type_name=@name where payment_type_id=@id
end;

go

create procedure pt_delete
    (@id int)
as
begin
    delete from payment_types where payment_type_id=@id
end;

go

create procedure res_insert
    (@ci date,
    @co date,
    @nop int,
    @pt int)
as
begin
    insert into reservations
        (check_in,check_out,number_of_people,payment_type)
    values
        (@ci, @co, @nop, @pt)
end;

go

create procedure res_update
    (@id int,
    @ci date,
    @co date,
    @nop int,
    @pt int)
as
begin
    update reservations set check_in=@ci,check_out=@co,number_of_people=@nop,payment_type=@pt where reservation_id=@id
end;

go

create procedure res_delete
    (@id int)
as
begin
    delete from reservations where reservation_id=@id
end;

go

create procedure room_insert
    (@rn int,
    @rc int,
    @nob int)
as
begin
    insert into rooms
        (room_number,room_category,number_of_beds)
    values
        (@rn, @rc, @nob)
end;

go

create procedure room_update
    (@id int,
    @rn int,
    @rc int,
    @nob int)
as
begin
    update rooms set room_number=@rn,room_category=@rc,number_of_beds=@nob where room_id=@id
end;

go

create procedure room_delete
    (@id int)
as
begin
    delete from rooms where room_id=@id
end;

go

-- create functions
create function daycount(@id int) returns int as
begin
    declare @cl_res int
    declare @date1 date
    declare @date2 date
    select @cl_res = client_reservation
    from clients
    where client_id = @id
    select @date1 = check_in
    from reservations
    where reservation_id = @cl_res
    select @date2 = check_out
    from reservations
    where reservation_id = @cl_res
    return datediff(d,@date1,@date2)
end

go

create function sh_cat() returns table as return select *
from categories

go

create procedure price110
as
begin
    begin transaction
    begin try
        declare cur cursor for
            select category_id, price
    from categories
        declare @id int
        declare @price money
        open cur
        fetch next from cur into @id, @price
        while @@fetch_status = 0
        begin
        update categories
            set price=@price*1.1
            where current of cur
        fetch next from cur into @id, @price
    end
        close cur
        deallocate cur
        select *
    from dbo.sh_cat()
        commit;
    end try
    begin catch
        if @@error <> 0 rollback;
    end catch
end

go

-- create triggers
create trigger trg_a_ins
on clients after insert as
begin
    update clients set invoice = (dbo.daycount((select client_id
    from inserted))*(select price
    from categories
    where category_id = (select room_category
    from rooms
    where room_id = (select client_room
    from inserted)))) where client_id = (select client_id
    from inserted)
end

go

create trigger trg_a_upd
on reservations
after update
as
begin
    if (update(check_out))
    begin
        declare cur cursor for
            select client_id
        from clients
        where client_reservation = (select reservation_id
        from deleted)
        declare @id int
        open cur
        fetch next from cur into @id
        while @@fetch_status = 0
        begin
            update clients
            set invoice = dbo.daycount(@id)*(
                select price
            from categories
            where category_id = (
                    select room_category
            from rooms
            where room_id = (
                        select client_room
            from clients
            where client_id = @id
                    )
                )
            )
            where current of cur
            fetch next from cur into @id
        end
        close cur
        deallocate cur
    end
end

go

create trigger trg_a_del
on clients after delete as
begin
    if (select count(1)
    from clients
    where client_reservation in (select client_reservation
    from deleted)) = 0
delete from reservations where reservation_id in (select client_reservation
    from deleted)
end

go

-- create users
create login guest with password='Us3rP4ssw0rd!'
create user userguest for login guest
grant select on dbo.categories to userguest
grant select on dbo.clients to userguest
grant select on dbo.payment_types to userguest
grant select on dbo.reservations to userguest
grant select on dbo.rooms to userguest
grant select on dbo.view_view to userguest
grant select on dbo.sh_cat to userguest

go

create login admin with password='Adm1nP4ssw0rd!'
create user useradmin for login admin
grant select, insert, update, delete on dbo.categories to useradmin
grant select, insert, update, delete on dbo.clients to useradmin
grant select, insert, update, delete on dbo.payment_types to useradmin
grant select, insert, update, delete on dbo.reservations to useradmin
grant select, insert, update, delete on dbo.rooms to useradmin
grant select on dbo.view_view to useradmin
grant select on dbo.sh_cat to useradmin
grant execute to useradmin