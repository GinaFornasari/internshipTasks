using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OrderBook
{
    public class Socket
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public event Action<string> MessageUpdated;
        public Func<string> GetSelectedItem { get; set; }
        public async Task getSocket(ClientWebSocket webSocket, string act)
        {
            Uri serverUri = new Uri("wss://ws.bitmex.com/realtime");
            if (act.Equals("Connect"))
            {
                try
                {
                    await ConnectToWebSocketServer(serverUri, webSocket);
                    await SubscribeToOrderBook(webSocket);
                }
                catch (Exception ex)
                {
                    log.Error("Could not connect to socket and subscribe to order book");
                    log.Error(ex.ToString());
                }
            }
            else
            {
                try
                {
                    await CloseWebSocket(webSocket);
                }
                catch (Exception ex)
                {
                    log.Error("Could not close socket");
                    log.Error(ex.ToString());
                }
            }
        }
        public async Task ConnectToWebSocketServer(Uri serverUri, ClientWebSocket webSocket)
        {
            try
            {
                await webSocket.ConnectAsync(serverUri, CancellationToken.None);
                log.Info("Connected to the WebSocket server.");
                string receivedMessage = await ReceiveMessage(webSocket);
                if (receivedMessage.Equals(String.Empty))
                {
                    MessageUpdated?.Invoke("Could not receive message");
                }
                else
                {
                    MessageUpdated?.Invoke(receivedMessage + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                log.Error("Could not connect to web socket server");
                log.Error($"Error: {ex.Message}");
            }
        }
        public async Task SubscribeToOrderBook(ClientWebSocket webSocket)
        {
            if (webSocket.State == WebSocketState.Open)
            {
                string symbol = GetSelectedItem?.Invoke() ?? string.Empty;
                byte[] subscriptionData = Encoding.UTF8.GetBytes("{\"op\": \"subscribe\", \"args\": [\"orderBookL2_25:" + $"{symbol}" + "\"]}");
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
                            string receivedMessage = await ReceiveMessage(webSocket);
                            MessageUpdated?.Invoke(Environment.NewLine + Environment.NewLine + receivedMessage + Environment.NewLine);
                            await Task.Delay(1);
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
        static async Task<string> ReceiveMessage(ClientWebSocket webSocket)
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
        static async Task CloseWebSocket(ClientWebSocket webSocket)
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
    }
}
