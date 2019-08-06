namespace CartApp
{
    public class Mobile : Product
    {
        public override string Name => "mobile";
        public override double Price =>100;
        public override Category category => Category.Electronics;
    }
}
