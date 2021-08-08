using System;
using Newtonsoft.Json;
using UnityEngine.PlayerLoop;

namespace Models.Entities
{
    public class EntityNode<T> : Entity where T : Entity
    {
        public string NodeId { get; set; }

        public EntityNode()
        {
        }

        public EntityNode(T node)
        {
            Node = node;
        }

        private T node;

        [JsonIgnore]
        public T Node
        {
            get
            {
                if (node != null)
                {
                    return node;
                }

                node = Read<T>(NodeId);
                if (node == null)
                {
                    NodeId = null;
                }

                return node;
            }
            private set
            {
                node = value ?? throw new Exception("Cannot set null value.");
                NodeId = node.Id;
            }
        }

        public override void Delete()
        {
            Delete<T>(NodeId);
        }

        public override void Update()
        {
            Update<T>(NodeId,node);
        }

        public void SaveNode()
        {
            Write(NodeId, Node);
        }
    }
}