// Login existing user account
SELECT * FROM user where email="" AND password_hash="";

// Register new user account
INSERT INTO user (password_hash, hash_salt, email, name, 
id_type, id_number, date_of_birth) VALUES (...);

// change user profile
UPDATE user SET address="", location="", postcode="" WHERE uid="";
UPDATE user SET phone_number="" WHERE uid="";
UPDATE user SET home_number="" WHERE uid="";

// change password
UPDATE user SET password_hash="" WHERE uid="";

// get user profile information
SELECT * FROM user WHERE uid="";

// track/get parcel real-time location (latest location)
SELECT status FROM parcel WHERE tracking_number="";
// if in transit
SELECT departure_point, departure_datetime, arrival_point, arrival_datetime 
FROM tracking WHERE tracking_number="" ORDER BY trip DESC LIMIT 1;
// else
SELECT receiver_address, receiver_location, receiver_postcode 
FROM parcel WHERE tracking_number="";

// when a parcel is lodged in
// register parcel to system
// user-interface: done by user themselves
// staff-interface: done by the staff
// service: 0 -> lodge in; 1 -> pick-up
// type: 0 -> parcel; 1 -> document
INSERT INTO parcel (address, location, postcode, service, type, pieces, 
content, value, weight, delivery_fee, pick_up_fee, user_uid, sender_name,
sender_id_type, sender_id_number, sender_phone, sender_email, sender_address,
sender_location, sender_postcode, receiver_name, receiver_phone, receiver_email,
receiver_address, receiver_location, receiver_postcode, status) VALUES (..., 0);
// if a parcel is request for pick up
INSERT INTO pick_up_info (tracking_number, pick_up_date, pick_up_time, remark) 
VALUES (...);

// parcel in the starting point
INSERT INTO tracking (tracking_number, trip, departure_point) 
VALUES (..., 1, ...);
UPDATE parcel SET status=1 WHERE tracking_number="";

// start delivery to next point
UPDATE tracking SET departure_datetime="", arrival_point="" 
WHERE tracking_number=... AND arrival_datetime=NULL;

// arrived at next point
prev_trip = SELECT trip FROM tracking 
WHERE tracking_number="" AND arrival_datetime=NULL;
UPDATE tracking SET arrival_datetime=""
WHERE tracking_number=... AND trip=prev_trip;
// if arrived at last point
UPDATE parcel SET status=2 WHERE tracking_number="";
// else
INSERT INTO tracking (tracking_number, trip, departure_point) 
VALUES (..., prev_trip+1, ...);

// if sending to destination
UPDATE parcel SET status=3 WHERE tracking_number="";

// if received by receiver
UPDATE parcel SET status=4 WHERE tracking_number="";

// calculate number of 
SELECT COUNT(*) FROM parcel WHERE uid="" AND status=0; // pending
SELECT COUNT(*) FROM parcel WHERE uid="" AND status=1; // pick-up
SELECT COUNT(*) FROM parcel WHERE uid="" AND status=2; // in transit
SELECT COUNT(*) FROM parcel WHERE uid="" AND status=3; // out of delivery
SELECT COUNT(*) FROM parcel WHERE uid="" AND status=4; // delivered

