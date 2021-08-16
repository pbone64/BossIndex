namespace BossIndex.Core
{
    /// <summary>
    ///     The visual side and supplier of a boss index.
    /// </summary>
    public interface IBossIndexInformationView
    {
        public IBossIndexInformationEngine Engine { get; set; }
    }
}
