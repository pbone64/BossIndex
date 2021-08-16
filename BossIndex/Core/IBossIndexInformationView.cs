namespace BossIndex.Core
{
    /// <summary>
    /// The visual side of a boss index
    /// </summary>
    public interface IBossIndexInformationView
    {
        public IBossIndexInformationEngine Engine { get; set; }
    }
}
