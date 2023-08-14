using Renci.SshNet;


namespace SFTPService
{
    public class SftpClient : Renci.SshNet.SftpClient
    {
        public SftpClient(ConnectionInfo connectionInfo) : base(connectionInfo)
        {
        }

        public SftpClient(string host, int port, string username, string password) : base(host, port, username, password)
        {
        }

        public SftpClient(string host, string username, string password) : base(host, username, password)
        {
        }

        public SftpClient(string host, int port, string username, params PrivateKeyFile[] keyFiles) : base(host, port, username, keyFiles)
        {
        }

        public SftpClient(string host, string username, params PrivateKeyFile[] keyFiles) : base(host, username, keyFiles)
        {
        }

        public void UploadFile(string sourcePath, string targetPath)
        {
            FileStream fs = File.OpenRead(sourcePath);
            UploadFile(fs, targetPath);
        }

        public void DownloadFile(string sourcePath, string targetPath)
        {
            FileStream fs = File.Create(targetPath);
            DownloadFile(sourcePath, fs);
        }
    }
}
