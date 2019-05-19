using System;
using System.Collections.Generic;
using Objects;
using Objects.Items;

namespace Server.Facades.Shop
{
    public class ShopFacadeProxy : IShopFacade
    {
        private readonly SessionStore _sessionStore;
        private readonly ShopFacade _shopFacade;
        public ShopFacadeProxy()
        {
            _sessionStore = SessionStore.GetSessionStore();
            _shopFacade = new ShopFacade();
        }

        public Response<List<Item>> GetItems(Request itemsRequest)
        {
            if (!_sessionStore.LoggedIn(itemsRequest.SessionId))
            {
                return Response<List<Item>>.ReturnUnauthorized();
            }

            return _shopFacade.GetItems(itemsRequest);
        }

        public Response<bool> BuyItem(Request<Guid> buyRequest)
        {
            if (!_sessionStore.LoggedIn(buyRequest.SessionId))
            {
                return Response<bool>.ReturnUnauthorized();
            }

            return _shopFacade.BuyItem(buyRequest);
        }

        public Response<bool> SellItem(Request<Guid> sellRequest)
        {
            if (!_sessionStore.LoggedIn(sellRequest.SessionId))
            {
                return Response<bool>.ReturnUnauthorized();
            }

            return _shopFacade.SellItem(sellRequest);
        }
    }
}
