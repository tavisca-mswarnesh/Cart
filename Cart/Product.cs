namespace CartApp
{
    public abstract class  Product
    {
         public abstract string Name { get;  }
         public abstract double Price { get;  }
         public abstract Category category { get; }
    }
}
