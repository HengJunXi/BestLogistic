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
        public string SenderName;
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

        public bool ParcelType;
        public int ParcelPieces;
        public double ValueOfContent;
        public string Content;
        public double Weight;
        public double DeliveryFee;

        public Parcel(string trackingNumber, string senderName, string senderEmail, string senderPhone, string senderAddress, string senderPostCode, string senderLocation, string senderCity, string senderState, string receiverName, string receiverEmail, string receiverPhone, string receiverAddress, string receiverPostCode, string receiverLocation, string receiverCity, string receiverState, bool parcelType, int parcelPieces, double valueOfContent, string content, double weight)
        {
            TrackingNumber = trackingNumber;
            SenderName = senderName;
            SenderEmail = senderEmail;
            SenderPhone = senderPhone;
            SenderAddress = senderAddress;
            SenderPostCode = senderPostCode;
            SenderLocation = senderLocation;
            SenderCity = senderCity;
            SenderState = senderState;
            ReceiverName = receiverName;
            ReceiverEmail = receiverEmail;
            ReceiverPhone = receiverPhone;
            ReceiverAddress = receiverAddress;
            ReceiverPostCode = receiverPostCode;
            ReceiverLocation = receiverLocation;
            ReceiverCity = receiverCity;
            ReceiverState = receiverState;
            ParcelType = parcelType;
            ParcelPieces = parcelPieces;
            ValueOfContent = valueOfContent;
            Content = content;
            Weight = weight;
        }

        public Parcel(DataRow dataRow)
        {
            TrackingNumber = dataRow.Field<Guid>("tracking_num").ToString();
            SenderName = dataRow.Field<string>("sender_name");
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
            ParcelType = dataRow.Field<bool>("type");
            ParcelPieces = dataRow.Field<byte>("pieces");
            ValueOfContent = dataRow.Field<double>("value");
            Content = dataRow.Field<string>("content");
            Weight = dataRow.Field<double>("weight");
            DeliveryFee = dataRow.Field<double>("delivery_fee");
        }

        public static void Create(string senderName, string senderEmail, byte senderIdType, string senderIdNum, 
            string senderPhone, string senderAddress, string senderPostCode, string senderLocation, 
            string receiverName, string receiverEmail, string receiverPhone, string receiverAddress, 
            string receiverPostCode, string receiverLocation, string parcelType, int parcelPieces, 
            double valueOfContent, string content, double weight, double deliveryFee)
        {
            string query = "INSERT INTO [dbo].[parcel] ([type],[pieces],[content],[value],[weight],[delivery_fee]," +
                "[sender_name],[sender_id_type],[sender_id_number],[sender_phone],[sender_email],[sender_address],[sender_location],[sender_postcode]," +
                "[receiver_name],[receiver_phone],[receiver_email],[receiver_address],[receiver_location],[receiver_postcode]) VALUES (" +
                "@TYPE, @PIECES, @CONTENT, @VALUE, @WEIGHT, @FEE, @SNAME, @SIDTYPE, @SIDNUM, @SPHONE, @SEMAIL, @SADDRESS, @SLOCATION, @SPOSTCODE," +
                "@RNAME, @RPHONE, @REMAIL, @RADDRESS, @RLOCATION, @RPOSTCODE);";

            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();

                cmd.Parameters.AddWithValue("@TYPE", parcelType);
                cmd.Parameters.AddWithValue("@PIECES", parcelPieces);
                cmd.Parameters.AddWithValue("@CONTENT", content);
                cmd.Parameters.AddWithValue("@VALUE", valueOfContent);
                cmd.Parameters.AddWithValue("@WEIGHT", weight);
                cmd.Parameters.AddWithValue("@FEE", deliveryFee);

                cmd.Parameters.AddWithValue("@SNAME", senderName);
                cmd.Parameters.AddWithValue("@SIDTYPE", senderIdType);
                cmd.Parameters.AddWithValue("@SIDNUM", senderIdNum);
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

        public static Parcel Get(string trackingNum)
        {
            //string query = "SELECT * FROM dbo.parcel WHERE tracking_number=@TN;";
            string query = "SELECT parcel.*, T.area AS sender_city, T.state_code AS sender_state, " +
                "S.area AS receiver_city, S.state_code AS receiver_state FROM dbo.parcel " +
                "INNER JOIN dbo.postcode T ON parcel.sender_postcode=T.postcode " +
                "INNER JOIN dbo.postcode S ON parcel.sender_postcode=S.postcode " +
                "WHERE tracking_number=@TN AND parcel.sender_postcode=T.postcode " +
                "AND parcel.sender_location=T.post_office AND parcel.receiver_postcode=S.postcode " +
                "AND parcel.receiver_location=S.post_office;";
            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@TN", trackingNum);

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
    }
}
