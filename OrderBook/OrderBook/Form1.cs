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

namespace OrderBook
{
    public partial class Form1 : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Form1));
        public static ClientWebSocket webSocket = new ClientWebSocket();
        public Form1()
        {
            InitializeComponent();
        }
        private async void btnRest_Click(object sender, EventArgs e)
        {
            try
            {
                await getOrderBookRest();
            }
            catch (Exception ex)
            {
                log.Error("Could not get the order book");
            }
        }
        public async Task getOrderBookRest()
        {
            string symbol = "XBTUSD"; 
            int depth = 25;
            string result = await MakeRestCall($"https://www.bitmex.com/api/v1/orderBook/L2?symbol={symbol}&depth={depth}");
            if (result.Equals(String.Empty))
            {
                log.Error("Could not get a rest resoponse");
                txtbxRest.Text += "Error while getting response" +Environment.NewLine;
            }
            else
            {
                txtbxRest.Text += format(result);
            }
        }
        static async Task<string> MakeRestCall(string apiUrl)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        log.Error("Response status code not succesful");
                        log.Error($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Something went wrong while trying to make a REST call"); 
                log.Error(ex.ToString());
            }
            return null; 
        }
        private async void btnSocket_Click(object sender, EventArgs e)
        {
            if (btnSocket.Text.Equals("Open Socket"))
            {
                btnSocket.Text = "Close Socket";
                webSocket = new ClientWebSocket();
                await getSocket("Connect");
            }
            else
            {
                btnSocket.Text = "Open Socket";
                await getSocket("Close");
            }
        }
        public async Task getSocket(string act)
        {
            Uri serverUri = new Uri("wss://ws.bitmex.com/realtime");
            if (act.Equals("Connect"))
            {
                try
                {
                    await ConnectToWebSocketServer(serverUri);
                    await SubscribeToOrderBook();
                }
                catch (Exception ex )
                {
                    log.Error("Could not connect to socket and subscribe to order book"); 
                    log.Error(ex.ToString()); 
                }
            }
            else
            {
                try
                {
                    await CloseWebSocket();
                }catch(Exception ex)
                {
                    log.Error("Could not close socket");
                    log.Error(ex.ToString());
                }
            }
        }
        public async Task ConnectToWebSocketServer(Uri serverUri)
        {
            try
            {
                await webSocket.ConnectAsync(serverUri, CancellationToken.None);
                log.Info("Connected to the WebSocket server.");
                string receivedMessage = await ReceiveMessage();
                if(receivedMessage.Equals(String.Empty))
                {
                    txtbxSocket.Text += "Could not receive message"; 
                }
                else
                {
                    txtbxSocket.Text += receivedMessage + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                log.Error("Could not connect to web socket server"); 
                log.Error($"Error: {ex.Message}");
            }
        }
        public async Task SubscribeToOrderBook()
        {
            if (webSocket.State == WebSocketState.Open)
            {
                byte[] subscriptionData = Encoding.UTF8.GetBytes("{\"op\": \"subscribe\", \"args\": [\"orderBookL2_25:XBTUSD\"]}");
                try
                {
                    await webSocket.SendAsync(new ArraySegment<byte>(subscriptionData), WebSocketMessageType.Text, true, CancellationToken.None);
                    log.Info("Subscribed to order book updates.");
                    while (webSocket.State == WebSocketState.Open)
                    {
                        byte[] buffer = new byte[1024];
                        WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                        if (result.MessageType == WebSocketMessageType.Text)
                        {
                            string receivedMessage = await ReceiveMessage();
                            txtbxSocket.Text += receivedMessage + Environment.NewLine;
                            await Task.Delay(1000);
                        }
                    }
                }
                catch (Exception ex)
                {
                    log.Error("Could not subscribe to order book");
                    log.Error($"Error: {ex.Message}");
                }
            }
            else
            {
                log.Info("WebSocket connection is not open.");
            }
        }
        static async Task<string> ReceiveMessage()
        {
            byte[] buffer = new byte[1024];
            try
            {
                WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                return Encoding.UTF8.GetString(buffer, 0, result.Count);
            }
            catch (Exception ex)
            {
                log.Error("Could not recieve messages from the socket");
                log.Error($"Error: {ex.Message}");
                return "";
            }
        }
        static async Task CloseWebSocket()
        {
            if (webSocket.State == WebSocketState.Open)
            {
                try
                {
                    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing connection", CancellationToken.None);
                    log.Info("WebSocket connection closed.");
                }
                catch (Exception ex)
                {
                    log.Error("Could not close Async");
                    log.Error($"Error: {ex.Message}");
                }
            }
            else
            {
                log.Info("WebSocket connection is not open.");
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
    }
}
