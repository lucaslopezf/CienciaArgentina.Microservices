using System;

namespace CienciaArgentina.Microservices.Storage.Azure.QueueStorage
{
	public class QueueMessage<TMessage>
	{
	    public string Id { get; internal set; }
		public string PopReceipt { get; internal set; }
		public DateTimeOffset? InsertionTime { get; internal set; }
        public DateTimeOffset? ExpirationTime { get; internal set; }
        public DateTimeOffset? NextVisibleTime { get; internal set; }
		public int DequeueCount { get; internal set; }
		public TMessage Data { get; set; }
	}
}