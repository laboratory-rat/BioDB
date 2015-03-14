using UnityEngine;
using System.Collections;
using System.Net;
using System.IO;

public class FTPConnector : MonoBehaviour {

    private string Addres;
    private string User;
    private string Pass;

    public FTPConnector(string addres, string user, string pass)
    {
        this.Addres = addres;
        this.User = user;
        this.Pass = pass;
    }

    public void ListDir()
    {
        // Get the object used to communicate with the server.
        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(Addres);
        request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

        // This example assumes the FTP site uses anonymous logon.
        request.Credentials = new NetworkCredential(User, Pass);

        FtpWebResponse response = (FtpWebResponse)request.GetResponse();

        Stream responseStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(responseStream);
        Debug.Log(reader.ReadToEnd());
            
        reader.Close();
        response.Close();
    }
}
