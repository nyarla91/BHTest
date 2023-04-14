using System;
using System.Collections.Generic;
using System.Linq;
using Mirror;
using Source.Gameplay.Character;
using UnityEngine;

namespace Source
{
    public class NetworkManager : Mirror.NetworkManager
    {
        public static NetworkManager Singleton => (NetworkManager) singleton;
        
        private readonly List<CharacterComposition> _playerObjects = new List<CharacterComposition>();

        public List<CharacterComposition> PlayerObjects => _playerObjects.ToList();

        public event Action<CharacterComposition> PlayerAdded;
        public event Action<CharacterComposition> PlayerRemoved;

        public override void OnServerDisconnect(NetworkConnectionToClient conn)
        {
            base.OnServerDisconnect(conn);
            for (var i = PlayerObjects.Count - 1; i >= 0; i--)
            {
                CharacterComposition composition = PlayerObjects[i];
                if (!composition.connectionToClient.Equals(conn))
                    continue;
                PlayerRemoved?.Invoke(composition);
                PlayerObjects.RemoveAt(i);
                break;
            }
        }

        public override void OnServerAddPlayer(NetworkConnectionToClient conn)
        {
            Transform startPos = GetStartPosition();
            GameObject player = startPos != null
                ? Instantiate(playerPrefab, startPos.position, startPos.rotation)
                : Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);

            CharacterComposition composition = player.GetComponent<CharacterComposition>();
            _playerObjects.Add(composition);
            PlayerAdded?.Invoke(composition);
            
            player.name = $"{playerPrefab.name} [connId={conn.connectionId}]";
            NetworkServer.AddPlayerForConnection(conn, player);
        }
    }
}