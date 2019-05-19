using System;
using Objects.Items;

namespace Objects
{
    [Serializable]
    public class CharacterItemDto
    {
        public Character Character { get; set; }
        public Item Item { get; set; }
        public CharacterItemDto(Character _character, Item _item)
        {
            Character = _character;
            Item = _item;
        }
    }
}
