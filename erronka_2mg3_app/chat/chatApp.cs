using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace erronka_2mg3_app.chat
{
    public partial class chatApp : Form
    {
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;
        private string nombreUsuario;

        public chatApp(string userName)
        {
            InitializeComponent();
            nombreUsuario = userName;
        }

        private void chatApp_Load(object sender, EventArgs e)
        {
            userNameText.Text = nombreUsuario;

            string host = "192.168.115.153"; // Dirección del servidor
            int port = 5555; // Puerto del servidor

            try
            {
                client = new TcpClient(host, port);
                NetworkStream stream = client.GetStream();
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream) { AutoFlush = true };

                ShowMessage($"Conectado al servidor en {host}:{port}");

                // Iniciar el hilo para recibir mensajes del servidor
                System.Threading.Thread receiveThread = new System.Threading.Thread(ReceiveMessages);
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                ShowError("Error al conectar con el servidor", ex.Message);
            }
        }

        private void ReceiveMessages()
        {
            try
            {
                string message;
                while ((message = reader.ReadLine()) != null)
                {
                    Invoke(new Action(() => ShowMessage(message)));
                }
            }
            catch (Exception ex)
            {
                ShowError("Error al recibir mensajes", ex.Message);
            }
        }

        private void sendMessage()
        {
            string message = sendTextBox.Text;
            if (!string.IsNullOrEmpty(message))
            {
                try
                {
                    string usuario = nombreUsuario;
                    string fullMessage = $"{usuario}: {message}";
                    writer.WriteLine(fullMessage);
                    ShowMessage($"Tú: {message}");
                    sendTextBox.Clear();
                }
                catch (Exception ex)
                {
                    ShowError("Error al enviar mensaje", ex.Message);
                }
            }
            else
            {
                ShowError("Mensaje vacío", "No puedes enviar un mensaje vacío.");
            }
        }


        private void ShowMessage(string message, bool isSentByUser = false)
        {
            if (chatPanel.InvokeRequired)
            {
                chatPanel.Invoke(new Action(() => ShowMessage(message, isSentByUser)));
            }
            else
            {
                Label newMessageLabel = new Label
                {
                    AutoSize = true,
                    Text = message,
                    Margin = new Padding(5),
                    Padding = new Padding(10),
                    ForeColor = Color.White,
                    BackColor = isSentByUser ? Color.LightBlue : Color.LightGray,
                    TextAlign = isSentByUser ? ContentAlignment.MiddleRight : ContentAlignment.MiddleLeft,
                    MaximumSize = new Size(chatPanel.ClientSize.Width - 20, 0) // Limitar ancho
                };

                // Calcular posición manual del Label
                if (chatPanel.Controls.Count > 0)
                {
                    Control lastControl = chatPanel.Controls[chatPanel.Controls.Count - 1];
                    newMessageLabel.Top = lastControl.Bottom + 5; // Espaciado de 5 píxeles
                }
                else
                {
                    newMessageLabel.Top = 5; // Primer mensaje
                }

                newMessageLabel.Left = isSentByUser ? chatPanel.ClientSize.Width - newMessageLabel.PreferredWidth - 10 : 10;

                // Añadir el nuevo Label al Panel
                chatPanel.Controls.Add(newMessageLabel);

                // Ajustar AutoScrollMinSize para reflejar el tamaño del contenido
                chatPanel.AutoScrollMinSize = new Size(chatPanel.ClientSize.Width, newMessageLabel.Bottom + 10);

                // Asegurar que el último mensaje sea visible
                chatPanel.ScrollControlIntoView(newMessageLabel);
            }
        }




        private void ShowError(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void closeChatButton_Click(object sender, EventArgs e)
        {
            try
            {
                reader?.Close();
                writer?.Close();
                client?.Close();
                ShowMessage("Conexión cerrada.");
            }
            catch (Exception ex)
            {
                ShowError("Error al cerrar conexión", ex.Message);
            }
        }

        private void sendButton_Click_1(object sender, EventArgs e)
        {
            sendMessage();
        }

        private void chatGroup_Enter(object sender, EventArgs e)
        {

        }

        private void chatPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
