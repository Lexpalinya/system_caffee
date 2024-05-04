
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

using cafeshopCsharp.connection_DB;
using System.Windows.Forms;

namespace cafeshopCsharp.modle
{
    public class Member
    {
        public int mbId { get; set; }
        public string mbName { get; set; }
        public string mbPhoneNumber { get; set; }
        public string mbAddress { get; set; }
        public int mbPoints { get; set; }
    }


    public class MemberRepository
    {
        private readonly IDbConnection dbConnection;

        public MemberRepository(IDbConnection connection)
        {
            dbConnection = connection ?? throw new ArgumentNullException(nameof(connection));
        }
        // GetAllMember ----------------------------------------------------------------------------
        public IEnumerable<Member> GetAllMembers()
        {
            try {
                return dbConnection.Query<Member>("SELECT * FROM tb_member");
            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Enumerable.Empty<Member>();
            }



        }


        //GetMember -----------------------------------------------------------------------------------------
        public Member GetMember(Member mb) {

            try {
                string sql = "SELECT * FROM tb_member WHERE mbPhoneNumber=@mbPhoneNumber";
                return dbConnection.QueryFirstOrDefault<Member>(sql, mb)??null;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        } 
        // Add Member --------------------------------------------------------------------------------------
        public void AddMember(Member addMember)
        {
            try
            {
                string sql = "INSERT INTO tb_member (mbName, mbPhoneNumber, mbAddress, mbPoints) VALUES (@mbName, @mbPhoneNumber, @mbAddress, @mbPoints)";
                int rowAffected=dbConnection.Execute(sql, addMember);

                if (rowAffected == 1)
                {
                    MessageBox.Show("ບັນທຶກສຳເລັດ", "Save", MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Update Member -----------------------------------------------------------------------------------
        public void UpdateMember(Member updateMember) {

            try {
                string sql = "UPDATE tb_member SET mbName=@mbName,mbPhoneNumber=@mbPhoneNumber,mbAddress=@mbAddress WHERE mbId=@mbId";
                int rowAffected=dbConnection.Execute(sql, updateMember);



                if (rowAffected == 0)
                {
                    MessageBox.Show("ແກ້ໄຂຜິດພາດ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("ແກ້ໄຂສຳເລັດ", "Edit", MessageBoxButtons.OK);
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Update Point Member -----------------------------------------------------------------------------
        public void UpdatePoints(Member updatePoints) {

           
            try
            {
                string sql = "UPDATE tb_member SET mbPoints=@mbPoints WHERE mbPhoneNumber=@mbPhoneNumber";
                int rowAffected = dbConnection.Execute(sql, updatePoints);

                if (rowAffected == 0)
                {
                    MessageBox.Show("ແກ້ໄຂຜິດພາຍດ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("ແກ້ໄຂສຳເລັດ", "Edit", MessageBoxButtons.OK);
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Delete Member -----------------------------------------------------------------------------------
        public void DeleteMember(Member deleteMember) {
            try { 
                string sql = "DELETE FROM tb_member where mbId=@mbId";
                int rowAffected=dbConnection.Execute(sql, deleteMember);

                if (rowAffected == 0)
                {
                    MessageBox.Show("ລົບຜິດພາຍດ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("ລົບສຳເລັດ", "DELETE", MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
