using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ScanLogSyncService
{
   public class ScanLogSync
    {
        private SqlConnection DbConn = new SqlConnection();
        private string FilePath = ConfigurationManager.ConnectionStrings["FilePath"].ConnectionString;
        string strAccessConn = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;

        /// <summary>
        /// 消息通知
        /// </summary>
        /// <param name="message"></param>
        public delegate void EventHandleSync(string message);
        /// <summary>
        /// 进度事件
        /// </summary>
        public event EventHandleSync SyncMessage;
        /// <summary>
        /// 同步信息
        /// </summary>
        public event EventHandleSync SyncProgress;

        public ScanLogSync()
        {
            DbConn.ConnectionString = strAccessConn;
        }

        /// <summary>
        /// 开始同步
        /// </summary>
        public void Sync()
        {
            try
            {
                int allCount = 0;
                int successCount = 0;
                int failCount = 0;
                if (SyncProgress != null)
                {
                    SyncProgress("开始获取数据...");
                }
            }
            catch (Exception ex)
            {
                if (SyncProgress != null)
                {
                    SyncProgress("同步失败：" + ex.Message);
                }
            }
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        private DataSet GetAccessLogList()
        {
            DataSet ds = new DataSet();
            try
            {
                return ds;
            }
            catch (Exception ex)
            {
                SeatManage.SeatManageComm.WriteLog.Write("获取刷卡记录失败:" + ex.Message);
                throw ex;
            }
            finally
            {
                DbConn.Close();
            }

        }

    }
}
