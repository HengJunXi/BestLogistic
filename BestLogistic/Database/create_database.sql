USE best_logistic;

DROP TABLE IF EXISTS dbo.staff
DROP TABLE IF EXISTS dbo.parcel_trip
DROP TABLE IF EXISTS dbo.trip
DROP TABLE IF EXISTS dbo.transport
DROP TABLE IF EXISTS dbo.pick_up_info
DROP TABLE IF EXISTS dbo.parcel
DROP TABLE IF EXISTS dbo.parcel_status
DROP TABLE IF EXISTS dbo.[user]
DROP TABLE IF EXISTS dbo.id_type

CREATE TABLE dbo.id_type 
(
	id tinyint IDENTITY PRIMARY KEY,
	[type] varchar(255)
)

CREATE TABLE dbo.[user]
(
	[uid] uniqueidentifier DEFAULT NEWID(),
	password_hash varchar(255),
	hash_salt varchar(255) unique,
	email varchar(254) unique,
	phone_number varchar(15),
	home_number varchar(15),
	[name] varchar(255),
	id_type tinyint, 
	id_number varchar(255),
	date_of_birth date,
	[address] varchar(255),
	[location] varchar(70),
	postcode char(5), 
	picture_url varchar(255),
	PRIMARY KEY ([uid]),
	FOREIGN KEY (id_type) REFERENCES dbo.id_type,
	FOREIGN KEY (postcode, [location]) REFERENCES dbo.postcode
)

CREATE TABLE dbo.parcel_status
(
	id tinyint IDENTITY PRIMARY KEY,
	status varchar(255)
)

CREATE TABLE dbo.parcel 
(
	tracking_number int IDENTITY(1000000000,1),
	[service] bit,
	[type] bit,
	pieces tinyint,
	content varchar(255),
	[value] decimal(19,2),
	[weight] real,
	date_created datetime DEFAULT getdate(),
	delivery_fee decimal(19,2),
	pick_up_fee decimal(19,2),
	[user_uid] uniqueidentifier,
	sender_name varchar(255),
	sender_id_type tinyint,
	sender_id_number varchar(255),
	sender_phone varchar(15),
	sender_email varchar(254),
	sender_address varchar(255),
	sender_location varchar(70),
	sender_postcode char(5),
	receiver_name varchar(255),
	receiver_phone varchar(15),
	receiver_email varchar(254),
	receiver_address varchar(255),
	receiver_location varchar(70),
	receiver_postcode char(5),
	--status tinyint,
	deleted bit DEFAULT 0,
	PRIMARY KEY (tracking_number),
	FOREIGN KEY ([user_uid]) REFERENCES dbo.[user],
	FOREIGN KEY (sender_id_type) REFERENCES dbo.id_type,
	FOREIGN KEY (sender_postcode, sender_location) REFERENCES dbo.postcode,
	FOREIGN KEY (receiver_postcode, receiver_location) REFERENCES dbo.postcode,
	--FOREIGN KEY (status) REFERENCES dbo.parcel_status
)

CREATE TABLE dbo.pick_up_info
(
	tracking_number int,
	pick_up_date date,
	pick_up_time time,
	remark varchar(511),
	PRIMARY KEY (tracking_number),
	FOREIGN KEY (tracking_number) REFERENCES dbo.parcel
)

CREATE TABLE dbo.transport
(
	plate_number varchar(255) PRIMARY KEY,
	car_model varchar(255)
)

--CREATE TABLE dbo.tracking
--(
--	tracking_number uniqueidentifier,
--	trip tinyint,
--	plate_number varchar(255),
--	departure_point varchar(255),
--	arrival_point varchar(255),
--	departure_datetime datetime,
--	arrival_datetime datetime,
--	status bit,
--	PRIMARY KEY (tracking_number, trip),
--	FOREIGN KEY (tracking_number) REFERENCES dbo.parcel,
--	FOREIGN KEY (departure_point) REFERENCES dbo.point,
--	FOREIGN KEY (arrival_point) REFERENCES dbo.point,	
--)

CREATE TABLE dbo.trip
(
	trip_id uniqueidentifier DEFAULT newid(),
	date_created datetime DEFAULT getdate(),
	departure_point varchar(255),
	arrival_point varchar(255),
	departure_datetime datetime,
	arrival_datetime datetime,
	plate_number varchar(255),
	[status] tinyint,
	PRIMARY KEY (trip_id),
	FOREIGN KEY (plate_number) REFERENCES dbo.transport,
	FOREIGN KEY (departure_point, arrival_point) REFERENCES dbo.route,
)

