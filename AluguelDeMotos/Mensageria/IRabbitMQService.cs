namespace AluguelDeMotos.Mensageria
{
    public interface IRabbitMQService
    {
        public void PostMessage(string message);
    }
}
