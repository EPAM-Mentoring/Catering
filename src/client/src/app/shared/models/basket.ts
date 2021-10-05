import {v4 as uuidv4} from 'uuid';

export interface IBasket {
    id: number;
    deliveryMethodId?: number;
    shippingPrice?: number;
    items: IBasketItem[];
    mealItems: IBasketMealItem[];
}

export interface IBasketItem {
    id: number;
    foodName: string;
    price: number;
    quantity: number;
    pictureUrl: string;
}

export interface IBasketMealItem {
    id: number;
    mealName: string;
    mealPrice: number;
    mealQuantity: number;
    mealPictureUrl: string;
}

export class Basket implements IBasket {
     id = Number(uuidv4());
    items: IBasketItem[] = [];
    mealItems: IBasketMealItem[] =  [];
}

export interface IBasketTotals {
    shipping: number;
    subtotal: number;
    total: number;
}
