namespace AppSlider.Domain
{
    internal interface IEntity<TId>
    {
        TId Id { get; }
    }
}
