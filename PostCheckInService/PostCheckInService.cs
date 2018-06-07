using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PostCheckInService
{
    public class PostCheckInService : IService.IService
    {
        private System.Timers.Timer timer = null;

        public PostCheckInService()
        {
            timer = new System.Timers.Timer(2000);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = true;
            timer.Start();
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timer.Stop();
            try
            {
                Console.WriteLine("提交签到数据");
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
    }
}