CREATE TABLE dbo.parcel_trip
(
	trip_id uniqueidentifier,
	tracking_number int,
	PRIMARY KEY (trip_id, tracking_number),
	FOREIGN KEY (trip_id) REFERENCES dbo.trip,
	FOREIGN KEY (tracking_number) REFERENCES dbo.parcel,
)

CREATE TABLE dbo.staff
(
	[uid] uniqueidentifier DEFAULT NEWID(),
	branch_id varchar(255),
	staff_id int IDENTITY(10000, 1),
	[name] varchar(255),
	password_hash varchar(255),
	hash_salt varchar(255) unique,
	PRIMARY KEY ([uid]),
	FOREIGN KEY (branch_id) REFERENCES dbo.point,
)

INSERT INTO [dbo].[id_type] ([type]) VALUES ('IC Number'), ('Old IC Number'), ('Passport');

INSERT INTO parcel_status ([status]) VALUES ('Pending'), ('Pick-up'), ('In transit'), ('Out of delivery'), ('Delivered');

INSERT INTO transport VALUES 
('WC3456', 'Grey Van'),
('WK6785', 'White Van');

INSERT INTO [user] (uid, password_hash, hash_salt, email, name, id_type, id_number, date_of_birth) VALUES 
('2E075DF1-7144-4077-B925-000AA23DC10F', 'NNSYPl6OI60v+eC50qdN55E24fc=', 'oNXKoe2TCAwboEV9rk76eQ==', 'heng@heng.com', 'Heng Jun Xi', 1, '980510080000', '1998-05-10'),
('6F99B241-7C39-4957-8A9B-7EEEE8A7BF2A', '/o+xUzI3ZR6l/G8d15q/wv6ySgY=', 'Qx8Pk3B1ZSc19pZCFLChvw==', 'loh@loh.com', 'Loh Shu Yi', 1, '980330080000', '1998-03-30'),
('C1713FC0-118D-4650-9314-26480E210F8D', 'yCV9BB0Zha9pMyuZ7Bn/4Py1Qqk=', 'lavcNAWHs5Nr7722Lxw6gg==', 'lim@lim.com', 'Lim Carol', 1, '980327080000', '1998-03-27');

INSERT INTO staff (uid, password_hash, hash_salt, branch_id, name) VALUES 
('2E075DF1-7144-4077-B925-000AA23DC10F', 'NNSYPl6OI60v+eC50qdN55E24fc=', 'oNXKoe2TCAwboEV9rk76eQ==', 'ChIJRb7LRg02zDERETaXXhc-QyU', 'Heng Jun Xi'),
('6F99B241-7C39-4957-8A9B-7EEEE8A7BF2A', '/o+xUzI3ZR6l/G8d15q/wv6ySgY=', 'Qx8Pk3B1ZSc19pZCFLChvw==', 'ChIJ7ciSyEquSjARqdvRktxutKI', 'Loh Shu Yi'),
('C1713FC0-118D-4650-9314-26480E210F8D', 'yCV9BB0Zha9pMyuZ7Bn/4Py1Qqk=', 'lavcNAWHs5Nr7722Lxw6gg==', 'ChIJTfBUxjVs2jER3vZ-g6U8JkI', 'Lim Carol');

--INSERT INTO parcel (user_uid, sender_id_type, type, pieces, value, weight, delivery_fee, service, pick_up_fee, sender_postcode, sender_location, receiver_postcode, receiver_location) VALUES
--(null, 1, 0, 1, 10, 1, 5, 0, 0, '50460', 'Wisma Putra', '81800', 'Kampung AC Batu 18'),
--(null, 1, 0, 5, 10, 4, 10, 1, 5, '81800', 'Kampung AC Batu 18', '14300', 'Taman Pekaka'),
--(null, 1, 1, 3, 2, 0.5, 4.5, 1, 1.5, '14300', 'Taman Pekaka', '50460', 'Wisma Putra');

