public interface IAwaitable<TArgument>
{
	IAwaiter<TArgument> GetAwaiter();
}