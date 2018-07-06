namespace AppVerse.Jewel.Entities
{



    public class LengthUnitSystem : IUnitSystemUnit>
    {
        public Unit DefaultUnit => throw new System.NotImplementedException();

        public Unit SelectedUnit => throw new System.NotImplementedException();

        public Unit Convert(Unit from, Unit to)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IUnitSystem
    {
        LengthUnits MeasurementUnit { get; }
    }
    internal enum UnitType
    {
        Length
    }


    public interface IUnitSystem<TIUnitSystem> where TIUnitSystem :IUnitSystem
    {
        TIUnitSystem DefaultUnit { get; }
        TIUnitSystem SelectedUnit { get; }
        TIUnitSystem Convert(TIUnitSystem from, TIUnitSystem to);
    }





}