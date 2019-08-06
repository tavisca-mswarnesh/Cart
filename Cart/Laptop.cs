namespace CartApp
{
    public class Laptop : Product
    {
        public override string Name => "laptop";
        public override double Price => 1000;
        public override Category category => Category.Electronics;

    }
}
