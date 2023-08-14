using SFTPService;

SftpClient client = new("sftp.sc-cockpit.com", 22, "AUSTRO_DIESEL", "yVvs6u1eifigJSxBij7x");
client.Connect();

// list files
Console.WriteLine("List files in the SFTP directory:");
//var files = sftpService.ListAllFiles("/test/WCA");
var files = client.ListDirectory("/test/WCA");
foreach (var file in files)
{
    if (file.IsDirectory)
    {
        Console.WriteLine($"\t Directory: [{file.FullName}]");
    }
    else if (file.IsRegularFile)
    {
        Console.WriteLine($"\t File: [{file.FullName}]");
    }
}
Console.WriteLine();

// download a file
/*Console.WriteLine("Download a file from the SFTP directory:");
const string pngFile = @"hi.png";
File.Delete(pngFile);
sftpService.DownloadFile(@"/pub/example/imap-console-client.png", pngFile);
if (File.Exists(pngFile))
{
    Console.WriteLine($"\t file {pngFile} downloaded");
}
Console.WriteLine();
*/

// upload a file // not working for this demo SFTP server due to readonly permission
Console.WriteLine("Upload a file to the SFTP directory:");
var testFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.txt");
//sftpService.UploadFile(testFile, @"/test/WCA/test.txt");
client.UploadFile(testFile, @"/test/WCA/test.txt");
//sftpService.DeleteFile(@"/test/WCA/test.txt");
Console.WriteLine();

client.Disconnect();
