using BestLogistic.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BestLogistic.Controllers
{
    public class ParcelController
    {
        //add new parcel
        public static void Create(bool senderIdType, string senderIdNumber, PersonInfo sender, PersonInfo receiver, ParcelInfo parcel, string branchId)
        {
            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        string query = "insert into parcel (service, type, pieces, content, value, weight, delivery_fee, " +
                            "pick_up_fee, sender_name, sender_id_type, sender_id_number, sender_phone, " +
                            "sender_email, sender_address, sender_location, sender_postcode, receiver_name, " +
                            "receiver_phone, receiver_email, receiver_address, receiver_location, " +
                            "receiver_postcode, status) OUTPUT INSERTED.tracking_number VALUES " +
                            "(@SERVICE, @TYPE, @PIECES, @CONTENT, @VALUE, @WEIGHT, @DFEE, @PFEE, @SNAME, @SIDTYPE, " +
                            "@SIDNUM, @SPHONE, @SEMAIL, @SADDRESS, " +
                            "@SLOCATION, @SPOSTCODE, @RNAME, @RPHONE, @REMAIL, " +
                            "@RADDRESS, @RLOCATION, @RPOSTCODE, @STATUS);";
                        int trackingNumber = 0;
                        using (SqlCommand cmd = new SqlCommand(query, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@SERVICE", parcel.Service);
                            cmd.Parameters.AddWithValue("@TYPE", parcel.Type);
                            cmd.Parameters.AddWithValue("@PIECES", parcel.Pieces);
                            cmd.Parameters.AddWithValue("@CONTENT", parcel.Content);
                            cmd.Parameters.AddWithValue("@VALUE", parcel.Value);
                            cmd.Parameters.AddWithValue("@WEIGHT", parcel.Weight);
                            cmd.Parameters.AddWithValue("@DFEE", parcel.DeliveryFee);
                            cmd.Parameters.AddWithValue("@PFEE", parcel.PickUpFee);
                            cmd.Parameters.AddWithValue("@SNAME", sender.Name);
                            cmd.Parameters.AddWithValue("@SIDTYPE", senderIdType);
                            cmd.Parameters.AddWithValue("@SIDNUM", senderIdNumber);
                            cmd.Parameters.AddWithValue("@SPHONE", sender.Phone);
                            cmd.Parameters.AddWithValue("@SEMAIL", sender.Email);
                            cmd.Parameters.AddWithValue("@SADDRESS", sender.Address);
                            cmd.Parameters.AddWithValue("@SLOCATION", sender.Location);
                            cmd.Parameters.AddWithValue("@SPOSTCODE", sender.PostCode);
                            cmd.Parameters.AddWithValue("@RNAME", receiver.Name);
                            cmd.Parameters.AddWithValue("@RPHONE", receiver.Phone);
                            cmd.Parameters.AddWithValue("@REMAIL", receiver.Email);
                            cmd.Parameters.AddWithValue("@RADDRESS", receiver.Address);
                            cmd.Parameters.AddWithValue("@RLOCATION", receiver.Location);
                            cmd.Parameters.AddWithValue("@RPOSTCODE", receiver.PostCode);
                            cmd.Parameters.AddWithValue("@STATUS", status);          // either lodge in or pick up 0 / 1
                            cmd.Parameters.AddWithValue("@RAT", branchId);

                            trackingNumber = (int)cmd.ExecuteScalar();
                        }
                        query = "insert into branch_parcel (branch_id, tracking_number) VALUES (@BID, @TN);";
                        using (SqlCommand cmd = new SqlCommand(query, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@BID", branchId);
                            cmd.Parameters.AddWithValue("@TN", trackingNumber);
                            cmd.ExecuteNonQuery();
                        }
                        tx.Commit();
                    }
                    catch (SqlException e)
                    {
                        Debug.WriteLine(e.Message);
                        tx.Rollback();
                    }
                }
            }
        }
    }
}