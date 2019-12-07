using BestLogisticAdmin.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestLogisticAdmin.Models
{
    public class Parcel
    {
        public readonly string TrackingNumber;
        public readonly string UserUid;
        public string SenderName;
        public byte SenderIdType;
        public string SenderIdNumber;
        public string SenderEmail;
        public string SenderPhone;
        public string SenderAddress;
        public string SenderPostCode;
        public string SenderLocation;
        public string SenderCity;
        public string SenderState;

        public string ReceiverName;
        public string ReceiverEmail;
        public string ReceiverPhone;
        public string ReceiverAddress;
        public string ReceiverPostCode;
        public string ReceiverLocation;
        public string ReceiverCity;
        public string ReceiverState;

        public DateTime DateCreated;
        public bool ParcelService;
        public bool ParcelType;
        public byte ParcelPieces;
        public decimal ValueOfContent;
        public string Content;
        public float Weight;
        public decimal DeliveryFee;
        public decimal PickUpFee;

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
            TrackingNumber = dataRow.Field<Guid>("tracking_number").ToString();
            UserUid = dataRow.Field<Guid?>("user_uid").ToString();
            SenderName = dataRow.Field<string>("sender_name");
            SenderIdType = dataRow.Field<byte>("sender_id_type");
            SenderIdNumber = dataRow.Field<string>("sender_id_number");
            SenderEmail = dataRow.Field<string>("sender_email");
            SenderPhone = dataRow.Field<string>("sender_phone");
            SenderAddress = dataRow.Field<string>("sender_address");
            SenderPostCode = dataRow.Field<string>("sender_postcode");
            SenderLocation = dataRow.Field<string>("sender_location");
            SenderCity = dataRow.Field<string>("sender_city");
            SenderState = dataRow.Field<string>("sender_state");
            ReceiverName = dataRow.Field<string>("receiver_name");
            ReceiverEmail = dataRow.Field<string>("receiver_email");
            ReceiverPhone = dataRow.Field<string>("receiver_phone");
            ReceiverAddress = dataRow.Field<string>("receiver_address");
            ReceiverPostCode = dataRow.Field<string>("receiver_postcode");
            ReceiverLocation = dataRow.Field<string>("receiver_location");
            ReceiverCity = dataRow.Field<string>("receiver_city");
            ReceiverState = dataRow.Field<string>("receiver_state");
            ParcelService = dataRow.Field<bool>("service");
            ParcelType = dataRow.Field<bool>("type");
            ParcelPieces = dataRow.Field<byte>("pieces");
            ValueOfContent = dataRow.Field<decimal>("value");
            Content = dataRow.Field<string>("content");
            Weight = dataRow.Field<float>("weight");
            DeliveryFee = dataRow.Field<decimal>("delivery_fee");
            PickUpFee = dataRow.Field<decimal>("pick_up_fee");
            DateCreated = dataRow.Field<DateTime>("date_created");
        }

        public static void Create(string senderName, string senderEmail, byte senderIdType, string senderIdNumber, 
            string senderPhone, string senderAddress, string senderPostCode, string senderLocation, 
            string receiverName, string receiverEmail, string receiverPhone, string receiverAddress, 
            string receiverPostCode, string receiverLocation, bool parcelService, bool parcelType, byte parcelPieces, 
            decimal valueOfContent, string content, float weight, decimal deliveryFee, decimal pickUpFee, string branchId)
        {
            string query = "INSERT INTO [dbo].[parcel] ([type],[pieces],[content],[value],[weight],[delivery_fee],[service],[pick_up_fee]," +
                "[sender_name],[sender_id_type],[sender_id_number],[sender_phone],[sender_email],[sender_address],[sender_location],[sender_postcode]," +
                "[receiver_name],[receiver_phone],[receiver_email],[receiver_address],[receiver_location],[receiver_postcode],[status]) " +
                "OUTPUT INSERTED.tracking_number " +
                "VALUES (" +
                "@TYPE, @PIECES, @CONTENT, @VALUE, @WEIGHT, @DFEE, @SERVICE, @PFEE, " +
                "@SNAME, @SIDTYPE, @SIDNUM, @SPHONE, @SEMAIL, @SADDRESS, @SLOCATION, @SPOSTCODE, " +
                "@RNAME, @RPHONE, @REMAIL, @RADDRESS, @RLOCATION, @RPOSTCODE, @STATUS);";

            string trackingNumber = string.Empty;

            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            {
                conn.Open();
                
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                        {
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

                            cmd.Parameters.AddWithValue("@STATUS", 2); // Pick-up status, which means in branch
                            trackingNumber = ((Guid)cmd.ExecuteScalar()).ToString();
                        }

                        if (trackingNumber != string.Empty)
                        {
                            query = "INSERT INTO tracking (tracking_number, trip, departure_point) VALUES (@TN, @TRIP, @DP);";

                            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@TN", trackingNumber);
                                cmd.Parameters.AddWithValue("@TRIP", 1);
                                cmd.Parameters.AddWithValue("@DP", branchId);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (SqlException e)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }

        public static Parcel Get(string trackingNumber)
        {
            //string query = "SELECT * FROM dbo.parcel WHERE tracking_number=@TN;";
            string query = "SELECT parcel.*, T.post_office AS sender_city, T.state_code AS sender_state, S.area AS receiver_city, S.state_code AS receiver_state FROM dbo.parcel INNER JOIN dbo.postcode T ON parcel.sender_postcode=T.postcode INNER JOIN dbo.postcode S ON parcel.receiver_postcode=S.postcode WHERE tracking_number=@TN AND deleted=0 AND parcel.sender_postcode=T.postcode AND parcel.sender_location=T.area AND parcel.receiver_postcode=S.postcode AND parcel.receiver_location=S.area;";
            
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

        public static List<Parcel> GetParcelsFromBranch(string branchId)
        {
            string query = "SELECT parcel.*, T.post_office AS sender_city, T.state_code AS sender_state, S.area AS receiver_city, S.state_code AS receiver_state " +
                "FROM dbo.parcel INNER JOIN dbo.postcode T ON parcel.sender_postcode=T.postcode INNER JOIN dbo.postcode S ON parcel.receiver_postcode=S.postcode " +
                "WHERE branch_id=@BID " +
                "AND parcel.sender_postcode=T.postcode AND parcel.sender_location=T.area " +
                "AND parcel.receiver_postcode=S.postcode AND parcel.receiver_location=S.area;";

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

        public static void Update(string trackingNumber, string senderName, string senderEmail, byte senderIdType, string senderIdNumber,
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

        public static void Delete(string trackingNumber)
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
