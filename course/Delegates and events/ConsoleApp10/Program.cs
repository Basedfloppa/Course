using System.Net;

namespace BotCode
{
    class Program
    {
        public static void Main(string[] args)
        {
            string url = "https://effigis.com/wp-content/uploads/2015/02/Iunctus_SPOT5_5m_8bit_RGB_DRA_torngat_mountains_national_park_8bits_1.jpg";
            Console.WriteLine("начало программы");
            var observer = new Observer();
            var task = new ImageDownloader();
            observer._event(task);
            var thread1 = new Thread(() =>
            {
                Thread.Sleep(10000);
                task.Download(url);
            });
            var thread2 = new Thread(() =>
            {
                Console.WriteLine("нажмите A, для выхода или B для проверки состояния");
                while (true)
                {
                    ConsoleKeyInfo a = Console.ReadKey();
                    if (a.Key.ToString().ToLower().Contains("a")) { thread1.Interrupt(); Environment.Exit(0); }
                    if (a.Key.ToString().ToLower().Contains("b"))
                    {
                        if (Convert.ToInt32(thread1.ThreadState) == 16)
                        {
                            Console.WriteLine("Загрузка завершена");
                        }
                        else
                        {
                            Console.WriteLine(" Загрузка ещё идёт");
                        }
                    }
                }
            });

            thread1.Start();
            thread2.Start();
        }
    }
    class ImageDownloader
    {
        public string fileName = "bigimage.jpg";
        public WebClient myWebClient = new WebClient();
        public event Action<bool> startdownload;
        public event Action<bool> enddownload;
        public void Download(string url)
        {
            Uri remoteUri = new Uri(url);
            startdownload?.Invoke(true);
            DownloadProccess(myWebClient, remoteUri, fileName);
            enddownload?.Invoke(true);
        }
        public static async Task<int> DownloadProccess(WebClient myweb, Uri uri, string filename)
        {
            myweb.DownloadFileAsync(uri, filename);
            return 1;
        }
    }
    class Observer
    {
        private ImageDownloader _image;
        public void _event(ImageDownloader image)
        {
            _image = image;
            _image.startdownload += ImageStarted;
            _image.enddownload += ImageCompleted;
        }
        private void ImageStarted(bool obj)
        {
            Console.WriteLine("Скачивание файла началось");
        }
        private void ImageCompleted(bool obj)
        {
            Console.WriteLine("Скачивание файла закончилось");
        }
    }
}