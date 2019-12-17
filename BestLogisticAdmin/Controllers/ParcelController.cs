using BestLogisticAdmin.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestLogisticAdmin.Controllers
{
    public static class ParcelController
    {
        //add new parcel
        public static void Create(byte senderIdType, string senderIdNumber, PersonInfo sender, PersonInfo receiver, ParcelInfo parcel, string branchId)
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
                            "receiver_postcode, status, register_at) OUTPUT INSERTED.tracking_number VALUES " +
                            "(@SERVICE, @TYPE, @PIECES, @CONTENT, @VALUE, @WEIGHT, @DFEE, @PFEE, @SNAME, @SIDTYPE, " +
                            "@SIDNUM, @SPHONE, @SEMAIL, @SADDRESS, " +
                            "@SLOCATION, @SPOSTCODE, @RNAME, @RPHONE, @REMAIL, " +
                            "@RADDRESS, @RLOCATION, @RPOSTCODE, @STATUS, @RAT);";
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
                            cmd.Parameters.AddWithValue("@STATUS", 2);          // in branch (not assigned)
                            cmd.Parameters.AddWithValue("@RAT", branchId);

                            trackingNumber = (int) cmd.ExecuteScalar();
                        }
                        query = "insert into branch_parcel (branch, tracking_number) VALUES (@BID, @TN);";
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

        //register online parcel
        public static void RegisterOnlineLodgeIn(int trackingNumber, string branchId)
        {
            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        string query = "update parcel set status=@STATUS, register_at=@RAT where tracking_number=@TN;";
                        using (SqlCommand cmd = new SqlCommand(query, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@STATUS", 2);
                            cmd.Parameters.AddWithValue("@RAT", branchId);
                            cmd.Parameters.AddWithValue("@TN", trackingNumber);
                            cmd.ExecuteNonQuery();
                        }
                        query = "insert into branch_parcel (branch, tracking_number) VALUES (@BID, @TN);";
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

        public static void RegisterOnlinePickUp(int trackingNumber, string branchId)
        {
            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        string query = "update parcel set status=@STATUS, register_at=@RAT where tracking_number=@TN;";
                        using (SqlCommand cmd = new SqlCommand(query, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@STATUS", 2);
                            cmd.Parameters.AddWithValue("@RAT", branchId);
                            cmd.Parameters.AddWithValue("@TN", trackingNumber);
                            cmd.ExecuteNonQuery();
                        }
                        query = "insert into branch_parcel (branch, tracking_number) VALUES (@BID, @TN);";
                        using (SqlCommand cmd = new SqlCommand(query, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@BID", branchId);
                            cmd.Parameters.AddWithValue("@TN", trackingNumber);
                            cmd.ExecuteNonQuery();
                        }
                        query = "update pick_up_info set status=@STATUS WHERE tracking_number=@TN;";
                        using (SqlCommand cmd = new SqlCommand(query, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@STATUS", 1);          // picked up
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

        //view all parcels need to pick up
        public static DataTable GetAllParcelsToPickUp()
        {
            string query = "select * from parcel P inner join pick_up_info PU on P.tracking_number=PU.tracking_number WHERE PU.status=0 AND P.deleted=0;";
            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (DataTable dt = new DataTable())
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        //view all parcels in branch and registered by that branch
        public static DataTable GetAllRegisteredParcels(string branchId)
        {
            // return all (not assigned, each route, pending delivery)
            string query = "select * from parcel P inner join branch_parcel BP on P.tracking_number=BP.tracking_number WHERE BP.branch=@BID AND P.register_at=@BID AND P.deleted=0;";
            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@BID", branchId);
                using (DataTable dt = new DataTable())
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        //view all parcels in branch(not assigned, each route, pending delivery)
        public static DataTable GetAllInBranchParcels(string branchId, string nextBranchId)
        {
            if (nextBranchId == null) // pending delivery
            {
                string query = "select * from parcel P inner join branch_parcel BP on P.tracking_number=BP.tracking_number WHERE BP.to_home=1 AND BP.branch=@BID AND deleted=0;";
                using (SqlConnection conn = new SqlConnection(Repository.connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@BID", branchId);
                    using (DataTable dt = new DataTable())
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            else if (nextBranchId.Equals(branchId)) // not assigned
            {
                string query = "select * from parcel P inner join branch_parcel BP on P.tracking_number=BP.tracking_number WHERE BP.branch=@BID AND BP.next_branch IS NULL AND P.deleted=0;";
                using (SqlConnection conn = new SqlConnection(Repository.connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@BID", branchId);
                    using (DataTable dt = new DataTable())
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            else // each route
            {
                string query = "select * from parcel P inner join branch_parcel BP on P.tracking_number=BP.tracking_number WHERE BP.branch=@BID AND BP.next_branch=@NBID AND P.deleted=0;";
                using (SqlConnection conn = new SqlConnection(Repository.connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@BID", branchId);
                    cmd.Parameters.AddWithValue("@NBID", nextBranchId);
                    using (DataTable dt = new DataTable())
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        //view all outgoing parcels(each route, delivery)
        public static DataTable GetAllOutgoingParcels(string branchId, string nextBranchId)
        {
            if (nextBranchId == null) // in delivery
            {
                string query = "select * from parcel P inner join transit_parcel TP on P.tracking_number=TP.tracking_number inner join transit T on TP.transit_id=T.transit_id " +
                    "WHERE T.departure_point=@BID AND T.arrival_point IS NULL AND T.arrival_datetime IS NULL;";
                using (SqlConnection conn = new SqlConnection(Repository.connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@BID", branchId);
                    using (DataTable dt = new DataTable())
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            else // each route
            {
                string query = "select * from parcel P inner join transit_parcel TP on P.tracking_number=TP.tracking_number inner join transit T on TP.transit_id=T.transit_id " +
                    "WHERE T.departure_point=@BID AND T.arrival_point=@NBID AND T.arrival_datetime IS NULL;";
                using (SqlConnection conn = new SqlConnection(Repository.connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@BID", branchId);
                    cmd.Parameters.AddWithValue("@NBID", nextBranchId);
                    using (DataTable dt = new DataTable())
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        //view all incoming parcels(each route)
        public static DataTable GetAllIncomingParcels(string branchId, string prevBranchId)
        {
            // both parameters are required
            string query = "select * from parcel P inner join transit_parcel TP on P.tracking_number=TP.tracking_number inner join transit T on TP.transit_id=T.transit_id " +
                    "WHERE T.arrival_point=@BID AND T.departure_point=@PBID AND T.arrival_datetime IS NULL;";
            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@BID", branchId);
                cmd.Parameters.AddWithValue("@PBID", prevBranchId);
                using (DataTable dt = new DataTable())
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        //view all parcels delivered to home
        public static DataTable GetAllDeliveredParcels(string branchId)
        {
            string query = "select * from parcel P inner join transit_parcel TP on P.tracking_number=TP.tracking_number inner join transit T on TP.transit_id=T.transit_id " +
                    "WHERE T.departure_point=@BID AND T.arrival_point IS NULL AND T.arrival_datetime IS NOT NULL;";
            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@BID", branchId);
                using (DataTable dt = new DataTable())
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        //start an outgoing transit(from in branch)
        // if branchId is null start delivery to home
        public static void StartTransit(string branchId, string nextBranchId, string carNumber, List<int> trackingNumberList)
        {
            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        string query = "delete from branch_parcel where branch=@BID and tracking_number in (";

                        for (int i = 0; i < trackingNumberList.Count; i++)
                        {
                            if (i < trackingNumberList.Count - 1)
                                query += trackingNumberList[i] + ",";
                            else
                                query += trackingNumberList[i];
                        }
                        query += ");";
                        using (SqlCommand cmd = new SqlCommand(query, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@BID", branchId);
                            cmd.ExecuteNonQuery();
                        }

                        query = "insert into transit (departure_point, arrival_point, departure_datetime, plate_number) OUTPUT INSERTED.transit_id values (@BID, @NBID, @DEPDT, @PN);";
                        string transitId = string.Empty;
                        using (SqlCommand cmd = new SqlCommand(query, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@BID", branchId);
                            cmd.Parameters.AddWithValue("@NBID", nextBranchId);
                            cmd.Parameters.AddWithValue("@DEPDT", DateTime.Now);
                            cmd.Parameters.AddWithValue("@PN", carNumber);
                            transitId = ((Guid) cmd.ExecuteScalar()).ToString();
                        }

                        query = "insert into transit_parcel values ";
                        for (int i = 0; i < trackingNumberList.Count; i++)
                        {
                            query += "(@TID, " + trackingNumberList[i] + ")" + (i < trackingNumberList.Count - 1 ? "," : ";");
                            //if (i < trackingNumberList.Count - 1)
                            //    query += "(@TID, " + trackingNumberList[i] + "),";
                            //else
                            //    query += "(@TID, " + trackingNumberList[i] + ");";
                        }
                        using (SqlCommand cmd = new SqlCommand(query, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@TID", transitId);
                            cmd.ExecuteNonQuery();
                        }

                        query = "update parcel set status=@STATUS where tracking_number in (";
                        for (int i = 0; i < trackingNumberList.Count; i++)
                        {
                            if (i < trackingNumberList.Count - 1)
                                query += trackingNumberList[i] + ",";
                            else
                                query += trackingNumberList[i];
                        }
                        query += ");";
                        using (SqlCommand cmd = new SqlCommand(query, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@STATUS", (nextBranchId != null) ? 4 : 6);          // in transit or in delivery
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

        //end an incoming transit(to in branch)
        // if branchId is null end delivery to home
        public static void EndTransit(string branchId, string carNumber, List<int> trackingNumberList)
        {
            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        string query = "update top 1 transit set arrival_datetime=@ARRDT where plate_number=@PN order by departure_datetime desc;";
                        using (SqlCommand cmd = new SqlCommand(query, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@ARRDT", DateTime.Now);
                            cmd.Parameters.AddWithValue("@PN", carNumber);
                            cmd.ExecuteNonQuery();
                        }

                        if (branchId != null)
                        {
                            query = "insert into branch_parcel (branch, tracking_number) values ";
                            for (int i = 0; i < trackingNumberList.Count; i++)
                            {
                                query += "(@BID, " + trackingNumberList[i] + ")" + (i < trackingNumberList.Count - 1 ? "," : ";");
                                //if (i < trackingNumberList.Count - 1)
                                //    query += "(@TID, " + trackingNumberList[i] + "),";
                                //else
                                //    query += "(@TID, " + trackingNumberList[i] + ");";
                            }
                            using (SqlCommand cmd = new SqlCommand(query, conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@BID", branchId);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        query = "update parcel set status=@STATUS where tracking_number in (";
                        for (int i = 0; i < trackingNumberList.Count; i++)
                        {
                            if (i < trackingNumberList.Count - 1)
                                query += trackingNumberList[i] + ",";
                            else
                                query += trackingNumberList[i];
                        }
                        query += ");";
                        using (SqlCommand cmd = new SqlCommand(query, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@STATUS", (branchId != null) ? 2 : 7);          // in branch or delivered
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

        //edit parcel details(only before any transit)
        public static DataTable Get(int trackingNumber)
        {
            string query = "select * from parcel where tracking_number=@TN AND deleted=0;";
            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@TN", trackingNumber);
                using (DataTable dt = new DataTable())
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public static void Update(int trackingNumber, bool senderIdType, string senderIdNumber, PersonInfo sender, PersonInfo receiver, ParcelInfo parcel)
        {
            //string query = "update parcel (service, type, pieces, content, value, weight, delivery_fee, " +
            //    "pick_up_fee, sender_name, sender_id_type, sender_id_number, sender_phone, " +
            //    "sender_email, sender_address, sender_location, sender_postcode, receiver_name, " +
            //    "receiver_phone, receiver_email, receiver_address, receiver_location, " +
            //    "receiver_postcode, status, register_at) OUTPUT INSERTED.tracking_number VALUES " +
            //    "(@SERVICE, @TYPE, @PIECES, @CONTENT, @VALUE, @WEIGHT, @DFEE, @PFEE, @SNAME, @SIDTYPE, " +
            //    "@SIDNUM, @SPHONE, @SEMAIL, @SADDRESS, " +
            //    "@SLOCATION, @SPOSTCODE, @RNAME, @RPHONE, @REMAIL, " +
            //    "@RADDRESS, @RLOCATION, @RPOSTCODE, @STATUS, @RAT);";
            //using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            //using (SqlCommand cmd = new SqlCommand(query, conn))
            //{

            //}
        }

        public static void Delete(int[] trackingNumberList)
        {
            string query = "update parcel set deleted=1 where tracking_number in (";
            for (int i = 0; i < trackingNumberList.Length; i++)
                query += trackingNumberList[i] + ",";
            query += ");";
            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //change parcels routes(only during in branch)
        public static void ChangeRoute(int[] trackingNumberList, string nextBranchId)
        {
            string query = "update branch_parcel set next_branch=@NBID where tracking_number in (";
            for (int i = 0; i < trackingNumberList.Length; i++)
                query += trackingNumberList[i] + ",";
            query += ");";
            using (SqlConnection conn = new SqlConnection(Repository.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@NBID", nextBranchId);
                cmd.ExecuteNonQuery();
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