--INSERT INTO trip (departure_point, arrival_point, status) VALUES 
--('ChIJw06LDtrFzTER578ZF_6Z-gg', NULL, 0),
--('ChIJw06LDtrFzTER578ZF_6Z-gg', NULL, 1),
--('ChIJw06LDtrFzTER578ZF_6Z-gg', 'ChIJ7ZqvbEzKzTER-r67V-ufxtg', 2),
--('ChIJw06LDtrFzTER578ZF_6Z-gg', NULL, 3),
--('ChIJ7ZqvbEzKzTER-r67V-ufxtg', NULL, 0),
--('ChIJ7ZqvbEzKzTER-r67V-ufxtg', NULL, 1),
--('ChIJ7ZqvbEzKzTER-r67V-ufxtg', 'ChIJw06LDtrFzTER578ZF_6Z-gg', 2),
--('ChIJ7ZqvbEzKzTER-r67V-ufxtg', NULL, 3),
--('ChIJ7ZqvbEzKzTER-r67V-ufxtg', NULL, 0),
--('ChIJ7ZqvbEzKzTER-r67V-ufxtg', NULL, 1),
--('ChIJ7ZqvbEzKzTER-r67V-ufxtg', 'ChIJNWxC8VmzzTERVQYzQ66uwCM', 2),
--('ChIJ7ZqvbEzKzTER-r67V-ufxtg', NULL, 3),
--('ChIJNWxC8VmzzTERVQYzQ66uwCM', NULL, 0),
--('ChIJNWxC8VmzzTERVQYzQ66uwCM', NULL, 1),
--('ChIJNWxC8VmzzTERVQYzQ66uwCM', 'ChIJ7ZqvbEzKzTER-r67V-ufxtg', 2),
--('ChIJNWxC8VmzzTERVQYzQ66uwCM', NULL, 3),
--('ChIJNWxC8VmzzTERVQYzQ66uwCM', NULL, 0),
--('ChIJNWxC8VmzzTERVQYzQ66uwCM', NULL, 1),
--('ChIJNWxC8VmzzTERVQYzQ66uwCM', 'ChIJIeom6DpOzDERFh89Ox4KCig', 2),
--('ChIJNWxC8VmzzTERVQYzQ66uwCM', NULL, 3),
--('ChIJIeom6DpOzDERFh89Ox4KCig', NULL, 0),
--('ChIJIeom6DpOzDERFh89Ox4KCig', NULL, 1),
--('ChIJIeom6DpOzDERFh89Ox4KCig', 'ChIJNWxC8VmzzTERVQYzQ66uwCM', 2),
--('ChIJIeom6DpOzDERFh89Ox4KCig', NULL, 3),
--('ChIJIeom6DpOzDERFh89Ox4KCig', NULL, 0),
--('ChIJIeom6DpOzDERFh89Ox4KCig', NULL, 1),
--('ChIJIeom6DpOzDERFh89Ox4KCig', 'ChIJoxijCENpzDERzC5DDRq2J8E', 2),
--('ChIJIeom6DpOzDERFh89Ox4KCig', NULL, 3),
--('ChIJoxijCENpzDERzC5DDRq2J8E', NULL, 0),
--('ChIJoxijCENpzDERzC5DDRq2J8E', NULL, 1),
--('ChIJoxijCENpzDERzC5DDRq2J8E', 'ChIJIeom6DpOzDERFh89Ox4KCig', 2),
--('ChIJoxijCENpzDERzC5DDRq2J8E', NULL, 3),
--('ChIJoxijCENpzDERzC5DDRq2J8E', NULL, 0),
--('ChIJoxijCENpzDERzC5DDRq2J8E', NULL, 1),
--('ChIJoxijCENpzDERzC5DDRq2J8E', 'ChIJexR2dy6TyjERVqDwNY8buBo', 2),
--('ChIJoxijCENpzDERzC5DDRq2J8E', NULL, 3),
--('ChIJexR2dy6TyjERVqDwNY8buBo', NULL, 0),
--('ChIJexR2dy6TyjERVqDwNY8buBo', NULL, 1),
--('ChIJexR2dy6TyjERVqDwNY8buBo', 'ChIJoxijCENpzDERzC5DDRq2J8E', 2),
--('ChIJexR2dy6TyjERVqDwNY8buBo', NULL, 3),
--('ChIJexR2dy6TyjERVqDwNY8buBo', NULL, 0),
--('ChIJexR2dy6TyjERVqDwNY8buBo', NULL, 1),
--('ChIJexR2dy6TyjERVqDwNY8buBo', 'ChIJ7ciSyEquSjARqdvRktxutKI', 2),
--('ChIJexR2dy6TyjERVqDwNY8buBo', NULL, 3),
--('ChIJ7ciSyEquSjARqdvRktxutKI', NULL, 0),
--('ChIJ7ciSyEquSjARqdvRktxutKI', NULL, 1),
--('ChIJ7ciSyEquSjARqdvRktxutKI', 'ChIJexR2dy6TyjERVqDwNY8buBo', 2),
--('ChIJ7ciSyEquSjARqdvRktxutKI', NULL, 3);


