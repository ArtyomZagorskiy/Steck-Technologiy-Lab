using System;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Lab_4_Threads
{
    public partial class Form1 : Form
    {
        private BackgroundWorker encryptionWorker;

        private CancellationTokenSource cancellationTokenSource;
        private bool isPaused;
        private readonly object pauseLock = new object();

        private Thread encryptionThread;
        private ThreadPriority currentPriority; 

        TimeSpan elapsedPauseTime = new TimeSpan(0, 0, 0);
        string savedPath;

        public Form1()
        {
            InitializeComponent();
            currentPriority = ThreadPriority.Normal;

            encryptionWorker = new BackgroundWorker();
            encryptionWorker.DoWork += EncryptionWorker_DoWork;
            encryptionWorker.RunWorkerCompleted += EncryptionWorker_RunWorkerCompleted;
            encryptionWorker.ProgressChanged += EncryptionWorker_ProgressChanged;
            encryptionWorker.WorkerReportsProgress = true;

            pauseResumeButton.Enabled = false;
            cancelButton.Enabled = false;
        }

        private void EncryptionWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] args = (object[])e.Argument;
            string filePath = (string)args[0];
            string key = (string)args[1];
            bool encryption = (bool)args[2];

            try
            {
                DateTime startTime = DateTime.Now;

                if (encryption)
                {
                    string encryptedFilePath = filePath + ".enc";
                    EncryptFile(filePath, encryptedFilePath, key, sender as BackgroundWorker);
                }
                else
                {
                    DecryptFile(filePath, filePath.Substring(0, filePath.Length - 4), key, sender as BackgroundWorker);
                }

                DateTime endTime = DateTime.Now;
                TimeSpan elapsedTime = endTime - startTime - elapsedPauseTime;
                elapsedPauseTime = new TimeSpan(0, 0, 0);

                e.Result = new EncryptionResult
                {
                    EncryptedFilePath = filePath,
                    ElapsedTime = elapsedTime
                };
            }
            catch (OperationCanceledException)
            {
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void EncryptionWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            encryptionButton.Enabled = true;
            decryptionButton.Enabled = true;
            pauseResumeButton.Enabled = false;
            cancelButton.Enabled = false;
            progressBar.Value = 0;
            txtFilePath.Text = "";
            textBoxKey.Text = "";
            lblTime.Text = "";

            if (e.Cancelled)
            {
                MessageBox.Show("Процесс шифрования отменён.", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(e.Result != null)
            {
                EncryptionResult result = e.Result as EncryptionResult;

                FileInfo encryptedFileInfo = new FileInfo(result.EncryptedFilePath);
                string message = $"Шифрування завершено!\n" +
                                 $"Назва файла: {encryptedFileInfo.Name}\n" +
                                 $"Розмір файла: {encryptedFileInfo.Length} байт\n" +
                                 $"Час, витрачений на шифрування: {result.ElapsedTime.ToString(@"hh\:mm\:ss")}";
                MessageBox.Show(message, "Результати шифрування", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Помилка при шифруванні!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EncryptionWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            lblTime.Text = $"Time elapsed: {e.UserState}";
        }

        private void EncryptFile(string inputFile, string outputFile, string key, BackgroundWorker worker)
        {
            encryptionThread = Thread.CurrentThread;
            encryptionThread.Priority = currentPriority;

            using (FileStream fsInput = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
            using (FileStream fsOutput = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = new byte[16];
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (CryptoStream cryptoStream = new CryptoStream(fsOutput, encryptor, CryptoStreamMode.Write))
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead;
                    long totalBytes = fsInput.Length;
                    long bytesProcessed = 0;
                    DateTime startTime = DateTime.Now;

                    while ((bytesRead = fsInput.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        if (cancellationTokenSource.Token.IsCancellationRequested)
                        {
                            cryptoStream.Close();
                            fsOutput.Close();
                            File.Delete(outputFile);
                            throw new OperationCanceledException();
                        }

                        lock (pauseLock)
                        {
                            DateTime startPauseTime = DateTime.Now;
                            while (isPaused)
                            {
                                Monitor.Wait(pauseLock);
                            }
                            TimeSpan elapsedPause = DateTime.Now - startPauseTime;
                            startTime += elapsedPause;
                            elapsedPauseTime += elapsedPause;
                        }

                        cryptoStream.Write(buffer, 0, bytesRead);
                        bytesProcessed += bytesRead;

                        int progress = (int)((bytesProcessed * 100) / totalBytes);
                        TimeSpan elapsedTime = DateTime.Now - startTime;
                        worker.ReportProgress(progress, elapsedTime.ToString(@"hh\:mm\:ss"));
                    }
                }
            }
        }

        public void DecryptFile(string inputFile, string outputFile, string key, BackgroundWorker worker)
        {
            encryptionThread = Thread.CurrentThread;
            encryptionThread.Priority = currentPriority;

            using (FileStream fsInput = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
            using (FileStream fsOutput = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = new byte[16];

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (CryptoStream cryptoStream = new CryptoStream(fsInput, decryptor, CryptoStreamMode.Read))
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead;
                    long totalBytes = fsInput.Length;
                    long bytesProcessed = 0;
                    DateTime startTime = DateTime.Now;

                    while ((bytesRead = cryptoStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        if (cancellationTokenSource.Token.IsCancellationRequested)
                        {
                            cryptoStream.Close();
                            fsOutput.Close();
                            File.Delete(outputFile);
                            throw new OperationCanceledException();
                        }

                        
                        lock (pauseLock)
                        {
                            DateTime startPauseTime = DateTime.Now;
                            while (isPaused)
                            {
                                Monitor.Wait(pauseLock);
                            }
                            TimeSpan elapsedPause = DateTime.Now - startPauseTime;
                            startTime += elapsedPause;
                            elapsedPauseTime += elapsedPause;
                        }

                        fsOutput.Write(buffer, 0, bytesRead);
                        bytesProcessed += bytesRead;

                        int progress = (int)((bytesProcessed * 100) / totalBytes);
                        TimeSpan elapsedTime = DateTime.Now - startTime;
                        worker.ReportProgress(progress, elapsedTime.ToString(@"hh\:mm\:ss"));
                    }
                }
            }
        }

        private void selectFilebutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(fileDialog.FileName);
                txtFilePath.Text = fileName;
                savedPath = fileDialog.FileName;
            }
        }

        private void encryptionButton_Click(object sender, EventArgs e)
        {
            string filePath = savedPath;
            string key = textBoxKey.Text;
            if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(key) || (key.Length < 16 || key.Length > 16))
            {
                MessageBox.Show("Please select a file and enter a key.");
                return;
            }

            encryptionButton.Enabled = false;
            decryptionButton.Enabled = false;
            pauseResumeButton.Enabled = true;
            cancelButton.Enabled = true;

            cancellationTokenSource = new CancellationTokenSource();
            isPaused = false;

            encryptionWorker.RunWorkerAsync(new object[] { filePath, key, true });
        }

        private void decryptionButton_Click(object sender, EventArgs e)
        {
            string filePath = savedPath;
            string key = textBoxKey.Text;
            if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(key) || (key.Length < 16 || key.Length > 16))
            {
                MessageBox.Show("Please select a file and enter a key.");
                return;
            }

            encryptionButton.Enabled = false;
            decryptionButton.Enabled = false;
            pauseResumeButton.Enabled = true;
            cancelButton.Enabled = true;

            cancellationTokenSource = new CancellationTokenSource();
            isPaused = false;

            encryptionWorker.RunWorkerAsync(new object[] { filePath, key, false });
        }

        private void pauseResumeButton_Click(object sender, EventArgs e)
        {
            lock (pauseLock)
            {
                isPaused = !isPaused;

                if (!isPaused)
                {
                    Monitor.PulseAll(pauseLock);
                }
            }

            pauseResumeButton.Text = isPaused ? "Resume" : "Pause";
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
            }
        }

        private void changePriorityButton_Click(object sender, EventArgs e)
        {
            if (encryptionThread != null && encryptionThread.IsAlive)
            {
                switch (currentPriority)
                {
                    case ThreadPriority.Normal:
                        currentPriority = ThreadPriority.BelowNormal;
                        changePriorityButton.Text = "Below Normal";
                        break;
                    case ThreadPriority.BelowNormal:
                        currentPriority = ThreadPriority.Normal;
                        changePriorityButton.Text = "Normal";
                        break;
                }

                encryptionThread.Priority = currentPriority;
            }
        }
    }
}