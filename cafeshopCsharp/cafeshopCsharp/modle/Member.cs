
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

using cafeshopCsharp.connection_DB;
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

        public IEnumerable<Member> GetAllMembers()
        {
            // Using Dapper's Query method to execute the SQL query and map the result to Member objects
            return dbConnection.Query<Member>("SELECT * FROM tb_member");
        }



        public Member GetMember(string mbPhoneNumber) {
            return dbConnection.QueryFirstOrDefault<Member>("SELECT * FROM tb_member WHERE mbPhoneNumber=@PhoneNumber", new { PhoneNumber = mbPhoneNumber });
        }

        public void AddMember(Member addMember)
        {
            string sql = "INSERT INTO tb_member (mbName, mbPhoneNumber, mbAddress, mbPoints) VALUES (@mbName, @mbPhoneNumber, @mbAddress, @mbPoints)";
            dbConnection.Execute(sql, addMember);
        }


        public void UpdataMember(Member updateMember) {

            string sql = "UPDATE tb_member SET mbName=@mbName,mbPhoneNumber=@mbPhoneNumber,mbAddress=@mbAddress WHERE mbId=@mbId";
            dbConnection.Execute(sql, updateMember);
        }

        public void UpdatePoints(Member updatePoints) {

            string sql = "UPDATE tb_member SET mbPoints=@mbPoints WHERE mbPhoneNumber=@mbPhoneNumber";
            dbConnection.Execute(sql, updatePoints);
        }

        public void DeleteMember(Member deleteMember) {
            string sql = "DELETE FROM tb_member where mbId=@mbId";
            dbConnection.Execute(sql, deleteMember);
        }

    }
}