insert into parcel (tracking_number, service, type, pieces, content, value, weight, delivery_fee, 
pick_up_fee, sender_name, sender_id_type, sender_id_number, sender_phone, 
sender_email, sender_address, sender_location, sender_postcode, receiver_name,
receiver_phone, receiver_email, receiver_address, receiver_location, 
receiver_postcode) VALUES 
(1000000000, 0, 0, 3, 'Merchandises', 69.9, 2.7, 10.9, 0, 'Johnny English', 1, 
'960316087732', '0123456789', 'johnny@english.com', 'Xiamen University Malaysia, Jalan Sunsuria',
'Bandar Baru Salak Tinggi', '43900', 'Harry Potter', '0142356789', 'harry@potter.com',
'No. 11, Jalan Pekaka', 'Taman Pekaka', '14300'),

(1000000001, 0, 1, 4, 'Documents', 5, 0.1, 5, 0, 'Anthony Brown', 1, 
'970228126534', '0123456789', 'anthony@brown.com', 'Xiamen University Malaysia, Jalan Sunsuria',
'Bandar Baru Salak Tinggi', '43900', 'Uzumaki Naruto', '0142356789', 'uzumaki@naruto.com',
'No. 11, Jalan Pekaka', 'Taman Pekaka', '14300'),

(1000000002, 0, 0, 1, 'Bear', 99, 3.5, 15.9, 0, 'James Bond', 1, 
'870927136937', '0123456789', 'james@bond.com', 'Xiamen University Malaysia, Jalan Sunsuria',
'Bandar Baru Salak Tinggi', '43900', 'Uchiha Sasuke', '0142356789', 'uchiha@sasuke.com',
'No. 11, Jalan Pekaka', 'Taman Pekaka', '14300'),

(1000000003, 1, 0, 5, 'Books', 180.4, 5.6, 20.9, 5, 'Michael Jackson', 1, 
'880808145536', '0123456789', 'michael@jackson.com', 'Xiamen University Malaysia, Jalan Sunsuria',
'Bandar Baru Salak Tinggi', '43900', 'Ash Ketchum', '0142356789', 'ash@ketchum.com',
'No. 11, Jalan Pekaka', 'Taman Pekaka', '14300'),

(1000000004, 1, 0, 5, 'Books', 180.4, 5.6, 20.9, 5, 'Michael Jackson', 1, 
'880808145536', '0123456789', 'michael@jackson.com', 'Xiamen University Malaysia, Jalan Sunsuria',
'Bandar Baru Salak Tinggi', '43900', 'Ash Ketchum', '0142356789', 'ash@ketchum.com',
'No. 11, Jalan Pekaka', 'Taman Pekaka', '14300'),

(1000000005, 1, 0, 5, 'Books', 180.4, 5.6, 20.9, 5, 'Michael Jackson', 1, 
'880808145536', '0123456789', 'michael@jackson.com', 'Xiamen University Malaysia, Jalan Sunsuria',
'Bandar Baru Salak Tinggi', '43900', 'Ash Ketchum', '0142356789', 'ash@ketchum.com',
'No. 11, Jalan Pekaka', 'Taman Pekaka', '14300'),

(1000000006, 1, 0, 5, 'Books', 180.4, 5.6, 20.9, 5, 'Michael Jackson', 1, 
'880808145536', '0123456789', 'michael@jackson.com', 'Xiamen University Malaysia, Jalan Sunsuria',
'Bandar Baru Salak Tinggi', '43900', 'Ash Ketchum', '0142356789', 'ash@ketchum.com',
'No. 11, Jalan Pekaka', 'Taman Pekaka', '14300')
;

insert into pick_up_info VALUES 
(1000000003, '12/12/2019', '3pm', '5 box of books');