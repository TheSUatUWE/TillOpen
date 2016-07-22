using System;
using System.IO.Ports;
using System.Collections.Specialized;
using System.Configuration;

public class TillOpen
{
    static SerialPort _serialPort;

    public static void Main()
    {
        NameValueCollection settings = ConfigurationManager.GetSection("SU.appSettings") as NameValueCollection;
        string message;
        string port;

        // Create a new SerialPort object with default settings.
        _serialPort = new SerialPort();
        message = settings["Message"];
        int iMsg = Int32.Parse(message, System.Globalization.NumberStyles.HexNumber);
        message = "" + (char) iMsg;

        port = settings["Port"];
        _serialPort.PortName = port;

        // Set the read/write timeouts
        _serialPort.ReadTimeout = 500;
        _serialPort.WriteTimeout = 500;

        _serialPort.Open();

        _serialPort.WriteLine(message);

        _serialPort.Close();
    }

    // Display Port values and prompt user to enter a port. 
    public static string SetPortName()
    {
        string portName = "COM1";

        Console.WriteLine("Available Ports:");
        foreach (string s in SerialPort.GetPortNames())
        {
            portName = s;
            break;
        }

        return portName;
    }
}

