using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.WebSockets;
using System.Threading;
using System.Net.Sockets;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection;
using System.Web.UI.WebControls;

namespace OrderBook
{
    public partial class Form1 : Form
    {
        
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public ClientWebSocket webSocket = new ClientWebSocket();
        public Form1()
        {
            InitializeComponent();
            comboBoxCoin.SelectedItem = "XBTUSD";
        }
        private async void btnRest_Click(object sender, EventArgs e)
        {
            try
            {
                Rest rest = new Rest();
                rest.MessageUpdated += UpdateTextBoxFromRest;
                rest.GetSelectedItem = new Func<string>(GetSelectedComboBoxItem);
                await rest.getOrderBookRest();
            }
            catch (Exception ex)
            {
                log.Error("Could not get the order book");
            }
        }
        private async void btnSocket_Click(object sender, EventArgs e)
        {
            Socket sock = new Socket();
            sock.MessageUpdated += UpdateTextBoxFromSocket;
            sock.GetSelectedItem = new Func<string>(GetSelectedComboBoxItem);
            if (btnSocket.Text.Equals("Open Socket"))
            {
                btnSocket.Text = "Close Socket";
                webSocket = new ClientWebSocket();
                await sock.getSocket(webSocket, "Connect");
            }
            else
            {
                btnSocket.Text = "Open Socket";
                await sock.getSocket(webSocket, "Close");
            }
        }
        private void UpdateTextBoxFromSocket(string message)
        {
            if (txtbxSocket.InvokeRequired)
            {
                txtbxSocket.Invoke(new Action<string>(UpdateTextBoxFromSocket), message);
            }
            else
            {
                txtbxSocket.Text += message;
            }
        }
        private void UpdateTextBoxFromRest(string message)
        {
            if (txtbxRest.InvokeRequired)
            {
                txtbxRest.Invoke(new Action<string>(UpdateTextBoxFromSocket), message);
            }
            else
            {
                txtbxRest.Text += message;
            }
        }
        private string GetSelectedComboBoxItem()
        {
            if (comboBoxCoin.InvokeRequired)
            {
                return (string)comboBoxCoin.Invoke(new Func<string>(GetSelectedComboBoxItem));
            }
            else
            {
                return comboBoxCoin.SelectedItem?.ToString() ?? string.Empty;
            }
        }
        public string format(string result)
        {
            List<Order> orders = new List<Order>();
            try
            {
                orders = JsonConvert.DeserializeObject<List<Order>>(result);
            }
            catch (Exception ex)
            {
                log.Error("Unable to read JSON file");
                log.Error(ex.ToString());
                return result;
            }
            string res = "";
            foreach (Order order in orders)
            {
                res += order.getOrder() + Environment.NewLine;
            }
            return res;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtbxRest.Text = string.Empty;
            txtbxSocket.Text = string.Empty;
        }
    }
}
