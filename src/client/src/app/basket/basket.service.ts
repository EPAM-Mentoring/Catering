import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Basket, IBasket, IBasketItem, IBasketMealItem, IBasketTotals } from '../shared/models/basket';
import { IDeliveryMethod } from '../shared/models/deliveryMethod';
import { IFood } from '../shared/models/food';
import { IMeal } from '../shared/models/meal';

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  baseUrl = environment.apiUrl;
  private basketSource = new BehaviorSubject<IBasket>(null);
  basket$ = this.basketSource.asObservable();
  private basketTotalSource = new BehaviorSubject<IBasketTotals>(null);
  basketTotal$ = this.basketTotalSource.asObservable();
  shipping = 0;

  constructor(private http: HttpClient) { }

  getBasket(id: number) {
    return this.http.get(this.baseUrl + 'basket?id=' + id)
     .pipe(
       map((basket: IBasket) => {
         this.basketSource.next(basket);
         this.calculateTotals();  
       })
     );
  }

  setBasket(basket: IBasket) {
    return this.http.post(this.baseUrl + 'basket', basket).subscribe((response: IBasket) => {
      console.log("returned response", response);
      this.basketSource.next(response);
      this.calculateTotals();
    }, error => {
      console.log(error);
    })
  }
  
   setShippingPrice(deliveryMethod: IDeliveryMethod) {
    this.shipping = deliveryMethod.price;
    const basket = this.getCurrentBasketValue();
    basket.deliveryMethodId = deliveryMethod.id;
    basket.shippingPrice = deliveryMethod.price;
    this.calculateTotals();
    this.setBasket(basket);
  }
  
  getCurrentBasketValue(): IBasket {
    return this.basketSource.getValue();
  }
  
  addItemToBasket(item: IFood, quantity=1) {
    const itemToAdd: IBasketItem = this.mapFoodItemToBasketItem(item, quantity);
    let basket: IBasket;
    if(this.getCurrentBasketValue() != null) {
      basket = this.getCurrentBasketValue()
    } else {
      basket = new Basket();
    }
    basket.items = this.addOrUpdateItem(basket.items, itemToAdd, quantity);
    this.setBasket(basket);
  }
  
  addMealItemToBasket(item: IMeal, quantity=1) {
    const itemToAdd: IBasketItem = this.mapMealItemToBasketItem(item, quantity);
    let basket: IBasket;
    if(this.getCurrentBasketValue() != null) {
      basket = this.getCurrentBasketValue()
    } else {
      basket = new Basket();
    }
    basket.items = this.addOrUpdateItem(basket.items, itemToAdd, quantity);
    this.setBasket(basket);
  }

  private addOrUpdateItem(items: IBasketItem[], itemToAdd: IBasketItem, quantity: number): IBasketItem[] {
    const index = items.findIndex(i => i.id === itemToAdd.id);
    if (index === -1) {
      itemToAdd.quantity = quantity;
      items.push(itemToAdd);
    } else {
      items[index].quantity += quantity;
    }
    return items;
  }
  
  private addOrUpdateMealItem(items: IBasketMealItem[], itemToAdd: IBasketMealItem, quantity: number): IBasketMealItem[] {
    const index = items.findIndex(i => i.id === itemToAdd.id);
    if (index === -1) {
      itemToAdd.mealQuantity = quantity;
      items.push(itemToAdd);
    } else {
      items[index].mealQuantity += quantity;
    }
    return items;
  }

  incrementItemQuantity(item: IBasketItem) {
    const basket = this.getCurrentBasketValue();
    const foundItemIndex = basket.items.findIndex(x => x.id === item.id);
    basket.items[foundItemIndex].quantity++;
    this.setBasket(basket);
  }
  
  incrementMealItemQuantity(item: IBasketMealItem) {
    const basket = this.getCurrentBasketValue();
    const foundItemIndex = basket.mealItems.findIndex(x => x.id === item.id);
    basket.mealItems[foundItemIndex].mealQuantity++;
    this.setBasket(basket);
  }

  decrementItemQuantity(item: IBasketItem) {
    const basket = this.getCurrentBasketValue();
    const foundItemIndex = basket.items.findIndex(x => x.id === item.id);
    if (basket.items[foundItemIndex].quantity > 1) {
      basket.items[foundItemIndex].quantity--;
      this.setBasket(basket);
    } else {
      this.removeItemFromBasket(item);
    }
  }

  decrementMealItemQuantity(item: IBasketMealItem) {
    const basket = this.getCurrentBasketValue();
    const foundItemIndex = basket.mealItems.findIndex(x => x.id === item.id);
    if (basket.mealItems[foundItemIndex].mealQuantity > 1) {
      basket.mealItems[foundItemIndex].mealQuantity--;
      this.setBasket(basket);
    } else {
      this.removeMealItemFromBasket(item);
    }
  }

  removeItemFromBasket(item: IBasketItem) {
    const basket = this.getCurrentBasketValue();
    if (basket.items.some(x => x.id === item.id)) {
      basket.items = basket.items.filter(i => i.id !== item.id);
      if (basket.items.length > 0) {
        this.setBasket(basket);
      } else {
        this.deleteBasket(basket); 
      }
    }
  }
   
  removeMealItemFromBasket(item: IBasketMealItem) {
    const basket = this.getCurrentBasketValue();
    if (basket.mealItems.some(x => x.id === item.id)) {
      basket.mealItems = basket.mealItems.filter(i => i.id !== item.id);
      if (basket.mealItems.length > 0) {
        this.setBasket(basket);
      } else {
        this.deleteBasket(basket); 
      }
    }
  }

  deleteBasket(basket: IBasket) {
    return this.http.delete(this.baseUrl + 'basket?id=' + basket.id).subscribe(() => {
      this.basketSource.next(null);
      this.basketTotalSource.next(null);
      localStorage.removeItem('basket_id');
    }, error => {
      console.log(error);
    })
  }

  private createBasket(): IBasket {
    const basket = new Basket();
    localStorage.setItem('basket_id',basket.id.toString());
    return basket;
  }
  
  private mapFoodItemToBasketItem(item: IFood, quantity: number): IBasketItem {
    return {
      id: item?.id,
      foodName: item?.foodName,
      price: item?.price,
      pictureUrl: item?.pictureUrl,
      quantity
    }
  }
  
  private mapMealItemToBasketItem(item: IMeal, quantity: number): IBasketItem {
    return {
      id: item?.id,
      foodName: item?.mealName,
      price: item?.price,
      pictureUrl: item?.pictureUrl,
      quantity
    }
  }
  
  deleteLocalBasket(id: number) {
    this.basketSource.next(null);
    this.basketTotalSource.next(null);
    localStorage.removeItem('basket_id');
  }

   private calculateTotals() {
    const basket = this.getCurrentBasketValue();
    const shipping = this.shipping;
    const subtotal = basket.items.reduce((a, b) => (b.price * b.quantity) + a, 0);
    const total = subtotal + shipping;
    this.basketTotalSource.next({shipping, total, subtotal});
  }

   private mealCalculateTotals() {
    const basket = this.getCurrentBasketValue();
    const shipping = this.shipping;
    const subtotal = basket.mealItems.reduce((a, b) => (b.mealPrice * b.mealQuantity) + a, 0);
    const total = subtotal + shipping;
    this.basketTotalSource.next({shipping, total, subtotal});
  }

}
