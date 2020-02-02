namespace vue_spa.ServiceInterface
{
    public interface ITenant
    {
        string Key { get; set; }
    }

    public class Tenant : ITenant
    {
        public Tenant()
        {
            Key = null;
        }
        public string Key { get; set; }
    }
}