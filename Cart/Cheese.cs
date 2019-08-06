namespace CartApp
{
    public class Cheese : Product
    {
        public override string Name => "Cheese";

        public override double Price => 10;

        public override Category category => Category.Dairy;
    }
}
