using Catering.BLL.Interfaces;
using Catering.DAL;
using Catering.DAL.DbContexts;
using Catering.DAL.Entities.Basket;
using Catering.DAL.Entities.FoodShops;
using Catering.DAL.Entities.Order;
using Catering.DAL.Entities.Restaurnt;
using Catering.DAL.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.BLL.Services
{
    public class OrderService: BaseService, IOrderService
    {
        private readonly IRepository<Order> _repository;
        private readonly IRepository<CustomerBasket> _basketRepository;

        public OrderService(IRepository<Order> repository,
            IUnitOfWork unitOfWork, IRepository<CustomerBasket> basketRepository) : base(unitOfWork)
        {
            _repository = repository;
            _basketRepository = basketRepository;
        }

        public async Task<Order> CreateOrderAsync(string buyerEmail, int delieveryMethodId, int basketId, Address shippingAddress)
        {
            var basket = await _basketRepository.GetAsync(basketId);

            var items = new List<OrderItem>();

            var mealItems = new List<MealOrderItem>();

            foreach(var item in basket.Items)
            {
                var foodItem = await UnitOfWork.Repository<Food>().GetAsync(item.Id);
                var itemOrdered = new ProductItemOrdered(foodItem.Id, foodItem.FoodName, foodItem.PictureUrl);
                var orderItem = new OrderItem(itemOrdered, foodItem.Price, item.Quantity);
                items.Add(orderItem);
            }

            foreach(var item in basket.MealItems)
            {
                var mealItem = await UnitOfWork.Repository<Meal>().GetAsync(item.Id);
                var mealItemOrdered = new MealItemOrdered(mealItem.Id, mealItem.MealName, mealItem.PictureUrl);
                var mealOrderItem = new MealOrderItem(mealItemOrdered, mealItem.Price, item.MealQuantity);
                mealItems.Add(mealOrderItem);
            }

            var deliveryMethod = await UnitOfWork.Repository<DeliveryMethod>().GetAsync(delieveryMethodId);

            var subtotal = items.Sum(item => item.Price * item.Quantity);

            var order = new Order(items, mealItems,  buyerEmail, shippingAddress, deliveryMethod, subtotal);

            _repository.Add(order);

            await UnitOfWork.SaveChangeAsync();

            return order;
        }

        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            return await UnitOfWork.Repository<DeliveryMethod>().ListAllAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
        {
            var spec = new OrderSpecification(id, buyerEmail);

            return await UnitOfWork.Repository<Order>().GetEntityWithSpec(spec);
        }

        public async Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            var spec = new OrderSpecification(buyerEmail);

            return await UnitOfWork.Repository<Order>().ListAsync(spec);
        }

    }
}
