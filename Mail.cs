using System;
using System.Text;
using Crestron.SimplSharp;      // For Basic SIMPL# Classes

namespace SendMail
{
    public class Mail
    {
        public delegate ushort OutputDelegate(SimplSharpString str);
        
        public String server;
        public ushort port;
        public String user;
        public String password;
        public String sendFrom;
        public String sendTo;
        public String sendCC;
        public String subject;
        public String body;
        public short err;
        public String errmsg;

        public Mail()
        {
        }

        public OutputDelegate myDel
        {
            get;
            set;
        }

        public string SendEMail()
        {
            try
            {
                CrestronMailFunctions.SendMailErrorCodes error = CrestronMailFunctions.SendMail(server, port, true, user, password, sendFrom, sendTo, sendCC, subject, body, 0, "");
                err = (short)error;
                switch (err)
                {
                    case -14:
                        {
                            errmsg = ("General SendMail error");
                            break;
                        }
                    case -13:
                        {
                            errmsg = ("Send Failed");
                            break;
                        }
                    case -12:
                        {
                            errmsg = ("No Server Address");
                            break;
                        }
                    case -11:
                        {
                            errmsg = ("Ethernet not enabled");
                            break;
                        }
                    case -10:
                        {
                            errmsg = ("Invalid Parameter");
                            break;
                        }
                    case -9:
                        {
                            errmsg = ("Auth Login Unsupported");
                            break;
                        }
                    case -8:
                        {
                            errmsg = ("Error Authentication");
                            break;
                        }
                    case -7:
                        {
                            errmsg = ("Error NU Buffers");
                            break;
                        }
                    case -6:
                        {
                            errmsg = ("Error NU Connect");
                            break;
                        }
                    case -5:
                        {
                            errmsg = ("Error Recv");
                            break;
                        }
                    case -4:
                        {
                            errmsg = ("Error Send");
                            break;
                        }
                    case -3:
                        {
                            errmsg = ("Error Connect");
                            break;
                        }
                    case -2:
                        {
                            errmsg = ("Illegal CMD");
                            break;
                        }
                    case -1:
                        {
                            errmsg = ("Error Fatal");
                            break;
                        }
                    case 0:
                        {
                            errmsg = ("msg sent");
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                CrestronConsole.PrintLine("Error sending command: {0} ", ex.Message);
            }
            return "error";
        }
    }
}