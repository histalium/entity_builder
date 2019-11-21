namespace EntityBuilder.Blas
{
    public class BlaBuilder : EntityBuilder<Bla>
    {
        public BlaBuilder()
        {
            RegisterHandler<AddFoo>(AddFooHandler);
            RegisterHandler<AddBar>(AddBarHandler);
        }

        private static Bla AddFooHandler(Bla org, AddFoo @event)
        {
            var nb = Clone(org);

            nb.Foo += @event.Amount;

            return nb;
        }

        private static Bla AddBarHandler(Bla org, AddBar msg)
        {
            var nb = Clone(org);

            nb.Bar += msg.Amount;

            return nb;
        }

        private static Bla Clone(Bla entity)
        {
            return new Bla
            {
                Foo = entity.Foo,
                Bar = entity.Bar
            };
        }
    }
}
