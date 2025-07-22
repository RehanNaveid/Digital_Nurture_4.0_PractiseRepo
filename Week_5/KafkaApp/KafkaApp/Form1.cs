using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Confluent.Kafka;

namespace KafkaApp
{
    public partial class Form1 : Form
    {
        private TextBox txtMessage;
        private Button btnSend;
        private ListBox lstChat;

        private IProducer<Null, string> producer;
        private IConsumer<Null, string> consumer;
        private CancellationTokenSource cts = new();

        public Form1()
        {
            InitializeComponent();  // This will be defined below
            InitializeKafka();
            StartConsumerLoop();
        }

        private void InitializeComponent()
        {
            this.Text = "Kafka Chat";
            this.Width = 400;
            this.Height = 400;

            lstChat = new ListBox
            {
                Top = 10,
                Left = 10,
                Width = 360,
                Height = 250
            };
            this.Controls.Add(lstChat);

            txtMessage = new TextBox
            {
                Top = 270,
                Left = 10,
                Width = 260
            };
            this.Controls.Add(txtMessage);

            btnSend = new Button
            {
                Text = "Send",
                Top = 270,
                Left = 280,
                Width = 90
            };
            btnSend.Click += BtnSend_Click;
            this.Controls.Add(btnSend);
        }

        private void InitializeKafka()
        {
            var producerConfig = new ProducerConfig { BootstrapServers = "localhost:9092" };
            producer = new ProducerBuilder<Null, string>(producerConfig).Build();

            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = $"chat-group-{Guid.NewGuid()}",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            consumer = new ConsumerBuilder<Null, string>(consumerConfig).Build();
            consumer.Subscribe("chat-topic");
        }

        private void StartConsumerLoop()
        {
            Task.Run(() =>
            {
                try
                {
                    while (!cts.Token.IsCancellationRequested)
                    {
                        var cr = consumer.Consume(cts.Token);
                        this.Invoke(new Action(() =>
                        {
                            lstChat.Items.Add("Friend: " + cr.Message.Value);
                        }));
                    }
                }
                catch (OperationCanceledException)
                {
                    consumer.Close();
                }
            });
        }

        private async void BtnSend_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text.Trim();
            if (!string.IsNullOrEmpty(message))
            {
                await producer.ProduceAsync("chat-topic", new Message<Null, string> { Value = message });
                lstChat.Items.Add("You: " + message);
                txtMessage.Clear();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            cts.Cancel();
            base.OnFormClosing(e);
        }
    }
}
