﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Poker.Server
{
    public sealed class PokerUserFactory
    {
        private static object _locker = new object();
        private static PokerUserFactory _instance;
        private  List<PokerUser> _pokerUserList;


        private PokerUserFactory()
        {
            _pokerUserList = new List<PokerUser>();
        }
        public static PokerUserFactory Instance
        {
            get
            {
                lock (_locker)
                {
                    if (_instance == null)
                        _instance = new PokerUserFactory();
                    return _instance;
                }
            }
        }
        public static List<PokerUser> GetListPokerUsers()
        {
            return Instance._pokerUserList;
        }
        public bool CreatePlayer(TcpClient client, Action<Poker.Shared.Message> incomingmessage_callback ,   string username, string encyrpted_pwd)
        {
            if (Authenticate(username, encyrpted_pwd))
            {
                PokerUser u = new PokerUser(client, incomingmessage_callback, username);
                return true;
            }
            return false;
        }
        public void AddToList(PokerUser user)
        {
            if (user.UserName != "")
            {
                if (Exists(user.UserName))
                {
                    PokerUser pokeruser = Instance._pokerUserList.Find(a => a.UserName == user.UserName);
                    pokeruser.ReJoin(user.TcpClient, user.Incomingmessage_callback);
                }
                else
                {
                    _pokerUserList.Add(user);
                }
            }
        }
        private bool Exists(string username)
        {
            if (Instance._pokerUserList.Exists(a => a.UserName == username))
                return true;
            return false;
        }
        private bool Authenticate(string username, string encrypted_pwd)
        {
            return true;
        }
    }
}

