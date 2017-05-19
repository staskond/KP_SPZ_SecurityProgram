using kp_spz_klass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
            BinaryFormatter formatter = new BinaryFormatter();
            //OpenFileDialog file = new OpenFileDialog();
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
                BaseBoardInf.baseBoard[0].GetSerialNumber());
            FileStream fs = new FileStream("E:\\hardware.dat", FileMode.Open);
            try
            {
                HardWareInfo newasd = (HardWareInfo)formatter.Deserialize(fs);
            }
            catch (SerializationException )
            {
                MessageBox.Show("Failed to deserialize.", "Error", MessageBoxButtons.OK);
                throw;
            }
            finally
            {
                fs.Close();
            }
            //
            //fs.Close();
            //if(file.ShowDialog() == DialogResult.OK && file.FileName != null)
            //{
            //using (FileStream fs = new FileStream("E:\\license.dat", FileMode.OpenOrCreate))
            //{
            //   // HardWareInfo newHardWareInfo = (HardWareInfo)formatter.Deserialize(fs);
            //}
            //}
            MessageBox.Show("Файл-лицензия успешно сгенирирован!", "Успешно!", MessageBoxButtons.OK);
        }
    }
}
