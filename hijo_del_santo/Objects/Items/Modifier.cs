using System;

namespace Objects.Items
{
    [Serializable]

    public class Modifier
    {
        public string Name { get; }
        public double Percentage { get; }
        public int RandomNumber { get; }
        public Modifier()
        {
            var randomNumber = Common.Random.Next(Common.Modifiers.Count);
            RandomNumber = randomNumber;
            Name = Common.Modifiers[randomNumber].Item1;
            Percentage = Common.Modifiers[randomNumber].Item2;
        }

        public Modifier(int modifierId)
        {
            RandomNumber = modifierId;
            Name = Common.Modifiers[modifierId].Item1;
            Percentage = Common.Modifiers[modifierId].Item2;
        }
    }
}