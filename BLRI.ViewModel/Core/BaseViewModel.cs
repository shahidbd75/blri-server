namespace BLRI.ViewModel.Core
{
    public abstract class BaseViewModel<T>
    {
        public T Id { get; set; }
        public string UpdatedByUserId { get; set; }
    }
}
