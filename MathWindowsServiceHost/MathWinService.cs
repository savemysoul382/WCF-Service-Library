using System;
using System.ServiceModel;
using System.ServiceProcess;
using MathServiceLibrary;

namespace MathWindowsServiceHost
{
    public partial class MathWinService : ServiceBase
    {
        private ServiceHost myHost;
        public MathWinService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // Проверить для подстраховки.
            this.myHost?.Close();
            // Создать хост.
            this.myHost = new ServiceHost(typeof(MathService));

            //2й способ
            this.myHost?.Close();
            // Create the host and specify a URL for an HTTP binding.
            this.myHost = new ServiceHost(typeof(MathService),
                new Uri("http://localhost:8080/MathServiceLibrary"));
            this.myHost.AddDefaultEndpoints();

            // Open the host.
            this.myHost.Open();

            // Указать ABC в коде.
            //Uri address = new Uri("http://localhost:8080/MathServiceLibrary") ;
            //WSHttpBinding binding = new WSHttpBinding();
            //Type contract = typeof(IBasicMath);
            //// Добавить эту конечную точку.
            //this.myHost.AddServiceEndpoint(contract, binding, address);
            //// Открыть хост.
            //this.myHost.Open();
        }

        protected override void OnStop()
        {
            // Остановить хост.
            this.myHost?.Close();
        }
    }
}
