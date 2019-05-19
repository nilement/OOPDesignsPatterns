using System;
using System.Collections.Generic;
using Objects;
using Objects.Items;

namespace Server.Facades.Shop
{
    interface IShopFacade
    {
        Response<List<Item>> GetItems(Request itemsRequest);
        Response<bool> BuyItem(Request<Guid> buyRequest);
        Response<bool> SellItem(Request<Guid> sellRequest);
    }
}
