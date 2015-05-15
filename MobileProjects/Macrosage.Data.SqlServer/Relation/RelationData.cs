using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Macrosage.Data.SqlServer.DBUtility;
using Macrosage.Model.ViewModel.Relation;


namespace Macrosage.Data.SqlServer.Friend
{
    public class RelationData : BaseDB
    {

        #region 列表

        /// <summary>
        /// 好友分组及统计
        /// </summary>
        ///<remarks>reck 2014-12-25</remarks>
        /// <param name="cvNumber"></param>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public DataTable GetGroupsByIdV1(long cvNumber, int typeId)
        {
            return ExecuteDataTable(MacrosageUserRoster, CommandType.StoredProcedure,
                "[Proc_Guru_Friend_GetGroupsByIdV1_M]",
                MakeParametersByInt64(cvNumber, typeId));
        }

        ///  <summary>
        ///  获取指定好友分组中的人、黑名单及回收站
        ///  </summary>
        /// <remarks>reck 2014-12-25</remarks>
        ///  <param name="cvNumber">操作人</param>
        ///  <param name="groupId">分组Id</param>
        /// <param name="typeId"></param>
        /// <param name="status">好友状态</param>
        ///  <param name="keyWord">搜索关键词</param>
        ///  <param name="pageIndex"></param>
        ///  <param name="pageSize"></param>
        ///  <returns></returns>
        public IList<DataTable> GetPeoplesByGroupIdAndStatusV1(long cvNumber, long groupId, int typeId, int status, string keyWord, int pageIndex, int pageSize)
        {
            var parameters = new List<SqlParameter>
            {
                MakeParameter("@cvNumber", SqlDbType.BigInt, cvNumber),
                MakeParameter("@groupId", SqlDbType.BigInt, groupId),
                MakeParameter("@status", SqlDbType.TinyInt, status),
                MakeParameter("@typeId", SqlDbType.TinyInt, typeId),
                MakeParameter("@keyWord", SqlDbType.VarChar, keyWord),
                MakeParameter("@pageIndex", SqlDbType.Int, pageIndex),
                MakeParameter("@pageSize", SqlDbType.Int, pageSize)
            };
            return
                ExecuteDataSet(MacrosageUserRoster, CommandType.StoredProcedure,
                    "[Proc_Guru_Friend_GetPeoplesByGroupIdAndStatusV1_M]", parameters).Tables.Cast<DataTable>().ToList();
        }

        #endregion 

        #region 分组管理

        /// <summary>
        /// Description：添加和修改好友分组
        /// </summary>
        /// <param name="model">model实体</param>
        /// <returns>返回插入当前行的id</returns>
        public DataTable InsertOrUpdateFriendGroup(FriendGroupModel model)
        {
            var parameters = new List<SqlParameter>() {
                MakeParameter("@FriendGroupId",SqlDbType.BigInt,model.FriendGroupId),
                MakeParameter("@CvNumber",SqlDbType.BigInt,model.CvNumber),
                MakeParameter("@GroupName",SqlDbType.VarChar,model.GroupName)
            };
            return ExecuteDataTable(MacrosageUserRoster, CommandType.StoredProcedure, "Macrosage_User_Roster.dbo.Proc_Guru_Friend_EditFriendGroupV1_M", parameters);
        }

        /// <summary>
        /// Description：删除好友分组
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelFriendGroup(long id, long cvNumber)
        {
            var parameters = new List<SqlParameter>() { 
            MakeParameter("@id",SqlDbType.BigInt,id),
            MakeParameter("@cvNumber",SqlDbType.BigInt,cvNumber)
            };
            return ExecuteScalarByInt(MacrosageUserRoster, CommandType.StoredProcedure, "Macrosage_User_Roster.dbo.Proc_Guru_Friend_DelGroupV1_M", parameters);
        }

        #endregion

        #region 好友管理

        /// <summary>
        /// Description：管理好友 ( model.Status:  0：删除，1: 正常,2：拉黑，3：放入回收站)
        /// </summary>
        /// <param name="model">model.Status:  0：删除，1: 正常,2：拉黑，3：放入回收站</param>
        /// <returns></returns>
        public int ManageFriend(MyFriendModel model)
        {
            var parameters = new List<SqlParameter>() {
                MakeParameter("@CvNumber",SqlDbType.BigInt,model.CvNumber),
                MakeParameter("@FriendCvNumber",SqlDbType.BigInt,model.FriendCvNumber),
                MakeParameter("@typeCode",SqlDbType.TinyInt,model.Status)
            };
            return ExecuteNonQuery(MacrosageUserRoster, CommandType.StoredProcedure, "Macrosage_User_Roster.dbo.Proc_Guru_Friend_ManageFriendV1_M", parameters);
        }

        #endregion
    }
}
