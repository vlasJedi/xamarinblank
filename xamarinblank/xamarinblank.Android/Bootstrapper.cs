namespace xamarinblank.Droid
{
    public class Bootstrapper : xamarinblank.Bootstraper
    {
        public static void Init()
        {
            // looks strange, however reference to container
            // with objects will be inserted to Resolver during contruction
            var instance = new Bootstrapper();
        }
    }
}