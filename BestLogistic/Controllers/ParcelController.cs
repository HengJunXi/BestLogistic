using BestLogistic.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BestLogistic.Controllers
{
    public static class ParcelController
    {
        //add new parcel
        public static int Create(string userUid, byte senderIdType, string senderIdNumber, PersonInfo sender, PersonInfo receiver, ParcelInfo parcel, PickUpInfo pickUp)
        {
            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        string query = "insert into parcel (service, type, pieces, content, value, weight, delivery_fee, " +
                            "pick_up_fee, user_uid, sender_name, sender_id_type, sender_id_number, sender_phone, " +
                            "sender_email, sender_address, sender_location, sender_postcode, receiver_name, " +
                            "receiver_phone, receiver_email, receiver_address, receiver_location, " +
                            "receiver_postcode, status) OUTPUT INSERTED.tracking_number VALUES " +
                            "(@SERVICE, @TYPE, @PIECES, @CONTENT, @VALUE, @WEIGHT, @DFEE, @PFEE, @UUID, @SNAME, @SIDTYPE, " +
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
                            cmd.Parameters.AddWithValue("@UUID", userUid);
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
                            cmd.Parameters.AddWithValue("@STATUS", (pickUp != null));          // either lodge in or pick up 0 / 1

                            trackingNumber = (int)cmd.ExecuteScalar();
                        }
                        if (pickUp != null)
                        {
                            query = "insert into pick_up_info values (@TN, @PUD, @PUT, @REMARK);";
                            using (SqlCommand cmd = new SqlCommand(query, conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@TN", trackingNumber);
                                cmd.Parameters.AddWithValue("@PUD", pickUp.PickUpDate);
                                cmd.Parameters.AddWithValue("@PUT", pickUp.PickUpTime);
                                cmd.Parameters.AddWithValue("@REMARK", pickUp.Remark);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        tx.Commit();
                        return trackingNumber;
                    }
                    catch (SqlException e)
                    {
                        Debug.WriteLine(e.Message);
                        tx.Rollback();
                    }
                }
            }
            return -1;
        }

        public static int CalculatePendingParcels(string userUid)
        {
            string query = "select count(*) from parcel where user_uid=@UID AND status=0;";
            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@UID", userUid);
                using (DataSet ds = new DataSet())
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(ds);
                    return ds.Tables[0].Rows.Count;
                }
            }
        }

        public static int CalculatePickUpParcels(string userUid)
        {
            string query = "select count(*) from parcel where user_uid=@UID AND status=1;";
            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@UID", userUid);
                using (DataSet ds = new DataSet())
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(ds);
                    return ds.Tables[0].Rows.Count;
                }
            }
        }

        public static int CalculateInTransitParcels(string userUid)
        {
            string query = "select count(*) from parcel where user_uid=@UID AND (status=2 OR status=3 OR status=4 OR status=5);";
            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@UID", userUid);
                using (DataSet ds = new DataSet())
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(ds);
                    return ds.Tables[0].Rows.Count;
                }
            }
        }

        public static int CalculateDeliveringParcels(string userUid)
        {
            string query = "select count(*) from parcel where user_uid=@UID AND status=6;";
            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@UID", userUid);
                using (DataSet ds = new DataSet())
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(ds);
                    return ds.Tables[0].Rows.Count;
                }
            }
        }

        public static int CalculateDeliveredParcels(string userUid)
        {
            string query = "select count(*) from parcel where user_uid=@UID AND status=7;";
            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@UID", userUid);
                using (DataSet ds = new DataSet())
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(ds);
                    return ds.Tables[0].Rows.Count;
                }
            }
        }

        //public static DataTable Get(int trackingNumber)
        //{
        //    string query = "select * from parcel where tracking_number=@TN AND deleted=0;";
        //    using (SqlConnection conn = new SqlConnection(Repository.connectionString))
        //    using (SqlCommand cmd = new SqlCommand(query, conn))
        //    {
        //        conn.Open();
        //        cmd.Parameters.AddWithValue("@TN", trackingNumber);
        //        using (DataTable dt = new DataTable())
        //        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
        //        {
        //            adapter.Fill(dt);
        //            return dt;
        //        }
        //    }
        //}

        public static void Track(string trackingNumber)
        {
            
            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        string query = "select status from parcel where tracking_number=@TN;";
                        byte status;
                        using (SqlCommand cmd = new SqlCommand(query, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@TN", trackingNumber);
                            using (DataSet ds = new DataSet())
                            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                            {
                                adapter.Fill(ds);
                                status = ds.Tables[0].Rows[0].Field<byte>("status");
                            }
                        }
                        string result = string.Empty;
                        switch (status)
                        {
                            case 0:
                                break;
                            case 1:
                                break;
                            case 2:
                                //query = "select branch from branch_parcel where tracking_number=@TN;";
                                //using (SqlCommand cmd = new SqlCommand(query, conn, tx))
                                //{
                                //    cmd.Parameters.AddWithValue("@TN", trackingNumber);
                                //    using (DataSet ds = new DataSet())
                                //    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                                //    {
                                //        adapter.Fill(ds);
                                //        result = ds.Tables[0].Rows[0].Field<byte>("branch");
                                //    }
                                //}
                                break;
                            case 3:
                                break;
                            case 4:
                                break;
                            case 5:
                                break;
                            case 6:
                                break;
                            case 7:
                                break;
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

        public static decimal Quote(string senderLocation, string senderPostCode, string receiverLocation, string receiverPostCode, ParcelInfo parcel, PickUpInfo pickUp)
        {
            decimal fee = new decimal(10 + (pickUp == null ? 0 : 5));
            if (parcel.Weight > 5)
                fee += 5;
            else if (parcel.Weight > 10)
                fee += 10;
            else if (parcel.Weight > 15)
                fee += 15;
            else if (parcel.Weight > 20)
                fee += 20;
            else if (parcel.Weight > 25)
                fee += 25;
            else if (parcel.Weight > 30)
                fee += 30;
            return fee;
        }
    }
}