using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScanLogSyncService
{
    public class ScanLogSyncService : IService.IService
    {
        private System.Timers.Timer timer = null;
        string intervalTime = System.Configuration.ConfigurationManager.AppSettings["GetDataInterval"];

        public ScanLogSyncService()
        {
            timer = new System.Timers.Timer(int.Parse(intervalTime) * 1000);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = true;
            timer.Start();
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timer.Stop();
            try
            {
                Console.WriteLine("执行扫码数据同步");
            }
            catch (Exception ex)
            {
                SeatManage.SeatManageComm.WriteLog.Write(ex.Message);
            }
            finally
            {
                timer.Start();
            }
        }

        public void Dispose()
        {
            timer.Stop();
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }


        public override string ToString()
        {
            return "扫码数据同步获取程序";
        }
    }
}
