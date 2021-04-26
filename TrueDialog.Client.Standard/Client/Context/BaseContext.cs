namespace TrueDialog.Context
{
    internal class BaseContext
    {
        protected readonly IApiCaller Api;
        private readonly ContextBuilder m_contextBuilder;

        public BaseContext(IApiCaller api)
        {
            Api = api;
            m_contextBuilder = new ContextBuilder(api);
        }

        protected int CurrentAccount { get { return Api.AccountId; } }

        protected TContext GetContext<TContext>()
            where TContext : BaseContext
        {
            return m_contextBuilder.GetContext<TContext>();
        }
    }
}
