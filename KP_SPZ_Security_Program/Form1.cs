using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KP_SPZ_Security_Program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetHDDInfo HDDInf = new GetHDDInfo();
            HDDInf.GetDeviceInfo();
            GetProcessorInfo ProcessorInf = new GetProcessorInfo();
            ProcessorInf.GetDeviceInfo();
            GetVideoControllerInfo VideoControllerInf = new GetVideoControllerInfo();
            VideoControllerInf.GetDeviceInfo();
            GetBaseBoardInfo BaseBoardInf = new GetBaseBoardInfo();
            BaseBoardInf.GetDeviceInfo();
            HardWareInfo HardWare = new HardWareInfo(HDDInf.hddInfo[0].GetSerialNumber(),
                ProcessorInf.processorInfo[0].GetProcessorName(),
                ProcessorInf.processorInfo[0].GetProcessorID(),
                VideoControllerInf.videoControllers[0].GetDeviceID(),
                BaseBoardInf.baseBoard[0].GetSerialNumber(),
                Convert.ToDateTime(EndDate.Text));
        }
    }
}
