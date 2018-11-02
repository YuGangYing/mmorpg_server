﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

namespace MMO
{
	public class MMOClient : SingleMonoBehaviour<MMOClient>
	{
		NetworkClient client;
		UnityAction<NetworkMessage> onConnect;
		UnityAction<NetworkMessage> onRecieveMessage;
		UnityAction<NetworkMessage> onRecievePlayerInfo;

		void Start ()
		{
			client = new NetworkClient ();
			client.RegisterHandler (MsgType.Connect, OnConnect);
			client.RegisterHandler (MsgType.Disconnect, OnDisconnect);
			client.RegisterHandler (MessageConstant.PLAYER_INIT_INFO, OnRecievePlayerInfo);
			client.RegisterHandler (MessageConstant.SERVER_TO_CLIENT_MSG, OnRecieveMessage);
		}

		public bool IsConnected {
			get { 
				return client.isConnected;
			}
		}

		public void Send (short msgType, MessageBase msg)
		{
			client.Send (msgType, msg);
		}

		public void Connect (string ip, int port, UnityAction<NetworkMessage> onConnect, UnityAction<NetworkMessage> onRecievePlayerInfo, UnityAction<NetworkMessage> onRecieveMessage)
		{
			Debug.Log (string.Format ("{0},{1}", ip, port));
			this.onConnect = onConnect;
			this.onRecievePlayerInfo = onRecievePlayerInfo;
			this.onRecieveMessage = onRecieveMessage;
			client.Connect (ip, port);
		}

		void OnConnect (NetworkMessage nm)
		{
			Debug.unityLogger.Log ("<color=green>Connect</color>");
			if (onConnect != null)
				onConnect (nm);
		}

		void OnDisconnect (NetworkMessage nm)
		{
			Debug.unityLogger.Log ("<color=red>Disconnect</color>");
		}

		void OnRecievePlayerInfo (NetworkMessage msg)
		{
			if (onRecievePlayerInfo != null)
				onRecievePlayerInfo (msg);
		}

		void OnRecieveMessage (NetworkMessage msg)
		{
			if (onRecieveMessage != null)
				onRecieveMessage (msg);
		}
	}
}