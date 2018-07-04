using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace Animations
{
    public class FalaSerial
    {
        public Action<string> m_pinos;
        public Action<string> m_dadosRX;
        public Action<string> m_atualizaTela;
        SerialPort m_ser = new SerialPort();
        System.Windows.Threading.Dispatcher dispatcher;
        string m_selCOMport = "";

        public FalaSerial(System.Windows.Threading.Dispatcher _dispatcher)
        {
            dispatcher = _dispatcher;
            m_ser.DataReceived += M_ser_DataReceived;
            m_ser.ErrorReceived += M_ser_ErrorReceived;
            m_ser.PinChanged += M_ser_PinChanged;
        }
        private void M_ser_PinChanged(object sender, SerialPinChangedEventArgs e)
        {
            switch (e.EventType)
            {
                case SerialPinChange.CtsChanged:
                    break;
                case SerialPinChange.DsrChanged:
                    break;
                case SerialPinChange.CDChanged:
                    break;
                case SerialPinChange.Ring:
                    break;
                case SerialPinChange.Break:
                    break;
                default:
                    break;
            }
        }
        public DataTable enumComms()
        {
            DataTable tb = new DataTable("COMs");
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            tb.Columns.Add(new DataColumn("COMx"));
            foreach (var p in ports)
            {
                tb.LoadDataRow(new object[] { p }, true);
            }
            //lstBytes.Clear();
            //listBox1.DisplayMemberPath = "COMx";
            //listBox1.SelectedValuePath = "COMx";
            //listBox1.ItemsSource = tb.DefaultView;
            //listBox1.DataContext = tb.DefaultView;
            return tb;
        }

        private void M_ser_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            switch (e.EventType)
            {
                case SerialError.TXFull:
                    break;
                case SerialError.RXOver:
                    break;
                case SerialError.Overrun:
                    break;
                case SerialError.RXParity:
                    break;
                case SerialError.Frame:
                    break;
                default:
                    break;
            }
        }

        private void M_ser_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort serial = sender as SerialPort;
            switch (e.EventType)
            {
                case SerialData.Chars:
                    break;
                case SerialData.Eof:
                    break;
                default:
                    break;
            }
            if(m_dadosRX != null)
            {
                dispatcher.Invoke(m_dadosRX, serial.ReadExisting());
            }
                
        }
        public void connect(string selCOMport)
        {
            m_ser.PortName = m_selCOMport = selCOMport;
            if (m_ser.IsOpen)
                m_ser.Close();
            m_ser.Open();
            m_ser.DataReceived += new SerialDataReceivedEventHandler(M_ser_DataReceived);
            m_ser.Write("R\\");
        }
        public void write(string tx)
        {
            if(m_ser != null)
                if(m_ser.IsOpen)
                    m_ser.Write(tx);
        }
    }
}
