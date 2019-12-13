﻿using BestLogisticAdmin.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestLogisticAdmin.Models
{
    public class Parcel
    {
        public readonly int TrackingNumber;
        public readonly string UserUid;
        
        public readonly byte SenderIdType;
        public readonly string SenderIdNumber;
        public readonly PersonInfo Sender;
        public readonly PersonInfo Receiver;

        public readonly DateTime DateCreated;
        public readonly bool ParcelService;
        public readonly bool ParcelType;
        public readonly byte ParcelPieces;
        public readonly decimal ValueOfContent;
        public readonly string Content;
        public readonly float Weight;
        public readonly decimal DeliveryFee;
        public readonly decimal PickUpFee;

        public readonly Trip ParcelTrip;
        public readonly PickUpInfo PickUp;

        //public Parcel(string trackingNumber, string senderName, string senderEmail, string senderPhone, string senderAddress, string senderPostCode, string senderLocation, string senderCity, string senderState, string receiverName, string receiverEmail, string receiverPhone, string receiverAddress, string receiverPostCode, string receiverLocation, string receiverCity, string receiverState, bool parcelType, int parcelPieces, double valueOfContent, string content, double weight)
        //{
        //    TrackingNumber = trackingNumber;
        //    SenderName = senderName;
        //    SenderEmail = senderEmail;
        //    SenderPhone = senderPhone;
        //    SenderAddress = senderAddress;
        //    SenderPostCode = senderPostCode;
        //    SenderLocation = senderLocation;
        //    SenderCity = senderCity;
        //    SenderState = senderState;
        //    ReceiverName = receiverName;
        //    ReceiverEmail = receiverEmail;
        //    ReceiverPhone = receiverPhone;
        //    ReceiverAddress = receiverAddress;
        //    ReceiverPostCode = receiverPostCode;
        //    ReceiverLocation = receiverLocation;
        //    ReceiverCity = receiverCity;
        //    ReceiverState = receiverState;
        //    ParcelType = parcelType;
        //    ParcelPieces = parcelPieces;
        //    ValueOfContent = valueOfContent;
        //    Content = content;
        //    Weight = weight;
        //}

        private Parcel(DataRow dataRow)
        {
            Sender = new PersonInfo();
            Receiver = new PersonInfo();
            ParcelTrip = new Trip();
            PickUp = new PickUpInfo();

            TrackingNumber = dataRow.Field<int>("tracking_number");
            UserUid = dataRow.Field<Guid?>("user_uid").ToString();
            Sender.Name = dataRow.Field<string>("sender_name");
            SenderIdType = dataRow.Field<byte>("sender_id_type");
            SenderIdNumber = dataRow.Field<string>("sender_id_number");
            Sender.Email = dataRow.Field<string>("sender_email");
            Sender.Phone = dataRow.Field<string>("sender_phone");
            Sender.Address = dataRow.Field<string>("sender_address");
            Sender.PostCode = dataRow.Field<string>("sender_postcode");
            Sender.Location = dataRow.Field<string>("sender_location");
            Sender.City = dataRow.Field<string>("sender_city");
            Sender.State = dataRow.Field<string>("sender_state");
            Receiver.Name = dataRow.Field<string>("receiver_name");
            Receiver.Email = dataRow.Field<string>("receiver_email");
            Receiver.Phone = dataRow.Field<string>("receiver_phone");
            Receiver.Address = dataRow.Field<string>("receiver_address");
            Receiver.PostCode = dataRow.Field<string>("receiver_postcode");
            Receiver.Location = dataRow.Field<string>("receiver_location");
            Receiver.City = dataRow.Field<string>("receiver_city");
            Receiver.State = dataRow.Field<string>("receiver_state");
            ParcelService = dataRow.Field<bool>("service");
            ParcelType = dataRow.Field<bool>("type");
            ParcelPieces = dataRow.Field<byte>("pieces");
            ValueOfContent = dataRow.Field<decimal>("value");
            Content = dataRow.Field<string>("content");
            Weight = dataRow.Field<float>("weight");
            DeliveryFee = dataRow.Field<decimal>("delivery_fee");
            PickUpFee = dataRow.Field<decimal>("pick_up_fee");
            DateCreated = dataRow.Field<DateTime>("date_created");

            ParcelTrip.Status = dataRow.Field<byte>("status");
            ParcelTrip.Departure = dataRow.Field<string>("departure");
            ParcelTrip.Arrival = dataRow.Field<string>("arrival");
            ParcelTrip.DepTime = dataRow.Field<DateTime?>("departure_datetime");
            ParcelTrip.ArrTime = dataRow.Field<DateTime?>("arrival_datetime");
            ParcelTrip.DepartureId = dataRow.Field<string>("departure_point");
            ParcelTrip.ArrivalId = dataRow.Field<string>("arrival_point");
        }

        public static void Create(string senderName, string senderEmail, byte senderIdType, string senderIdNumber, 
            string senderPhone, string senderAddress, string senderPostCode, string senderLocation, 
            string receiverName, string receiverEmail, string receiverPhone, string receiverAddress, 
            string receiverPostCode, string receiverLocation, bool parcelType, byte parcelPieces, 
            decimal valueOfContent, string content, float weight, decimal deliveryFee, string branchId)
        {
            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            {
                conn.Open();
                
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string query = string.Empty;
                        string tripId = string.Empty;
                        int trackingNumber = 0;

                        query = "SELECT trip_id FROM trip WHERE departure_point=@BID AND status=@STATUS;";
                        using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@BID", branchId);
                            cmd.Parameters.AddWithValue("@STATUS", 0);
                            using (DataSet ds = new DataSet())
                            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                            {
                                adapter.Fill(ds);
                                if (ds.Tables[0].Rows.Count != 0)
                                    tripId = ds.Tables[0].Rows[0].Field<Guid>("trip_id").ToString();
                            }
                        }

                        query = "INSERT INTO [dbo].[parcel] ([type],[pieces],[content],[value],[weight],[delivery_fee],[service],[pick_up_fee]," +
                            "[sender_name],[sender_id_type],[sender_id_number],[sender_phone],[sender_email],[sender_address],[sender_location],[sender_postcode]," +
                            "[receiver_name],[receiver_phone],[receiver_email],[receiver_address],[receiver_location],[receiver_postcode]) " +
                            "OUTPUT INSERTED.tracking_number " +
                            "VALUES (" +
                            "@TYPE, @PIECES, @CONTENT, @VALUE, @WEIGHT, @DFEE, @SERVICE, @PFEE, " +
                            "@SNAME, @SIDTYPE, @SIDNUM, @SPHONE, @SEMAIL, @SADDRESS, @SLOCATION, @SPOSTCODE, " +
                            "@RNAME, @RPHONE, @REMAIL, @RADDRESS, @RLOCATION, @RPOSTCODE);";
                        using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@TYPE", parcelType);
                            cmd.Parameters.AddWithValue("@PIECES", parcelPieces);
                            cmd.Parameters.AddWithValue("@CONTENT", content);
                            cmd.Parameters.AddWithValue("@VALUE", valueOfContent);
                            cmd.Parameters.AddWithValue("@WEIGHT", weight);
                            cmd.Parameters.AddWithValue("@DFEE", deliveryFee);
                            cmd.Parameters.AddWithValue("@SERVICE", false);
                            cmd.Parameters.AddWithValue("@PFEE", 0);

                            cmd.Parameters.AddWithValue("@SNAME", senderName);
                            cmd.Parameters.AddWithValue("@SIDTYPE", senderIdType);
                            cmd.Parameters.AddWithValue("@SIDNUM", senderIdNumber);
                            cmd.Parameters.AddWithValue("@SPHONE", senderPhone);
                            cmd.Parameters.AddWithValue("@SEMAIL", senderEmail);
                            cmd.Parameters.AddWithValue("@SADDRESS", senderAddress);
                            cmd.Parameters.AddWithValue("@SLOCATION", senderLocation);
                            cmd.Parameters.AddWithValue("@SPOSTCODE", senderPostCode);

                            cmd.Parameters.AddWithValue("@RNAME", receiverName);
                            cmd.Parameters.AddWithValue("@RPHONE", receiverPhone);
                            cmd.Parameters.AddWithValue("@REMAIL", receiverEmail);
                            cmd.Parameters.AddWithValue("@RADDRESS", receiverAddress);
                            cmd.Parameters.AddWithValue("@RLOCATION", receiverLocation);
                            cmd.Parameters.AddWithValue("@RPOSTCODE", receiverPostCode);

                            //cmd.Parameters.AddWithValue("@STATUS", 2); // Pick-up status, which means in branch
                            trackingNumber = ((int)cmd.ExecuteScalar());
                        }

                        query = "INSERT INTO parcel_trip (tracking_number, trip_id) VALUES (@TN, @TRIP);";
                        //query = "INSERT INTO tracking (tracking_number, trip, departure_point) VALUES (@TN, @TRIP, @DP);";

                        using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@TN", trackingNumber);
                            cmd.Parameters.AddWithValue("@TRIP", tripId);

                            cmd.ExecuteNonQuery();
                        }

                        //if (trackingNumber != 0 && tripId != string.Empty)
                        //{
                            
                        //}

                        transaction.Commit();
                    }
                    catch (SqlException e)
                    {
                        Debug.WriteLine(e.Message);
                        transaction.Rollback();
                    }
                }
            }
        }

        public static Parcel Get(int trackingNumber)
        {
            //string query = "SELECT * FROM dbo.parcel WHERE tracking_number=@TN;";
            string query = "SELECT P.*, S.post_office AS sender_city, S.state_code AS sender_state, " +
                "R.area AS receiver_city, R.state_code AS receiver_state, " +
                "T.status, PD.name AS departure, PA.name AS arrival, T.departure_point, T.arrival_point, " +
                "T.departure_datetime, T.arrival_datetime, PU.pick_up_date, PU.pick_up_time, PU.remark " +
                "FROM parcel P " +
                "LEFT JOIN pick_up_info PU ON P.tracking_number = PU.tracking_number " +
                "INNER JOIN postcode S ON P.sender_postcode=S.postcode " +
                "INNER JOIN postcode R ON P.receiver_postcode=R.postcode " +
                "INNER JOIN parcel_trip PT ON P.tracking_number=PT.tracking_number " +
                "INNER JOIN trip T ON PT.trip_id=T.trip_id " +
                "INNER JOIN point PD ON T.departure_point=PD.place_id " +
                "LEFT JOIN point PA ON T.arrival_point=PA.place_id " +
                "WHERE P.tracking_number=@TN AND P.deleted=0 " +
                "AND P.sender_location=S.area AND P.receiver_location=R.area;";
            
            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@TN", trackingNumber);

                using (DataSet ds = new DataSet())
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                        return new Parcel(ds.Tables[0].Rows[0]);
                }
            }
            return null;
        }

        public static void ChangeTrip(string trackingNumber, string oldTripId, string newTripId)
        {
            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string query = string.Empty;
                        if ( ! string.IsNullOrWhiteSpace(oldTripId) )
                        {
                            query = "DELETE FROM parcel_trip WHERE tracking_number=@TN AND trip_id=@OLDTRIP;";

                            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@TN", trackingNumber);
                                cmd.Parameters.AddWithValue("@OLDTRIP", oldTripId);

                                cmd.ExecuteNonQuery();
                            }
                        }
                        
                        if (! string.IsNullOrWhiteSpace(newTripId) )
                        {
                            query = "INSERT INTO parcel_trip VALUES (@TN, @NEWTRIP);";

                            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@TN", trackingNumber);
                                cmd.Parameters.AddWithValue("@NEWTRIP", newTripId);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (SqlException e)
                    {
                        Debug.WriteLine(e.Message);
                        transaction.Rollback();
                    }
                }
            }
        }

        
        public static DataTable GetParcelsInBranch(string branchId)
        {
            string query = "SELECT P.* FROM parcel P " +
                "INNER JOIN parcel_trip PT ON P.tracking_number=PT.tracking_number " +
                "INNER JOIN trip T ON PT.trip_id=T.trip_id " +
                "WHERE T.departure_point=@BID AND T.status=@STATUS;";

            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@BID", branchId);
                cmd.Parameters.AddWithValue("@STATUS", 0);
                using (DataTable dt = new DataTable())
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public static void AssignInBranchParcelsToRoute(List<string> trackingNumberList, string destinationBranchId)
        {
            for (int i = 0; i < trackingNumberList.Count; i++)
            {
                
                
                using (SqlConnection conn = new SqlConnection(Repository.connectionString))
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            string query = "DELETE FROM parcel_trip WHERE tracking_number=@TN";
                            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                            {

                            }
                            
                            query = "INSERT INTO parcel_trip VALUES (@TN, @TRIP);";
                            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                            {

                            }

                            transaction.Commit();
                        }
                        catch (SqlException e)
                        {
                            Debug.WriteLine(e.Message);
                            transaction.Rollback();
                        }
                    }
                }
                
            }
        }

        public static DataTable GetParcelsToPickUp(string branchId)
        {
            return null;
        }

        public static DataTable GetParcelsPendingTransit(string branchId, string destinationBranchId)
        {
            string query = "SELECT P.* FROM parcel P " +
                "INNER JOIN parcel_trip PT ON P.tracking_number=PT.tracking_number " +
                "INNER JOIN trip T ON PT.trip_id=T.trip_id " +
                "WHERE T.departure_point=@BID AND T.status=@STATUS " +
                "AND T.arrival_point=@DBID;";

            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@BID", branchId);
                cmd.Parameters.AddWithValue("@STATUS", 2);
                cmd.Parameters.AddWithValue("@DBID", destinationBranchId);
                using (DataTable dt = new DataTable())
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public static DataTable GetParcelsOutGoingTransit(string branchId, string destinationBranchId)
        {
            string query = "SELECT P.* FROM parcel P " +
                "INNER JOIN parcel_trip PT ON P.tracking_number=PT.tracking_number " +
                "INNER JOIN trip T ON PT.trip_id=T.trip_id " +
                "WHERE T.departure_point=@BID AND T.status=@STATUS " +
                "AND T.arrival_point=@DBID " +
                "AND T.depature_datetime IS NOT NULL;";

            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@BID", branchId);
                cmd.Parameters.AddWithValue("@STATUS", 2);
                cmd.Parameters.AddWithValue("@DBID", destinationBranchId);
                using (DataTable dt = new DataTable())
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public static DataTable GetParcelsIncomingTransit(string branchId, string sourceBranchId)
        {
            string query = "SELECT P.* FROM parcel P " +
                "INNER JOIN parcel_trip PT ON P.tracking_number=PT.tracking_number " +
                "INNER JOIN trip T ON PT.trip_id=T.trip_id " +
                "WHERE T.arrival_point=@BID AND T.status=@STATUS " +
                "AND T.departure_point=@SBID " +
                "AND T.depature_datetime IS NOT NULL;";

            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@BID", branchId);
                cmd.Parameters.AddWithValue("@STATUS", 2);
                cmd.Parameters.AddWithValue("@SBID", sourceBranchId);
                using (DataTable dt = new DataTable())
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public static DataTable GetParcelsPendingDelivery(string branchId)
        {
            return null;
        }

        public static DataTable GetParcelsInDelivery(string branchId)
        {
            return null;
        }

        public static DataTable GetParcelsDelivered(string branchId)
        {
            return null;
        }

        public static List<Parcel> GetParcelsFromBranch(string branchId)
        {
            string query = "SELECT TOP 1 P.*, S.post_office AS sender_city, S.state_code AS sender_state, " +
                "R.area AS receiver_city, R.state_code AS receiver_state, T.status, T.departure_point, " +
                "T.arrival_point, T.departure_datetime, T.arrival_datetime, " +
                "PD.name AS departure, PA.name AS arrival FROM parcel P " +
                "INNER JOIN postcode S ON P.sender_postcode=S.postcode INNER JOIN postcode R ON P.receiver_postcode=R.postcode " +
                "INNER JOIN parcel_trip PT ON P.tracking_number=PT.tracking_number " +
                "INNER JOIN trip T ON PT.trip_id=T.trip_id " +
                "INNER JOIN point PD ON T.departure_point=PD.place_id " +
                "LEFT JOIN point PA ON T.arrival_point=PA.place_id " +
                "WHERE (T.departure_point=@BID OR T.arrival_point=@BID) " +
                "AND P.deleted=0 ORDER BY T.date_created DESC;";

            List<Parcel> list = new List<Parcel>();
            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@BID", branchId);

                using (DataSet ds = new DataSet())
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        list.Add(new Parcel(ds.Tables[0].Rows[i]));
                    }
                    return list;
                }
            }
        }

        public static void SetTrip(string trackingNumber, string tripId)
        {
            string query;
        }

        public static void Update(int trackingNumber, string senderName, string senderEmail, byte senderIdType, string senderIdNumber,
            string senderPhone, string senderAddress, string senderPostCode, string senderLocation,
            string receiverName, string receiverEmail, string receiverPhone, string receiverAddress,
            string receiverPostCode, string receiverLocation, bool parcelService, bool parcelType, byte parcelPieces,
            decimal valueOfContent, string content, float weight, decimal deliveryFee, decimal pickUpFee)
        {
            string query = "UPDATE dbo.parcel SET [type]=@TYPE,[pieces]=@PIECES,[content]=@CONTENT,[value]=@VALUE,[weight]=@WEIGHT,[delivery_fee]=@DFEE," +
                "[service]=@SERVICE,[pick_up_fee]=@PFEE,[sender_name]=@SNAME,[sender_id_type]=@SIDTYPE,[sender_id_number]=@SIDNUM,[sender_phone]=@SPHONE," +
                "[sender_email]=@SEMAIL,[sender_address]=@SADDRESS,[sender_location]=@SLOCATION,[sender_postcode]=@SPOSTCODE,[receiver_name]=@RNAME," +
                "[receiver_phone]=@RPHONE,[receiver_email]=@REMAIL,[receiver_address]=@RADDRESS,[receiver_location]=@RLOCATION,[receiver_postcode]=@RPOSTCODE" +
                " WHERE tracking_number=@TN;";

            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@TN", trackingNumber);

                cmd.Parameters.AddWithValue("@TYPE", parcelType);
                cmd.Parameters.AddWithValue("@PIECES", parcelPieces);
                cmd.Parameters.AddWithValue("@CONTENT", content);
                cmd.Parameters.AddWithValue("@VALUE", valueOfContent);
                cmd.Parameters.AddWithValue("@WEIGHT", weight);
                cmd.Parameters.AddWithValue("@DFEE", deliveryFee);
                cmd.Parameters.AddWithValue("@SERVICE", parcelService);
                cmd.Parameters.AddWithValue("@PFEE", pickUpFee);

                cmd.Parameters.AddWithValue("@SNAME", senderName);
                cmd.Parameters.AddWithValue("@SIDTYPE", senderIdType);
                cmd.Parameters.AddWithValue("@SIDNUM", senderIdNumber);
                cmd.Parameters.AddWithValue("@SPHONE", senderPhone);
                cmd.Parameters.AddWithValue("@SEMAIL", senderEmail);
                cmd.Parameters.AddWithValue("@SADDRESS", senderAddress);
                cmd.Parameters.AddWithValue("@SLOCATION", senderLocation);
                cmd.Parameters.AddWithValue("@SPOSTCODE", senderPostCode);

                cmd.Parameters.AddWithValue("@RNAME", receiverName);
                cmd.Parameters.AddWithValue("@RPHONE", receiverPhone);
                cmd.Parameters.AddWithValue("@REMAIL", receiverEmail);
                cmd.Parameters.AddWithValue("@RADDRESS", receiverAddress);
                cmd.Parameters.AddWithValue("@RLOCATION", receiverLocation);
                cmd.Parameters.AddWithValue("@RPOSTCODE", receiverPostCode);

                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(int trackingNumber)
        {
            //string query = "DELETE FROM dbo.parcel WHERE tracking_number=@TN;";
            string query = "UPDATE dbo.parcel SET deleted=1 WHERE tracking_number=@TN;";

            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@TN", trackingNumber);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
