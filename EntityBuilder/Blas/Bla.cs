namespace EntityBuilder.Blas
{
    public class Bla
    {
        public int Foo { get; set; }
        public int Bar { get; set; }

        static Bla()
        {
            Empty = new Bla();
        }

        public static Bla Empty { get; }
    }
}
