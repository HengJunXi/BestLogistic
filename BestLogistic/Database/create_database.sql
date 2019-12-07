USE best_logistic;

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
	tracking_number uniqueidentifier DEFAULT NEWID(),
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
	status tinyint,
	PRIMARY KEY (tracking_number),
	FOREIGN KEY ([user_uid]) REFERENCES dbo.[user],
	FOREIGN KEY (sender_id_type) REFERENCES dbo.id_type,
	FOREIGN KEY (sender_postcode, sender_location) REFERENCES dbo.postcode,
	FOREIGN KEY (receiver_postcode, receiver_location) REFERENCES dbo.postcode,
	FOREIGN KEY (status) REFERENCES dbo.parcel_status
)

CREATE TABLE dbo.pick_up_info
(
	tracking_number uniqueidentifier,
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

CREATE TABLE dbo.tracking
(
	tracking_number uniqueidentifier,
	trip tinyint,
	plate_number varchar(255),
	departure_point varchar(255),
	arrival_point varchar(255),
	departure_datetime datetime,
	arrival_datetime datetime,
	status bit,
	PRIMARY KEY (tracking_number, trip),
	FOREIGN KEY (tracking_number) REFERENCES dbo.parcel,
	FOREIGN KEY (departure_point) REFERENCES dbo.point,
	FOREIGN KEY (arrival_point) REFERENCES dbo.point,
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

INSERT INTO parcel_status (status) VALUES ('Pending'), ('Pick-up'), ('In transit'), ('Out of delivery'), ('Delivered');

INSERT INTO [user] (uid, password_hash, hash_salt, email, name, id_type, id_number, date_of_birth) VALUES 
('2E075DF1-7144-4077-B925-000AA23DC10F', 'NNSYPl6OI60v+eC50qdN55E24fc=', 'oNXKoe2TCAwboEV9rk76eQ==', 'heng@heng.com', 'Heng Jun Xi', 1, '980510080000', '1998-05-10'),
('6F99B241-7C39-4957-8A9B-7EEEE8A7BF2A', '/o+xUzI3ZR6l/G8d15q/wv6ySgY=', 'Qx8Pk3B1ZSc19pZCFLChvw==', 'loh@loh.com', 'Loh Shu Yi', 1, '980330080000', '1998-03-30'),
('C1713FC0-118D-4650-9314-26480E210F8D', 'yCV9BB0Zha9pMyuZ7Bn/4Py1Qqk=', 'lavcNAWHs5Nr7722Lxw6gg==', 'lim@lim.com', 'Lim Carol', 1, '980327080000', '1998-03-27');

INSERT INTO staff (uid, password_hash, hash_salt, branch_id, name) VALUES 
('2E075DF1-7144-4077-B925-000AA23DC10F', 'NNSYPl6OI60v+eC50qdN55E24fc=', 'oNXKoe2TCAwboEV9rk76eQ==', 'ChIJRb7LRg02zDERETaXXhc-QyU', 'Heng Jun Xi'),
('6F99B241-7C39-4957-8A9B-7EEEE8A7BF2A', '/o+xUzI3ZR6l/G8d15q/wv6ySgY=', 'Qx8Pk3B1ZSc19pZCFLChvw==', 'ChIJ7ciSyEquSjARqdvRktxutKI', 'Loh Shu Yi'),
('C1713FC0-118D-4650-9314-26480E210F8D', 'yCV9BB0Zha9pMyuZ7Bn/4Py1Qqk=', 'lavcNAWHs5Nr7722Lxw6gg==', 'ChIJTfBUxjVs2jER3vZ-g6U8JkI', 'Lim Carol');

INSERT INTO parcel (tracking_number, type, pieces, value, weight, delivery_fee, pick_up_fee, sender_postcode, sender_location, receiver_postcode, receiver_location) VALUES
('2E075DF1-7144-4077-B925-000AA23DC10F', 0, 1, 10, 1, 5, 0, '50460', 'Wisma Putra', '81800', 'Kampung AC Batu 18'),
('6F99B241-7C39-4957-8A9B-7EEEE8A7BF2A', 0, 5, 10, 4, 10, 5, '81800', 'Kampung AC Batu 18', '14300', 'Taman Pekaka'),
('C1713FC0-118D-4650-9314-26480E210F8D', 1, 3, 2, 0.5, 4.5, 1.5, '14300', 'Taman Pekaka', '50460', 'Wisma Putra');