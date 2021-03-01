/*****************************************************************************************************
文件名: MTimer.cs
作  者: MHF
描  述: 当前类为自定义的毫秒级高精确定时器类
版  本: 0.1.0
日  期: 2021.2.28
功  能：
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace MControl.Controls.Timers
{
    public partial class MTimer : IComponent, IDisposable
    {

        //***************************************************  构造函数和释构函数  ******************************************************************
        static MTimer()
        {
            timeGetDevCaps(ref caps, Marshal.SizeOf(caps));
        }
        public MTimer()
        {
            this.interval = caps.periodMin;
            this.resolution = caps.periodMin;

            this.isRunning = false;
            this.timerCallback = new TimerCallback(this.TimerEventCallback);
        }

        public MTimer(IContainer container) : this()
        {
            container.Add(this);
        }

        ~MTimer()
        {
            timeKillEvent(this.timerID);
        }

        //*****************************************************  字 段  *******************************************************************
        private static TimerCaps caps;
        private int interval;
        private bool isRunning;
        private int resolution;
        private TimerCallback timerCallback;
        private int timerID;

        //***************************************************  内部类型  ******************************************************************
        private delegate void TimerCallback(int id, int msg, int user, int param1, int param2); // timeSetEvent所对应的回调函数的签名

        /// <summary>
        /// 定时器的分辨率（resolution）。单位是ms，毫秒
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct TimerCaps
        {
            public int periodMin;
            public int periodMax;
        }

        //***************************************************  内部函数  ******************************************************************

        /// <summary>
        /// 启动指定的定时器事件。
        /// </summary>
        /// <param name="delay">以毫秒指定事件的周期。</param>
        /// <param name="resolution">以毫秒指定延时的精度，数值越小定时器事件分辨率越高。缺省值为1ms。</param>
        /// <param name="callback">指向一个回调函数。</param>
        /// <param name="user">存放用户提供的回调数据。</param>
        /// <param name="mode">指定定时器事件类型。</param>
        /// <returns></returns>
        [DllImport("winmm.dll")]
        private static extern int timeSetEvent(int delay, int resolution, TimerCallback callback, int user, int mode);

        /// <summary>
        /// 取消指定计时器事件。
        /// </summary>
        /// <param name="id">要取消的计时器事件的标识符。设置计时器事件时，timeSetEvent函数返回此标识符。</param>
        /// <returns></returns>
        [DllImport("winmm.dll")]
        private static extern int timeKillEvent(int id);

        /// <summary>
        /// 查询计时设备，以确定它的分辨率。
        /// </summary>
        /// <param name="caps">指向TimerCaps结构。此结构充满了有关计时器设备分辨率的信息。</param>
        /// <param name="sizeOfTimerCaps">TimerCaps结构的大小（以字节为单位）。</param>
        /// <returns></returns>
        [DllImport("winmm.dll")]
        private static extern int timeGetDevCaps(ref TimerCaps caps, int sizeOfTimerCaps);

        /// <summary>
        /// 计时器回调函数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="msg"></param>
        /// <param name="user"></param>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        private void TimerEventCallback(int id, int msg, int user, int param1, int param2)
        {
            if (this.Tick != null)
            {
                this.Tick(this, null);  // 引发事件
            }
        }

        //*****************************************************  属 性  *******************************************************************

        /// <summary>
        /// 获取或设置引发 Tick 事件的间隔（以毫秒为单位）。
        /// </summary>
        /// <return>
        ///  返回引发 Tick 事件的间隔（以毫秒为单位）。
        /// </return>
        [DefaultValue(100)]
        public int Interval
        {
            get
            {
                return this.interval;
            }
            set
            {
                if ((value < caps.periodMin) || (value > caps.periodMax))
                {
                    throw new Exception("超出计时范围！");
                }
                this.interval = value;
            }
        }

        /// <summary>
        /// 获取定时器是否运行
        /// </summary>
        public bool IsRunning
        {
            get
            {
                return this.isRunning;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ISite Site
        {
            set;
            get;
        }

        //*****************************************************  事 件  *******************************************************************
        public event EventHandler Disposed;  // 这个事件实现了IComponet接口
        public event EventHandler Tick;


        //*****************************************************  方 法  *******************************************************************

        /// <summary>
        /// 开始定时器
        /// </summary>
        public void Start()
        {
            if (!this.isRunning)
            {
                this.timerID = timeSetEvent(this.interval, this.resolution, this.timerCallback, 0, 1); // 间隔性地运行
                if (this.timerID == 0)
                {
                    throw new Exception("无法启动计时器");
                }
                this.isRunning = true;
            }
        }

        /// <summary>
        /// 停止定时器
        /// </summary>
        public void Stop()
        {
            if (this.isRunning)
            {
                timeKillEvent(this.timerID);
                this.isRunning = false;
            }
        }

        /// <summary>
        /// 实现IDisposable接口
        /// </summary>
        public void Dispose()
        {
            timeKillEvent(this.timerID);
            GC.SuppressFinalize(this);                //不执行析构函数
            EventHandler disposed = this.Disposed;
            if (disposed != null)
            {
                disposed(this, EventArgs.Empty);
            }
        }
    }
}
