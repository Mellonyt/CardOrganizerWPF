﻿using System;
using System.Collections.Generic;

namespace CardOrganizerWPF
{
    class RemotingMessenger : MarshalByRefObject, IMessenger
    {
        private static Object lockObj;
        private Queue<byte[]> messages;
        private int register;

        public RemotingMessenger()
        {
            messages = new Queue<byte[]>();
            lockObj = new Object();
            register = 0;
        }

        public int Register()
        {
            lock(lockObj)
            {
                register += 1;
            }
            return register;
        }

        public void SendMessage(int id, byte[] message)
        {
            messages.Enqueue(message);
        }

        public byte[] GetMessage()
        {
            return messages.Count > 0 ? messages.Dequeue() : null; 
        }
    }
}