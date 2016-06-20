using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;
using Ionic.Zlib;

public class FileMD5Generator
{
    struct FileEntity
    {
        string filename;
        string filehash;
    }

    [@MenuItem("Tools/生成bundle")]
    static void GenerateBundleMD5()
    {
        FileMD5Generator generator = new FileMD5Generator();
        generator.GenerateAllFiles(@"E:\update_res");
    }

    private static string GetMD5HashFromFile(string fileName)
    {
        using (FileStream file = new FileStream(fileName, FileMode.Open))
        {
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hash = md5.ComputeHash(file);

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("x2"));
            }
            return result.ToString();
        }
    }

    public void GenerateAllFiles(string rootdir)
    {
        var oldverpath = Path.Combine(rootdir, "ver");
        int ver = readOldVer(oldverpath);
        File.Delete(oldverpath);

        ver++;
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(ver.ToString());
        string[] fileNames = Directory.GetFiles(rootdir, "*", SearchOption.AllDirectories);
        foreach (string fileName in fileNames)
        {
            string md5 = GetMD5HashFromFile(fileName);
            string fname =  Path.GetFileName(fileName);
            sb.AppendLine(fname);
            sb.AppendLine(md5);
        }

        byte[] outbts = UTF8Encoding.Default.GetBytes(sb.ToString());
        using (var output = System.IO.File.Create(oldverpath))
        {
            using (Stream compressor = new GZipStream(output, CompressionMode.Compress))
            {
                compressor.Write(outbts, 0, outbts.Length);
            }
        }
    }

    int readOldVer(string oldverpath)
    {
        if (File.Exists(oldverpath)){
            Debug.Log("找到初始文件");
            using (System.IO.Stream input = System.IO.File.OpenRead(oldverpath)){
                using (Stream decompressor = new Ionic.Zlib.GZipStream(input, CompressionMode.Decompress, true)){
                    MemoryStream output = new MemoryStream();
                    byte[] working = new byte[2048];
                    int n = 1;
                    while (n != 0){
                        n = decompressor.Read(working, 0, working.Length);
                        if (n > 0){
                            output.Write(working, 0, n);
                        }
                    }
                    byte[] unzipbts = output.ToArray();
                    string content = UTF8Encoding.Default.GetString(unzipbts);
                    Debug.Log("old ver:\n" + content);
                    string[] verarr = content.Split('\n');
                    return int.Parse(verarr[0]);
                }
            }
        }
        return 0;
    }
}
