namespace CienciaArgentina.Microservices.Storage.Azure.QueueStorage
{
    public interface IQueueConsumer
    {
        IQueueConsumer With(IPoolingFrequencer frequencer);
        void StartConsimung();
        void StopConsimung();
    }
}
